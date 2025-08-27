using Six.KeycloakAdmin.Models.Common;

namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ProtocolMapperType
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

 [JsonPropertyName("category")] public Category Category { get; set; } = new();

	[JsonPropertyName("helpText")]
	public string HelpText { get; set; } = string.Empty;

	[JsonPropertyName("priority")]
	public long Priority { get; set; }

	[JsonPropertyName("properties")]
	public List<ConfigProperty> Properties { get; set; } = [];
}
