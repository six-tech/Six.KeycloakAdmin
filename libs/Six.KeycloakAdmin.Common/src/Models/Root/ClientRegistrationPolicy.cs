namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ClientRegistrationPolicy
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public ClientRegistrationPolicyProviders Providers { get; set; } = new();
}
