using Microsoft.Extensions.Options;
using Six.KeycloakAdmin.AdminClients;
using Six.KeycloakAdmin.TokenProvider;

namespace Six.KeycloakAdmin;

/// <summary>
/// Service for creating and managing Keycloak client instances
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public class KeycloakAdminService : IKeycloakAdminService
{
  readonly IHttpClientFactory _httpClientFactory;
  readonly IOptions<KeycloakAdminOptions> _options;
  readonly ITokenCache _tokenCache;
  readonly BasicAuthTokenProvider _basicAuthProvider;
  readonly ClientSecretTokenProvider _clientSecretProvider;

  public KeycloakAdminService(
    IHttpClientFactory httpClientFactory,
    IOptions<KeycloakAdminOptions> options,
    ITokenCache tokenCache,
    BasicAuthTokenProvider basicAuthProvider,
    ClientSecretTokenProvider clientSecretProvider)
  {
    _httpClientFactory = httpClientFactory;
    _options = options;
    _tokenCache = tokenCache;
    _basicAuthProvider = basicAuthProvider;
    _clientSecretProvider = clientSecretProvider;
  }

  public IKeycloakAdminProvider GetAdminWithBasicAuth(string username, string password)
  {
    return new BasicAuthKeycloakAdminProvider(
      username,
      password,
      _httpClientFactory,
      _options,
      _basicAuthProvider);
  }

  public IKeycloakAdminProvider GetAdminWithSecret(string clientSecret)
  {
    return new SecretKeycloakAdminProvider(
      clientSecret,
      _httpClientFactory,
      _options,
      _clientSecretProvider);
  }

  public IKeycloakAdminProvider GetAdminWithToken(string token)
  {
    return new TokenKeycloakAdminProvider(
      token,
      _httpClientFactory,
      _options);
  }
}