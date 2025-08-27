namespace Six.KeycloakAdmin;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record KeycloakAdminOptions
{
  /// <summary>
  /// Base URL of the Keycloak server (e.g., <c>https://localhost:51214</c> or <c>https://keycloak.example.com</c>)
  /// </summary>
  /// <remarks>For Keycloak 17+, this should be just the base URL without any path segments</remarks>
  public string BaseUrl { get; set; } = string.Empty;

  /// <summary>
  /// <para>
  /// The client ID used for authenticating with the Keycloak admin endpoints.
  /// </para>
  /// <para>
  /// Keycloak uses the <c>admin-cli</c> client by default for admin operations.
  /// This client is typically used for administrative tasks and requires the appropriate permissions.
  /// </para>
  /// </summary>
  /// <remarks>Default value is <c>admin-cli</c></remarks>
  public string AdminClientId { get; set; } = "admin-cli";
  
  /// <summary>
  /// <para>
  /// The name of the HttpClient used for making requests to the Keycloak server.
  /// </para>
  /// <para>
  /// <c>KeycloakAdmin</c> automatically creates and registers a named <c>HttpClient</c> with this name.
  /// </para>
  /// </summary>
  /// <remarks>Default value is <c>KeyCloakAdmin</c></remarks>
  public string HttpClientName { get; set; } = "KeyCloakAdmin";
  
  /// <summary>
  /// HTTP client timeout for requests to Keycloak server
  /// </summary>
  public TimeSpan HttpTimeout { get; set; } = TimeSpan.FromSeconds(30);
  
  /// <summary>
  /// By default, the expiration from token is used. If expiration is not set in the token,
  /// then this value is used to determine how long the token is valid <b>[in seconds]</b>.
  /// </summary>
  /// <remarks>Defaults to <c>1 hour [3600 seconds]</c></remarks>
  public int TokenExpirationSeconds { get; set; } = 3600;

  /// <summary>
  /// Specifies the amount of allowable clock skew when validating token expiration times.
  /// This helps account for potential time synchronization issues between servers.
  /// </summary>
  /// <remarks>Defaults to <c>1 minute</c></remarks>
  public TimeSpan TokenClockSkew { get; set; } = TimeSpan.FromMinutes(1);
}