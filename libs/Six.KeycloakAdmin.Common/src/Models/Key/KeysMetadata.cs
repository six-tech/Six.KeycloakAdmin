namespace Six.KeycloakAdmin.Models.Key;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record KeysMetadata
{
	[JsonPropertyName("active")]
	public Active Active { get; set; } = new();
	[JsonPropertyName("keys")]
	public IEnumerable<Key> Keys { get; set; } = [];
}
