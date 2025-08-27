namespace Six.KeycloakAdmin.Models.AuthenticationManagement;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record RequiredActionProvider
{
	[JsonPropertyName("alias")]
	public string Alias { get; set; } = string.Empty;
	[JsonPropertyName("config")]
	public IDictionary<string, object> Config { get; set; } = new Dictionary<string, object>();
	[JsonPropertyName("defaultAction")]
	public bool? DefaultAction { get; set; }
	[JsonPropertyName("enabled")]
	public bool? Enabled { get; set; }
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
	[JsonPropertyName("priority")]
	public int? Priority { get; set; }
	[JsonPropertyName("providerId")]
	public string ProviderId { get; set; } = string.Empty;
}
