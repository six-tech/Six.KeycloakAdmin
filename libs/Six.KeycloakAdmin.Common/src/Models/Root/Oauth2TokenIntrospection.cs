namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Oauth2TokenIntrospection
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public Oauth2TokenIntrospectionProviders Providers { get; set; } = new ();
}
