namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record FormAuthenticatorProviders
{
	[JsonPropertyName("registration-page-form")]
	public HasOrder RegistrationPageForm { get; set; } = new ();
}
