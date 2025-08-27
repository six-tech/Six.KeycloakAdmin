namespace Six.KeycloakAdmin.Models.AuthorizationResources;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthorizationResourceOwner
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
}
