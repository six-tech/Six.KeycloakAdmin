using System.Text.Json;
using Microsoft.Extensions.Options;
using Six.KeycloakAdmin.TokenCache;

namespace Six.KeycloakAdmin.TokenProvider;

/// <summary>
/// Token provider for client credentials authentication
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public class ClientSecretTokenProvider : TokenProviderBase
{
  public ClientSecretTokenProvider(
    IHttpClientFactory httpClientFactory,
    ITokenCache tokenCache,
    IOptions<KeycloakAdminOptions> options)
    : base(httpClientFactory, tokenCache, options) { }

  /// <summary>
  /// Gets a token using client credentials authentication
  /// </summary>
  public async Task<string?> GetTokenAsync(
    string realm,
    string clientSecret,
    CancellationToken cancellationToken = default)
  {
    if(string.IsNullOrEmpty(realm))
      throw new ArgumentException("Realm cannot be null or empty", nameof(realm));
    
    if(string.IsNullOrEmpty(clientSecret))
      throw new ArgumentException("Client secret cannot be null or empty", nameof(clientSecret));

    var cacheKey = $"keycloak:client:{realm}:{AdminOptions.AdminClientId}";

    return await GetTokenAsync(realm, cacheKey, async () =>
    {
      var tokenResponse = await RequestTokenResponseAsync(realm, clientSecret, cancellationToken);
      if (tokenResponse is null)
        return null;
        
      return CreateTokenCacheRecord(tokenResponse);
    }, cancellationToken);
  }

  async Task<AdminTokenResponse?> RequestTokenResponseAsync(
    string realm,
    string clientSecret,
    CancellationToken cancellationToken)
  {
    try
    {
      var httpClient = HttpClientFactory.CreateClient();
      var tokenEndpoint = BuildTokenEndpoint(realm);

      var requestBody = new List<KeyValuePair<string, string>>
      {
        new("grant_type", "client_credentials"), 
        new("client_id", AdminOptions.AdminClientId), 
        new("client_secret", clientSecret)
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