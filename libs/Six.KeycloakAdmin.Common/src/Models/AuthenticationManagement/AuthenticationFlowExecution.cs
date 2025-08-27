namespace Six.KeycloakAdmin.Models.AuthenticationManagement;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthenticationFlowExecution
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("requirement")]
	public string Requirement { get; set; } = string.Empty;
	[JsonPropertyName("displayName")]
	public string DisplayName { get; set; } = string.Empty;
	[JsonPropertyName("requirementChoices")]
	public IEnumerable<string> RequirementChoices { get; set; } = [];
	[JsonPropertyName("configurable")]
	public bool? Configurable { get; set; }
	[JsonPropertyName("providerId")]
	public string ProviderId { get; set; } = string.Empty;
	[JsonPropertyName("level")]
	public int? Level { get; set; }
	[JsonPropertyName("index")]
	public int? Index { get; set; }
	[JsonPropertyName("authenticationFlow")]
	public bool? AuthenticationFlow { get; set; }
	[JsonPropertyName("flowId")]
	public string FlowId { get; set; } = string.Empty;
}
