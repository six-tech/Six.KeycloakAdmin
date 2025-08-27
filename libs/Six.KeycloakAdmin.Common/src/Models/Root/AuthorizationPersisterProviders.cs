namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AuthorizationPersisterProviders
{
	[JsonPropertyName("jpa")]
	public HasOrder Jpa { get; set; } = new();
}
