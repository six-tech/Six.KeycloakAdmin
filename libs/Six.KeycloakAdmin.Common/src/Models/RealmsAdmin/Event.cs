namespace Six.KeycloakAdmin.Models.RealmsAdmin;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Event
{
	[JsonPropertyName("clientId")]
	public string ClientId { get; set; } = string.Empty;
	[JsonPropertyName("details")]
	public IDictionary<string, object> Details { get; set; } = new Dictionary<string, object>();
	[JsonPropertyName("error")]
	public string Error { get; set; } = string.Empty;
	[JsonPropertyName("ipAddress")]
	public string IpAddress { get; set; } = string.Empty;
	[JsonPropertyName("realmId")]
	public string RealmId { get; set; } = string.Empty;
	[JsonPropertyName("sessionId")]
	public string SessionId { get; set; } = string.Empty;
	[JsonPropertyName("time")]
	public long Time { get; set; }
	[JsonPropertyName("type")]
	public string Type { get; set; } = string.Empty;
	[JsonPropertyName("userId")]
	public string UserId { get; set; } = string.Empty;
}
