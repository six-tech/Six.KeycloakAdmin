namespace Six.KeycloakAdmin.Models.IdentityProviders;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record IdentityProviderToken
{
	[JsonPropertyName("access_token")]
	public string AccessToken { get; set; } = string.Empty;

	[JsonPropertyName("token_type")]
	public string RequestingPartyToken { get; set; } = string.Empty;

	[JsonPropertyName("expires_in")]
	public int ExpiresIn { get; set; }

	[JsonPropertyName("refresh_token")]
	public string RefreshToken { get; set; } = string.Empty;

	[JsonPropertyName("scope")]
	public string Scope { get; set; } = string.Empty;

	[JsonPropertyName("created_at")]
	public long CreatedAt { get; set; }
}
