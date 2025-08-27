namespace Six.KeycloakAdmin.Models.AuthorizationPermissions;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthorizationPermission
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("description")]
	public string Description { get; set; } = string.Empty;

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public AuthorizationPermissionType Type { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PolicyDecisionLogic Logic { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public DecisionStrategy DecisionStrategy { get; set; }

	[JsonPropertyName("resourceType")]
	public string ResourceType { get; set; } = string.Empty;

	[JsonPropertyName("resources")]
	public IEnumerable<string> ResourceIds { get; set; } = [];

	[JsonPropertyName("scopes")]
	public IEnumerable<string> ScopeIds { get; set; } = [];

	[JsonPropertyName("policies")]
	public IEnumerable<string> PolicyIds { get; set; } = [];
}

public enum PolicyDecisionLogic
{
	Positive,
	Negative
}

public enum AuthorizationPermissionType
{
	Scope,
	Resource
}

public enum DecisionStrategy
{
	Unanimous,
	Affirmative,
	Consensus
}
