namespace Six.KeycloakAdmin.Models.UserStorageProvider;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record SynchronizationResult
{
	[JsonPropertyName("added")]
	public int? Added { get; set; }
	[JsonPropertyName("failed")]
	public int? Failed { get; set; }
	[JsonPropertyName("ignored")]
	public bool? Ignored { get; set; }
	[JsonPropertyName("removed")]
	public int? Removed { get; set; }
	[JsonPropertyName("status")]
	public string Status { get; set; } = string.Empty;
	[JsonPropertyName("updated")]
	public int? Updated { get; set; }
}
