namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Oauth2TokenIntrospectionProviders
{
	[JsonPropertyName("access_token")]
	public HasOrder AccessToken { get; set; } = new ();

	[JsonPropertyName("refresh_token")]
	public HasOrder RefreshToken { get; set; } = new ();

	[JsonPropertyName("requesting_party_token")]
	public HasOrder RequestingPartyToken { get; set; } = new ();
}
