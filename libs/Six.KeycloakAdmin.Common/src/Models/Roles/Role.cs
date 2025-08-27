namespace Six.KeycloakAdmin.Models.Roles;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Role
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
	[JsonPropertyName("description")]
	public string Description { get; set; } = string.Empty;
	[JsonPropertyName("composite")]
	public bool? Composite { get; set; }
	[JsonPropertyName("composites")]
	public RoleComposite Composites { get; set; } = new();
	[JsonPropertyName("clientRole")]
	public bool? ClientRole { get; set; }
	[JsonPropertyName("containerId")]
	public string ContainerId { get; set; } = string.Empty;
	[JsonPropertyName("attributes")]
	public IDictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
}
