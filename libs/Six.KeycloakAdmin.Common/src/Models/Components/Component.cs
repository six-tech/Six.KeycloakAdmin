namespace Six.KeycloakAdmin.Models.Components;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Component
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
	[JsonPropertyName("providerId")]
	public string ProviderId { get; set; } = string.Empty;
	[JsonPropertyName("providerType")]
	public string ProviderType { get; set; } = string.Empty;
	[JsonPropertyName("parentId")]
	public string ParentId { get; set; } = string.Empty;
	[JsonPropertyName("config")]
	public Config Config { get; set; } = new();
	[JsonPropertyName("subType")]
	public string SubType { get; set; } = string.Empty;
}
