namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record SamlConfig
{
	[JsonPropertyName("attribute.nameformat")]
	public string AttributeNameformat { get; set; } = string.Empty;

	[JsonPropertyName("user.attribute")]
	public string UserAttribute { get; set; } = string.Empty;

	[JsonPropertyName("friendly.name")]
	public string FriendlyName { get; set; } = string.Empty;

	[JsonPropertyName("attribute.name")]
	public string AttributeName { get; set; } = string.Empty;

	[JsonPropertyName("single")]
	public string? Single { get; set; }
}
