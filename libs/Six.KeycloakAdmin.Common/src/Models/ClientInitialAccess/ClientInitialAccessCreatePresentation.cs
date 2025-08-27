namespace Six.KeycloakAdmin.Models.ClientInitialAccess;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ClientInitialAccessCreatePresentation
{
	[JsonPropertyName("count")]
	public int? Count { get; set; }
	[JsonPropertyName("expiration")]
	public int? Expiration { get; set; }
}
