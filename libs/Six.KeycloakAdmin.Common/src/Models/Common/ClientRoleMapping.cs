using Six.KeycloakAdmin.Models.Roles;

namespace Six.KeycloakAdmin.Models.Common;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ClientRoleMapping
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("client")]
	public string Client { get; set; } = string.Empty;
	[JsonPropertyName("mappings")]
	public List<Role> Mappings { get; set; } = [];
}
