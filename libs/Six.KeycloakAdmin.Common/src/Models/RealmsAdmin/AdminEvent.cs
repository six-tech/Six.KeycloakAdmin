namespace Six.KeycloakAdmin.Models.RealmsAdmin;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AdminEvent
{
	[JsonPropertyName("authDetails")]
	public AuthDetails AuthDetails { get; set; } = new();
	[JsonPropertyName("error")]
	public string Error { get; set; } = string.Empty;
	[JsonPropertyName("operationType")]
	public string OperationType { get; set; } = string.Empty;
	[JsonPropertyName("realmId")]
	public string RealmId { get; set; } = string.Empty;
	[JsonPropertyName("representation")]
	public string Representation { get; set; } = string.Empty;
	[JsonPropertyName("resourcePath")]
	public string ResourcePath { get; set; } = string.Empty;
	[JsonPropertyName("resourceType")]
	public string ResourceType { get; set; } = string.Empty;
	[JsonPropertyName("time")]
	public long? Time { get; set; }
}
