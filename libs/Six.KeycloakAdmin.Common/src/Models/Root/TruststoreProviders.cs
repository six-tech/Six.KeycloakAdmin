namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record TruststoreProviders
{
	[JsonPropertyName("file")]
	public HasOrder File { get; set; } = new();
}
