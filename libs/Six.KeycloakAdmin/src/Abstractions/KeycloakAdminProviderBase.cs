using System.Text.Json;
using Microsoft.Extensions.Options;
using Six.KeycloakAdmin.Services;

namespace Six.KeycloakAdmin;

/// <summary>
/// Base class for Keycloak admin client implementations
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public abstract class KeycloakAdminProviderBase : IKeycloakAdminProvider
{
  internal IKeycloakJsonSerializer JsonSerializer;
  protected readonly IHttpClientFactory HttpClientFactory;
  protected readonly KeycloakAdminOptions AdminOptions;

  #region Properties

  public AttackDetection AttackDetection { get; }
  public AuthenticationManagement AuthenticationManagement { get; }
  public AuthZResource AuthorizationResource { get; }
  public AuthZScope AuthorizationScope { get; }
  public ClientAuthorization ClientAuthorization { get; }
  public ClientAttributeCertificate ClientAttributeCertificate { get; }
  public ClientInitialAccess ClientInitialAccess { get; }
  public ClientRegistrationPolicy ClientRegistrationPolicy { get; }
  public Clients Clients { get; }
  public ClientScopes ClientScopes { get; }
  public ProtocolMappers ProtocolMappers { get; }
  public ScopeMappings ScopeMappings { get; }
  public Components Components { get; }
  public ClientRoleMappings ClientRoleMappings { get; }
  public Groups Groups { get; }
  public GroupsRoleMapper GroupsRoleMapper { get; }
  public IdentityProviders IdentityProviders { get; }
  public Keys Keys { get; }
  public OpenIDConfiguration OpenIdConfiguration { get; }
  public Organizations Organizations { get; }
  public Realms Realms { get; }
  public Roles Roles { get; }
  public RolesById RolesById { get; }
  public ServerInfo ServerInfo { get; }
  public UserStorageProvider UserStorageProvider { get; }
  public Users Users { get; }

  #endregion

  protected KeycloakAdminProviderBase(
    IHttpClientFactory httpClientFactory,
    IOptions<KeycloakAdminOptions> options)
  {
    HttpClientFactory = httpClientFactory;
    AdminOptions = options.Value;

    var serializerOptions = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
      WriteIndented = true
    };

    JsonSerializer = new DefaultJsonKeycloakJsonSerializer(serializerOptions);

    AttackDetection = new AttackDetection(this);
    AuthenticationManagement = new AuthenticationManagement(this);
    AuthorizationResource = new AuthZResource(this);
    AuthorizationScope = new AuthZScope(this);
    ClientAuthorization = new ClientAuthorization(this);
    ClientAttributeCertificate = new ClientAttributeCertificate(this);
    ClientInitialAccess = new ClientInitialAccess(this);
    ClientRegistrationPolicy = new ClientRegistrationPolicy(this);
    Clients = new Clients(this);
    ClientScopes = new ClientScopes(this);
    ProtocolMappers = new ProtocolMappers(this);
    ScopeMappings = new ScopeMappings(this);
    Components = new Components(this);
    ClientRoleMappings = new ClientRoleMappings(this);
    Groups = new Groups(this);
    GroupsRoleMapper = new GroupsRoleMapper(this);
    IdentityProviders = new IdentityProviders(this);
    Keys = new Keys(this);
    OpenIdConfiguration = new OpenIDConfiguration(this);
    Organizations = new Organizations(this);
    Realms = new Realms(this);
    Roles = new Roles(this);
    RolesById = new RolesById(this);
    ServerInfo = new ServerInfo(this);
    UserStorageProvider = new UserStorageProvider(this);
    Users = new Users(this);
  }

  public void SetSerializer(IKeycloakJsonSerializer keycloakJsonSerializer) => JsonSerializer = keycloakJsonSerializer;

  /// <summary>
  /// Gets a token for the specified realm, using the authentication realm if configured
  /// </summary>
  protected abstract Task<string?> GetTokenAsync(string realm, CancellationToken cancellationToken = default);

  internal async Task<HttpRequestBuilder> GetRequestBuilderAsync(string realm)
  {
    var httpClient = HttpClientFactory.CreateClient(AdminOptions.HttpClientName);
    var token = await GetTokenAsync(realm);

    if(string.IsNullOrEmpty(token))
      throw new InvalidOperationException($"Failed to obtain token for realm: {realm}");

    var baseUrl = GetBaseUrl();

    var requestBuilder = new HttpRequestBuilder(httpClient, baseUrl)
      .WithSettings(settings => settings.JsonSerializer = JsonSerializer)
      .WithOAuthBearerToken(token);

    return requestBuilder;
  }

  string GetBaseUrl()
  {
    var baseUrl = AdminOptions.BaseUrl;

    if(string.IsNullOrEmpty(baseUrl))
      throw new InvalidOperationException("Keycloak BaseUrl is not configured");

    // Ensure the base URL doesn't end with a slash for consistent path building
    if(baseUrl.EndsWith("/"))
      baseUrl = baseUrl.TrimEnd('/');

    return baseUrl;
  }
}

internal record CountDto(int Count);