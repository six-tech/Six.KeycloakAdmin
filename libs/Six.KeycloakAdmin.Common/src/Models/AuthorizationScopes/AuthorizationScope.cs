namespace Six.KeycloakAdmin.Models.AuthorizationScopes;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthorizationScope
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
	[JsonPropertyName("displayName")]
	public string DisplayName { get; set; } = string.Empty;
}
