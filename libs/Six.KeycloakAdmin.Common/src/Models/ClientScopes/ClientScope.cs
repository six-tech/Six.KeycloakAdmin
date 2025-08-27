using Six.KeycloakAdmin.Models.ProtocolMappers;

namespace Six.KeycloakAdmin.Models.ClientScopes;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ClientScope
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
	[JsonPropertyName("description")]
	public string Description { get; set; } = string.Empty;
	[JsonPropertyName("protocol")]
	public string Protocol { get; set; } = string.Empty;
	[JsonPropertyName("attributes")]
	public Attributes Attributes { get; set; } = new();
	[JsonPropertyName("protocolMappers")]
	public IEnumerable<ProtocolMapper> ProtocolMappers { get; set; } = [];
}
