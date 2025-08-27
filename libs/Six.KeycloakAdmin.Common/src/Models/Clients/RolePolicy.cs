using Six.KeycloakAdmin.Models.AuthorizationPermissions;

namespace Six.KeycloakAdmin.Models.Clients;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Policy
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("description")]
	public string Description { get; set; } = string.Empty;

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PolicyType Type { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PolicyDecisionLogic Logic { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public DecisionStrategy DecisionStrategy { get; set; }

	[JsonPropertyName("config")]
	public PolicyConfig Config { get; set; } = new();
}


[PublicAPI]
[ExcludeFromCodeCoverage]
public record RolePolicy
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("description")]
	public string Description { get; set; } = string.Empty;

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PolicyType Type { get; set; } = PolicyType.Role;

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PolicyDecisionLogic Logic { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public DecisionStrategy DecisionStrategy { get; set; }

	[JsonPropertyName("roles")]
	public IEnumerable<RoleConfig> RoleConfigs { get; set; } = [];
}

public record RoleConfig
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	[JsonPropertyName("required")]
	public bool Required { get; set; }
}

public record UserPolicy
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("description")]
	public string Description { get; set; } = string.Empty;

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PolicyType Type { get; set; } = PolicyType.User;

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PolicyDecisionLogic Logic { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public DecisionStrategy DecisionStrategy { get; set; }

	[JsonPropertyName("users")]
	public IEnumerable<string> Users { get; set; } = [];
}

public record GroupPolicy
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("description")]
	public string Description { get; set; } = string.Empty;

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PolicyType Type { get; set; } = PolicyType.Group;

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PolicyDecisionLogic Logic { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public DecisionStrategy DecisionStrategy { get; set; }

	[JsonPropertyName("groups")]
	public IEnumerable<GroupConfig> GroupConfigs { get; set; } = [];

	[JsonPropertyName("groupsClaim")]
	public string GroupsClaim { get; set; } = string.Empty;
}

public record GroupConfig
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	[JsonPropertyName("path")]
	public string Path { get; set; } = string.Empty;

	[JsonPropertyName("extendChildren")]
	public bool ExtendChildren { get; set; }
}

public enum PolicyType
{
	Role,
	Client,
	Time,
	User,
	Aggregate,
	Group,
	Js
}

public record PolicyConfig
{
	[JsonPropertyName("roles")]
	public IEnumerable<RoleConfig> RoleConfigs { get; set; } = [];
}
