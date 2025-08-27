namespace Six.KeycloakAdmin.Models.RealmsAdmin;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Config
{
	[JsonPropertyName("hideOnLoginPage")]
	public string HideOnLoginPage { get; set; } = string.Empty;
	[JsonPropertyName("clientSecret")]
	public string ClientSecret { get; set; } = string.Empty;
	[JsonPropertyName("clientId")]
	public string ClientId { get; set; } = string.Empty;
	[JsonPropertyName("disableUserInfo")]
	public string DisableUserInfo { get; set; } = string.Empty;
	[JsonPropertyName("useJwksUrl")]
	public string UseJwksUrl { get; set; } = string.Empty;
}
