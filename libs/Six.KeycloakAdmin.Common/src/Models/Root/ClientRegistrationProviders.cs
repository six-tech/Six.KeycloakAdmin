namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ClientRegistrationProviders
{
	[JsonPropertyName("default")]
	public HasOrder Default { get; set; } = new();

	[JsonPropertyName("install")]
	public HasOrder Install { get; set; } = new();

	[JsonPropertyName("saml2-entity-descriptor")]
	public HasOrder Saml2EntityDescriptor { get; set; } = new();

	[JsonPropertyName("openid-connect")]
	public HasOrder OpenIdConnect { get; set; } = new();
}
