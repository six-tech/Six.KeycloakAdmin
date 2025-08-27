namespace Six.KeycloakAdmin.Models.AuthenticationManagement;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthenticatorConfig
{
	[JsonPropertyName("alias")]
	public string Alias { get; set; } = string.Empty;
	[JsonPropertyName("config")]
	public IDictionary<string, object> Config { get; set; } = new Dictionary<string, object>();
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
}
