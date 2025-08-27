namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record RequiredActionProviders
{
	[JsonPropertyName("terms_and_conditions")]
	public HasOrder TermsAndConditions { get; set; } = new ();

	[JsonPropertyName("CONFIGURE_TOTP")]
	public HasOrder ConfigureTotp { get; set; } = new ();

	[JsonPropertyName("VERIFY_EMAIL")]
	public HasOrder VerifyEmail { get; set; } = new ();

	[JsonPropertyName("UPDATE_PASSWORD")]
	public HasOrder UpdatePassword { get; set; } = new ();

	[JsonPropertyName("UPDATE_PROFILE")]
	public HasOrder UpdateProfile { get; set; } = new ();
}
