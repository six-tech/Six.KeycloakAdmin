using Six.KeycloakAdmin.Models.Roles;

namespace Six.KeycloakAdmin.Models.RealmsAdmin;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Roles
{
	[JsonPropertyName("client")]
	public IDictionary<string, object> Client { get; set; } = new Dictionary<string, object>();
	[JsonPropertyName("realm")]
	public IEnumerable<Role> Realm { get; set; } = [];
}
