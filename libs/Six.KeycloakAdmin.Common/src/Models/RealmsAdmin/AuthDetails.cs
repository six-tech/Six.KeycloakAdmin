namespace Six.KeycloakAdmin.Models.RealmsAdmin;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthDetails
{
	[JsonPropertyName("clientId")]
	public string ClientId { get; set; } = string.Empty;
	[JsonPropertyName("ipAddress")]
	public string IpAddress { get; set; } = string.Empty;
	[JsonPropertyName("realmId")]
	public string RealmId { get; set; } = string.Empty;
	[JsonPropertyName("userId")]
	public string UserId { get; set; } = string.Empty;
}
