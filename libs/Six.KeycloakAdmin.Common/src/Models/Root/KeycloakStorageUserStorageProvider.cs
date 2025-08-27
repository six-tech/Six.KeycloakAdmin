using Six.KeycloakAdmin.Models.Common;

namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record KeycloakStorageUserStorageProvider
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	[JsonPropertyName("helpText")]
	public string HelpText { get; set; } = string.Empty;

 [JsonPropertyName("properties")] public List<ConfigProperty> Properties { get; set; } = [];

	[JsonPropertyName("metadata")]
	public KeycloakStorageUserStorageProviderMetadata Metadata { get; set; } = new();
}
