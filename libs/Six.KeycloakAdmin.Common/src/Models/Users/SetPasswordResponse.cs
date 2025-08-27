namespace Six.KeycloakAdmin.Models.Users;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record SetPasswordResponse
{
	public bool Success { get; set; }
	[JsonPropertyName("error")]
	public string Error { get; set; } = string.Empty;
	[JsonPropertyName("error_description")]
	public string ErrorDescription { get; set; } = string.Empty;
}
