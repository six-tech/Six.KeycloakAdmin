namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record WellKnownProviders
{
  [JsonPropertyName("openid-configuration")]
  public HasOrder OpenIdConfiguration { get; set; } = new();

	[JsonPropertyName("uma2-configuration")]
	public HasOrder Uma2Configuration { get; set; } = new();
}
