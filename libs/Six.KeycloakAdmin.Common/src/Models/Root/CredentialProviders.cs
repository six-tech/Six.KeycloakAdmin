namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record CredentialProviders
{
	[JsonPropertyName("keycloak-otp")]
	public HasOrder KeycloakOtp { get; set; } = new();

	[JsonPropertyName("keycloak-password")]
	public HasOrder KeycloakPassword { get; set; } = new();
}
