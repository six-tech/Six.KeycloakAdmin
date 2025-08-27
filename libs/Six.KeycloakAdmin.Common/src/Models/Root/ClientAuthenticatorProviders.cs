namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ClientAuthenticatorProviders
{
	[JsonPropertyName("client-jwt")]
	public HasOrder ClientJwt { get; set; } = new();

	[JsonPropertyName("client-secret")]
	public HasOrder ClientSecret { get; set; } = new();

	[JsonPropertyName("client-x509")]
	public HasOrder ClientX509 { get; set; } = new();

	[JsonPropertyName("client-secret-jwt")]
	public HasOrder ClientSecretJwt { get; set; } = new();
}
