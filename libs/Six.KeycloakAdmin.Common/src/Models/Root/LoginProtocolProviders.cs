namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record LoginProtocolProviders
{
  [JsonPropertyName("saml")] public HasOrder Saml { get; set; } = new();

  [JsonPropertyName("openid-connect")] public HasOrder OpenIdConnect { get; set; } = new();
}
