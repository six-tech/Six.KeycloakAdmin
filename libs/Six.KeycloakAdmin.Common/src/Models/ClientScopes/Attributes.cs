namespace Six.KeycloakAdmin.Models.ClientScopes;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Attributes
{
	[JsonPropertyName("consent.screen.text")]
	public string ConsentScreenText { get; set; } = string.Empty;
	[JsonPropertyName("display.on.consent.screen")]
	public string DisplayOnConsentScreen { get; set; } = string.Empty;
	[JsonPropertyName("include.in.token.scope")]
	public string IncludeInTokenScope { get; set; } = string.Empty;
	[JsonPropertyName("gui.order")]
	public string DisplayOrder { get; set; } = string.Empty;
}
