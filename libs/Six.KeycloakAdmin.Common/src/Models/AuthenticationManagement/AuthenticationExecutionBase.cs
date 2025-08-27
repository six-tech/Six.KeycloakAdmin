namespace Six.KeycloakAdmin.Models.AuthenticationManagement;

[PublicAPI]
[ExcludeFromCodeCoverage]
public abstract record AuthenticationExecutionBase
{
  [JsonPropertyName("authenticator")] public string Authenticator { get; set; } = string.Empty;

  [JsonPropertyName("authenticatorConfig")]
  public string AuthenticatorConfig { get; set; } = string.Empty;

  [JsonPropertyName("authenticatorFlow")]
  public bool? AuthenticatorFlow { get; set; }

  [JsonPropertyName("priority")] public int? Priority { get; set; }
  [JsonPropertyName("requirement")] public string Requirement { get; set; } = string.Empty;
}
