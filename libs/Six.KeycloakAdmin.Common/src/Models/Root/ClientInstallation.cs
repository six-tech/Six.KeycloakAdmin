namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ClientInstallation
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	[JsonPropertyName("protocol")]
	public Protocol Protocol { get; set; } = new();

	[JsonPropertyName("downloadOnly")]
	public bool? DownloadOnly { get; set; }

	[JsonPropertyName("displayType")]
	public string DisplayType { get; set; } = string.Empty;

	[JsonPropertyName("helpText")]
	public string HelpText { get; set; } = string.Empty;

	[JsonPropertyName("filename")]
	public string FileName { get; set; } = string.Empty;

	[JsonPropertyName("mediaType")]
	public string MediaType { get; set; } = string.Empty;
}
