namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record FormActionProviders
{
	[JsonPropertyName("registration-profile-action")]
	public HasOrder RegistrationProfileAction { get; set; } = new ();

	[JsonPropertyName("registration-recaptcha-action")]
	public HasOrder RegistrationRecaptchaAction { get; set; } = new ();

	[JsonPropertyName("registration-password-action")]
	public HasOrder RegistrationPasswordAction { get; set; } = new ();

	[JsonPropertyName("registration-user-creation")]
	public HasOrder RegistrationUserCreation { get; set; } = new ();
}
