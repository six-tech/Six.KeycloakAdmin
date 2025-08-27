namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record OperationalInfo
{
	[JsonPropertyName("databaseUrl")]
	public string DatabaseUrl { get; set; } = string.Empty;

	[JsonPropertyName("databaseUser")]
	public string DatabaseUser { get; set; } = string.Empty;

	[JsonPropertyName("databaseProduct")]
	public string DatabaseProduct { get; set; } = string.Empty;

	[JsonPropertyName("databaseDriver")]
	public string DatabaseDriver { get; set; } = string.Empty;
}
