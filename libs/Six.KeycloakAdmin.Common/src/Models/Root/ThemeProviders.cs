namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ThemeProviders
{
  [JsonPropertyName("folder")] public HasOrder Folder { get; set; } = new ();

	[JsonPropertyName("module")]
	public HasOrder Module { get; set; } = new ();

	[JsonPropertyName("jar")]
	public HasOrder Jar { get; set; } = new ();

	[JsonPropertyName("extending")]
	public HasOrder Extending { get; set; } = new ();
}
