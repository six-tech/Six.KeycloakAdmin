namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AccountProviders
{
	[JsonPropertyName("freemarker")]
	public HasOrder Freemarker { get; set; } = new();
}
