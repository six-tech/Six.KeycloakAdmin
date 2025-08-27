namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ClientDescriptionConverterProviders
{
	[JsonPropertyName("keycloak")]
	public HasOrder Keycloak { get; set; } = new();

	[JsonPropertyName("saml2-entity-descriptor")]
	public HasOrder Saml2EntityDescriptor { get; set; } = new();

	[JsonPropertyName("openid-connect")]
	public HasOrder OpenIdConnect { get; set; } = new();
}
