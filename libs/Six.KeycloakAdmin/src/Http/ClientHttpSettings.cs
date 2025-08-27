namespace Six.KeycloakAdmin.Http;

/// <summary>
/// HTTP client settings to replace Flurl's ClientFlurlHttpSettings
/// </summary>
[ExcludeFromCodeCoverage]
internal sealed class ClientHttpSettings
{
  public IKeycloakJsonSerializer? JsonSerializer { get; set; }
}
