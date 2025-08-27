namespace Six.KeycloakAdmin.Models.Users;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record FederatedIdentity
{
	[JsonPropertyName("identityProvider")]
	public string IdentityProvider { get; set; } = string.Empty;
	[JsonPropertyName("userId")]
	public string UserId { get; set; } = string.Empty;
	[JsonPropertyName("userName")]
	public string UserName { get; set; } = string.Empty;
}
