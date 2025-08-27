using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Six.KeycloakAdmin.TokenCache;
using Six.KeycloakAdmin.TokenProvider;

namespace Six.KeycloakAdmin;

/// <summary>
/// Base class for token providers with caching support
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public abstract class TokenProviderBase
{
  protected readonly IHttpClientFactory HttpClientFactory;
  protected readonly ITokenCache TokenCache;
  protected readonly KeycloakAdminOptions AdminOptions;
  readonly SemaphoreSlim _tokenSemaphore = new(1, 1);

  protected TokenProviderBase(
    IHttpClientFactory httpClientFactory,
    ITokenCache tokenCache,
    IOptions<KeycloakAdminOptions> options)
  {
    HttpClientFactory = httpClientFactory;
    TokenCache = tokenCache;
    AdminOptions = options.Value;
  }

  
  /// <summary>
  /// Gets a token with caching support and refresh token handling
  /// </summary>
  protected async Task<string?> GetTokenAsync(
    string realm, 
    string cacheKey,
    Func<Task<TokenCacheEntry?>> tokenFactory,
    CancellationToken cancellationToken = default)
  {
    await _tokenSemaphore.WaitAsync(cancellationToken);
    try
    {
      // Check cache first
      var cachedRecord = await TokenCache.GetAsync(cacheKey, cancellationToken);
      
      if(cachedRecord is not null && cachedRecord.IsValid)
        return cachedRecord.GetAccessToken();

      // If cached record exists with expired access token but valid refresh token, try to refresh
      if(cachedRecord is { HasRefreshToken: true, IsExpired: true })
      {
        try
        {
          // Try to refresh the access token using refresh token
          var refreshedRecord = await RefreshTokenAsync(realm, cachedRecord, cancellationToken);
          if(refreshedRecord is not null)
          {
            // Update cache with the refreshed token
            await TokenCache.SetAsync(cacheKey, refreshedRecord, cancellationToken);
            
            // Dispose the old expired record after successful refresh
            cachedRecord.Dispose();
            
            return refreshedRecord.GetAccessToken();
          }
        }
        catch(Exception)
        {
          // Refresh failed, remove from cache and dispose
          TokenCache.Remove(cacheKey);
          cachedRecord.Dispose();
        }
      }

      // Get new token from provider
      var tokenRecord = await tokenFactory();
      if(tokenRecord is null)
        return null;

      // Cache the new token record
      await TokenCache.SetAsync(cacheKey, tokenRecord, cancellationToken);
      
      // Get the access token before any potential disposal
      var accessToken = tokenRecord.GetAccessToken();
      
      // Check if the token was actually cached (it won't be if it expires too soon)
      var cachedCheck = await TokenCache.GetAsync(cacheKey, cancellationToken);
      if(cachedCheck is null)
      {
        // Token wasn't cached (likely expires too soon), dispose it
        tokenRecord.Dispose();
      }

      return accessToken;
    }
    finally
    {
      _tokenSemaphore.Release();
    }
  }

  
  /// <summary>
  /// Refreshes an access token using a refresh token. Override in derived classes to implement specific refresh logic.
  /// </summary>
  /// <param name="realm">The realm for token refresh</param>
  /// <param name="cachedEntry">The cached record containing the refresh token</param>
  /// <param name="cancellationToken">Cancellation token</param>
  /// <returns>A new TokenCacheRecord with refreshed tokens, or null if refresh failed</returns>
  /// <remarks>
  /// Override in derived classes to implement specific refresh logic
  /// </remarks>
  protected virtual async Task<TokenCacheEntry?> RefreshTokenAsync(
    string realm, 
    TokenCacheEntry cachedEntry, 
    CancellationToken cancellationToken = default)
  {
    if(!cachedEntry.HasRefreshToken)
      return null;

    try
    {
      var httpClient = HttpClientFactory.CreateClient();
      var tokenEndpoint = BuildTokenEndpoint(realm);

      var requestBody = new List<KeyValuePair<string, string>>
      {
        new("grant_type", "refresh_token"),
        new("client_id", AdminOptions.AdminClientId),
        new("refresh_token", cachedEntry.GetRefreshToken()!)
      };

      var response = await httpClient.PostAsync(
        tokenEndpoint,
        new FormUrlEncodedContent(requestBody),
        cancellationToken);

      if(!response.IsSuccessStatusCode)
        return null;

      var content = await response.Content.ReadAsStringAsync(cancellationToken);
      var tokenResponse = JsonSerializer.Deserialize<AdminTokenResponse>(content);

      if(tokenResponse is null)
        return null;

      return CreateTokenCacheRecord(tokenResponse);
    }
    catch(Exception)
    {
      return null;
    }
  }

  
  /// <summary>
  /// Validates a JWT token and extracts its expiry time
  /// </summary>
  protected bool ValidateToken(string? token, out DateTimeOffset? expiryTime)
  {
    expiryTime = null;

    try
    {
      if(string.IsNullOrEmpty(token))
        return false;

      // Basic JWT structure check (header.payload.signature)
      var parts = token.Split('.');
      if(parts.Length != 3)
      {
        return false;
      }

      // Parse token to check basic claims without signature validation
      var jwtToken = new JwtSecurityToken(token);

      // Check if the token is already expired
      var now = DateTime.UtcNow.Add(AdminOptions.TokenClockSkew);
      if(jwtToken.ValidTo < now)
      {
        return false;
      }

      // Extract expiry time
      expiryTime = new DateTimeOffset(jwtToken.ValidTo);

      return true;
    }
    catch(Exception)
    {
      return false;
    }
  }
  
  
  /// <summary>
  /// Builds the token endpoint URL for a realm
  /// </summary>
  protected string BuildTokenEndpoint(string realm)
  {
    if(string.IsNullOrEmpty(AdminOptions.BaseUrl))
      throw new InvalidOperationException("Keycloak BaseUrl is not configured");

    var baseUrl = AdminOptions.BaseUrl;
    if(baseUrl.EndsWith("/") == false)
      baseUrl += "/";

    return $"{baseUrl}realms/{realm}/protocol/openid-connect/token";
  }
  
  
  /// <summary>
  /// Creates a TokenCacheRecord from token response, extracting actual expiry from JWT
  /// </summary>
  internal TokenCacheEntry CreateTokenCacheRecord(AdminTokenResponse tokenResponse)
  {
    if (string.IsNullOrEmpty(tokenResponse.AccessToken))
      throw new ArgumentException("Access token is required", nameof(tokenResponse));

    // Try to extract actual expiry from JWT token
    DateTimeOffset expiryTime;
    if (ValidateToken(tokenResponse.AccessToken, out var jwtExpiryTime) && jwtExpiryTime.HasValue)
    {
      // Use actual JWT expiry time
      expiryTime = jwtExpiryTime.Value;
    }
    else
    {
      // Fallback to response expires_in or configuration
      var expiresInSeconds = tokenResponse.ExpiresIn > 0 
        ? tokenResponse.ExpiresIn 
        : AdminOptions.TokenExpirationSeconds;
      
      expiryTime = DateTimeOffset.UtcNow.AddSeconds(expiresInSeconds);
    }

    return new TokenCacheEntry(
      tokenResponse.AccessToken, 
      expiryTime, 
      tokenResponse.RefreshToken);
  }

}