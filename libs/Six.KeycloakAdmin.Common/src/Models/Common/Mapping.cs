using Six.KeycloakAdmin.Models.Roles;

namespace Six.KeycloakAdmin.Models.Common;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Mapping
{
  [JsonPropertyName("clientMappings")]
  public IDictionary<string, ClientRoleMapping> ClientMappings { get; set; } =
    new Dictionary<string, ClientRoleMapping>();

  [JsonPropertyName("realmMappings")] public IEnumerable<Role> RealmMappings { get; set; } = [];
}
