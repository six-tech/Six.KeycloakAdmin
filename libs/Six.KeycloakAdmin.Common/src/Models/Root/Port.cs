namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Port
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

 [JsonPropertyName("providers")] public ExportProviders Providers { get; set; } = new ();
}
