using Six.KeycloakAdmin.Models.Root;

namespace Six.KeycloakAdmin.Models.Common;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ConfigProperty
{
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("label")]
	public string Label { get; set; } = string.Empty;

	[JsonPropertyName("helpText")]
	public string HelpText { get; set; } = string.Empty;

	[JsonPropertyName("type")]
	public JsonTypeLabel Type { get; set; }

	[JsonPropertyName("secret")]
	public bool? Secret { get; set; }

	[JsonPropertyName("defaultValue")]
	public object DefaultValue { get; set; } = new();

	[JsonPropertyName("options")]
	public List<string> Options { get; set; } = [];
}
