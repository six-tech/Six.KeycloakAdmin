namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ConnectionsJpaProviders
{
	[JsonPropertyName("default")]
	public Default Default { get; set; } = new();
}
