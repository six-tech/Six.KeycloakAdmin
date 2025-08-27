namespace Six.KeycloakAdmin.Models.AuthenticationManagement;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthenticationFlow
{
	[JsonPropertyName("alias")]
	public string Alias { get; set; } = string.Empty;
	[JsonPropertyName("authenticationExecutions")]
	public IEnumerable<AuthenticationExecutionExport> AuthenticationExecutions { get; set; } = [];
	[JsonPropertyName("builtIn")]
	public bool? BuiltIn { get; set; }
	[JsonPropertyName("description")]
	public string Description { get; set; } = string.Empty;
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("providerId")]
	public string ProviderId { get; set; } = string.Empty;
	[JsonPropertyName("topLevel")]
	public bool? TopLevel { get; set; }
}
