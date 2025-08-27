namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record JtaLookupProviders
{
	[JsonPropertyName("jboss")]
	public HasOrder Jboss { get; set; } = new();
}
