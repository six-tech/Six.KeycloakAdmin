using Six.KeycloakAdmin.Models.Common;

namespace Six.KeycloakAdmin.Models.Components;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ComponentType
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("helpText")]
	public string HelpText { get; set; } = string.Empty;
	[JsonPropertyName("properties")]
	public IEnumerable<ConfigProperty> Properties { get; set; } = [];
	[JsonPropertyName("metadata")]
	public IDictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();
}
