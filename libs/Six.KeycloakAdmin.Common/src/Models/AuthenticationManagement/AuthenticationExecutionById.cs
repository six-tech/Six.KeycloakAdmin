namespace Six.KeycloakAdmin.Models.AuthenticationManagement;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthenticationExecutionById
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("authenticator")]
	public string Authenticator { get; set; } = string.Empty;
	[JsonPropertyName("authenticatorFlow")]
	public bool? AuthenticatorFlow { get; set; }
	[JsonPropertyName("requirement")]
	public string Requirement { get; set; } = string.Empty;
	[JsonPropertyName("priority")]
	public int? Priority { get; set; }
	[JsonPropertyName("parentFlow")]
	public string ParentFlow { get; set; } = string.Empty;
	[JsonPropertyName("optional")]
	public bool? Optional { get; set; }
	[JsonPropertyName("enabled")]
	public bool? Enabled { get; set; }
	[JsonPropertyName("required")]
	public bool? Required { get; set; }
	[JsonPropertyName("alternative")]
	public bool? Alternative { get; set; }
	[JsonPropertyName("disabled")]
	public bool? Disabled { get; set; }
}
