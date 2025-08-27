namespace Six.KeycloakAdmin.Models.AuthenticationManagement;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthenticationExecutionExport : AuthenticationExecutionBase
{
	[JsonPropertyName("flowAlias")]
	public string FlowAlias { get; set; } = string.Empty;
	[JsonPropertyName("userSetupAllowed")]
	public bool? UserSetupAllowed { get; set; }
}
