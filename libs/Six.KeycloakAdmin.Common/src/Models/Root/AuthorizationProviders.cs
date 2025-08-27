namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthorizationProviders
{
	[JsonPropertyName("authorization")]
	public HasOrder Authorization { get; set; } = new();
}
