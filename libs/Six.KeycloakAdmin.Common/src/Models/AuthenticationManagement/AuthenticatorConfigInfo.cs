using Six.KeycloakAdmin.Models.Common;

namespace Six.KeycloakAdmin.Models.AuthenticationManagement;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthenticatorConfigInfo
{
	[JsonPropertyName("helpText")]
	public string HelpText { get; set; } = string.Empty;
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
	[JsonPropertyName("properties")]
	public IEnumerable<ConfigProperty> Properties { get; set; } = [];
	[JsonPropertyName("providerId")]
	public string ProviderId { get; set; } = string.Empty;
}
