namespace Six.KeycloakAdmin.Models.ClientInitialAccess;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ClientInitialAccessPresentation : ClientInitialAccessCreatePresentation
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("remainingCount")]
	public int? RemainingCount { get; set; }
	[JsonPropertyName("timestamp")]
	public int? Timestamp { get; set; }
	[JsonPropertyName("token")]
	public string Token { get; set; } = string.Empty;
}
