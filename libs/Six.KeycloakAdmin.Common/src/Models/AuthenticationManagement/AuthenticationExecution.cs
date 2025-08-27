namespace Six.KeycloakAdmin.Models.AuthenticationManagement;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthenticationExecution : AuthenticationExecutionBase
{
	[JsonPropertyName("flowId")]
	public string FlowId { get; set; } = string.Empty;
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("parentFlow")]
	public string ParentFlow { get; set; } = string.Empty;
}
