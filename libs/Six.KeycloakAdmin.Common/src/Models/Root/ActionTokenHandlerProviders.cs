namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ActionTokenHandlerProviders
{
	[JsonPropertyName("verify-email")]
	public HasOrder VerifyEmail { get; set; } = new();

	[JsonPropertyName("execute-actions")]
	public HasOrder ExecuteActions { get; set; } = new();

	[JsonPropertyName("reset-credentials")]
	public HasOrder ResetCredentials { get; set; } = new();

	[JsonPropertyName("idp-verify-account-via-email")]
	public HasOrder IdpVerifyAccountViaEmail { get; set; } = new();
}
