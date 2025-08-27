namespace Six.KeycloakAdmin.Models.Roles;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record RoleComposite
{
	[JsonPropertyName("client")]
	public IDictionary<string, string> Client { get; set; } = new Dictionary<string, string>();
	[JsonPropertyName("realm")]
	public IEnumerable<string> Realm { get; set; } = [];
}
