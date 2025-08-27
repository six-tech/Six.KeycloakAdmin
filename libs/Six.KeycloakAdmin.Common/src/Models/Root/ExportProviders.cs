namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ExportProviders
{
	[JsonPropertyName("singleFile")]
	public HasOrder SingleFile { get; set; } = new ();

	[JsonPropertyName("dir")]
	public HasOrder Dir { get; set; } = new ();
}
