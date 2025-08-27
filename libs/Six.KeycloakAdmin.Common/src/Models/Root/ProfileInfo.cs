namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ProfileInfo
{
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("disabledFeatures")]
	public List<string> DisabledFeatures { get; set; } = [];

	[JsonPropertyName("previewFeatures")]
	public List<string> PreviewFeatures { get; set; } = [];

	[JsonPropertyName("experimentalFeatures")]
	public List<string> ExperimentalFeatures { get; set; } = [];
}
