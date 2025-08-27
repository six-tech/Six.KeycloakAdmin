namespace Six.KeycloakAdmin.Models.Groups;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Group
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
	[JsonPropertyName("path")]
	public string Path { get; set; } = string.Empty;
	[JsonPropertyName("subGroups")]
	public IEnumerable<Group> Subgroups { get; set; } = [];
	[JsonPropertyName("realmRoles")]
	public IEnumerable<string> RealmRoles { get; set; } = [];
	[JsonPropertyName("clientRoles")]
	public IDictionary<string, IEnumerable<string>> ClientRoles { get; set; } = new Dictionary<string, IEnumerable<string>>();
	[JsonPropertyName("attributes")]
	public IDictionary<string, IEnumerable<string>> Attributes { get; set; } = new Dictionary<string, IEnumerable<string>>();
}
