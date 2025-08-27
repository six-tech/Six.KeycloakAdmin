namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record BuiltinProtocolMappers
{
	[JsonPropertyName("saml")]
	public List<Saml> Saml { get; set; } = [];

	[JsonPropertyName("openid-connect")]
	public List<OpenIdConnect> OpenIdConnect { get; set; } = [];
}
