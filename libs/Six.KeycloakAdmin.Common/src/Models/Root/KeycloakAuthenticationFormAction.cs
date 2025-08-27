using Six.KeycloakAdmin.Models.Common;

namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record KeycloakAuthenticationFormAction
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	[JsonPropertyName("helpText")]
	public string HelpText { get; set; } = string.Empty;

 [JsonPropertyName("properties")] public List<ConfigProperty> Properties { get; set; } = [];

	[JsonPropertyName("metadata")]
	public MetadataClass Metadata { get; set; } = new();
}
