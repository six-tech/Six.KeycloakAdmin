namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Enums
{
  [JsonPropertyName("operationType")] public List<string> OperationType { get; set; } = [];

	[JsonPropertyName("eventType")]
	public List<string> EventType { get; set; } = [];

	[JsonPropertyName("resourceType")]
	public List<string> ResourceType { get; set; } = [];
}
