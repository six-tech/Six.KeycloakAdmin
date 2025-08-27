namespace Six.KeycloakAdmin.Models.AuthenticationManagement;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthenticationExecutionInfo
{
	[JsonPropertyName("alias")]
	public string Alias { get; set; } = string.Empty;
	[JsonPropertyName("authenticationConfig")]
	public string AuthenticationConfig { get; set; } = string.Empty;
	[JsonPropertyName("authenticationFlow")]
	public bool? AuthenticationFlow { get; set; }
	[JsonPropertyName("configurable")]
	public bool? Configurable { get; set; }
	[JsonPropertyName("displayName")]
	public string DisplayName { get; set; } = string.Empty;
	[JsonPropertyName("flowId")]
	public string FlowId { get; set; } = string.Empty;
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("index")]
	public int? Index { get; set; }
	[JsonPropertyName("level")]
	public int? Level { get; set; }
	[JsonPropertyName("providerId")]
	public string ProviderId { get; set; } = string.Empty;
	[JsonPropertyName("requirement")]
	public string Requirement { get; set; } = string.Empty;
	[JsonPropertyName("requirementChoices")]
	public IEnumerable<string> RequirementChoices { get; set; } = [];
}
