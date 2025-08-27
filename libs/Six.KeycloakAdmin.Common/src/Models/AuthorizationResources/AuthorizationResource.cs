using Six.KeycloakAdmin.Models.AuthorizationScopes;

namespace Six.KeycloakAdmin.Models.AuthorizationResources;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthorizationResource
{
	[JsonPropertyName("_id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("scopes")]
	public IEnumerable<AuthorizationScope> Scopes { get; set; } = [];
	[JsonPropertyName("attributes")]
	public Dictionary<string, IEnumerable<string>> Attributes { get; set; } = [];
	[JsonPropertyName("uris")]
	public IEnumerable<string> Uris { get; set; } = [];
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
	[JsonPropertyName("ownerManagedAccess")]
	public bool? OwnerManagedAccess { get; set; }
	[JsonPropertyName("displayName")]
	public string DisplayName { get; set; } = string.Empty;
	[JsonPropertyName("type")]
	public string Type { get; set; } = string.Empty;
	[JsonPropertyName("owner")]
	public AuthorizationResourceOwner Owner { get; set; } = new();
}
