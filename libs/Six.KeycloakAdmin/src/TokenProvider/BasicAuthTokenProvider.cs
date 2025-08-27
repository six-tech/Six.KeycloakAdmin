using System.Text.Json;
using Microsoft.Extensions.Options;
using Six.KeycloakAdmin.TokenCache;

namespace Six.KeycloakAdmin.TokenProvider;

/// <summary>
/// Token provider for username/password authentication
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public class BasicAuthTokenProvider : TokenProviderBase
{
  public BasicAuthTokenProvider(
    IHttpClientFactory httpClientFactory,
    ITokenCache tokenCache,
    IOptions<KeycloakAdminOptions> options)
    : base(httpClientFactory, tokenCache, options) { }

  /// <summary>
  /// Gets a token using username and password authentication
  /// </summary>
  public async Task<string?> GetTokenAsync(
    string realm,
    string username,
    string password,
    CancellationToken cancellationToken = default)
  {
    if(string.IsNullOrEmpty(realm))
      throw new ArgumentException("Realm cannot be null or empty", nameof(realm));
    
    if(string.IsNullOrEmpty(username))
      throw new ArgumentException("Username cannot be null or empty", nameof(username));
    
    if(string.IsNullOrEmpty(password))
      throw new ArgumentException("Password cannot be null or empty", nameof(password));

    var cacheKey = $"keycloak:basic:{realm}:{username}";

    return await GetTokenAsync(realm, cacheKey, async () =>
    {
      var tokenResponse = await RequestTokenResponseAsync(realm, username, password, cancellationToken);
      if (tokenResponse is null)
        return null;
        
      return CreateTokenCacheRecord(tokenResponse);
    }, cancellationToken);
  }

  async Task<AdminTokenResponse?> RequestTokenResponseAsync(
    string realm,
    string username,
    string password,
    CancellationToken cancellationToken)
  {
    try
    {
      var httpClient = HttpClientFactory.CreateClient();
      var tokenEndpoint = BuildTokenEndpoint(realm);

      var requestBody = new List<KeyValuePair<string, string>>
      {
        new("grant_type", "password"),
        new("client_id", AdminOptions.AdminClientId),
        new("username", username),
        new("password", password)
      };

      var response = await httpClient.PostAsync(
        tokenEndpoint,
        new FormUrlEncodedContent(requestBody),
        cancellationToken);

      if(response.IsSuccessStatusCode == false)
        return null;

      var content = await response.Content.ReadAsStringAsync(cancellationToken);
      var tokenResponse = JsonSerializer.Deserialize<AdminTokenResponse>(content);

      return tokenResponse;
    }
    catch(Exception)
    {
      return null;
    }
  }
}