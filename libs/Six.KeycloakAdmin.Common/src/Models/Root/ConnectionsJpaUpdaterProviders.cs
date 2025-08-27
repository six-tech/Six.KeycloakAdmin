namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ConnectionsJpaUpdaterProviders
{
	[JsonPropertyName("liquibase")]
	public HasOrder Liquibase { get; set; } = new();
}
