namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record IdentityProviderProviders
{
	[JsonPropertyName("saml")]
	public HasOrder Saml { get; set; } = new();

	[JsonPropertyName("oidc")]
	public HasOrder Oidc { get; set; } = new();

	[JsonPropertyName("keycloak-oidc")]
	public HasOrder KeycloakOidc { get; set; } = new();
}
