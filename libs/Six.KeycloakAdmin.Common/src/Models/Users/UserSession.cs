namespace Six.KeycloakAdmin.Models.Users;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record UserSession
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("username")]
	public string UserName { get; set; } = string.Empty;
	[JsonPropertyName("userId")]
	public string UserId { get; set; } = string.Empty;
	[JsonPropertyName("ipAddress")]
	public string IpAddress { get; set; } = string.Empty;
	[JsonPropertyName("start")]
	public long Start { get; set; }
	[JsonPropertyName("lastAccess")]
	public long LastAccess { get; set; }
	[JsonPropertyName("clients")]
	public IDictionary<string, string> Clients { get; set; } = new Dictionary<string, string>();
}
