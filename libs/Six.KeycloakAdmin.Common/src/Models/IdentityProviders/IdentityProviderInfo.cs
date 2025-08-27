namespace Six.KeycloakAdmin.Models.IdentityProviders;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record IdentityProviderInfo
{
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
}
