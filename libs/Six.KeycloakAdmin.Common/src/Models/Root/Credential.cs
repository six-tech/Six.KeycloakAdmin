namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Credential
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public CredentialProviders Providers { get; set; } = new();
}
