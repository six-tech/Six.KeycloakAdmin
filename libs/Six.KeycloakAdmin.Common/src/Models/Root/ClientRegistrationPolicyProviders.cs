namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ClientRegistrationPolicyProviders
{
	[JsonPropertyName("allowed-client-templates")]
	public HasOrder AllowedClientTemplates { get; set; } = new();

	[JsonPropertyName("client-disabled")]
	public HasOrder ClientDisabled { get; set; } = new();

	[JsonPropertyName("max-clients")]
	public HasOrder MaxClients { get; set; } = new();

	[JsonPropertyName("scope")]
	public HasOrder Scope { get; set; } = new();

	[JsonPropertyName("allowed-protocol-mappers")]
	public HasOrder AllowedProtocolMappers { get; set; } = new();

	[JsonPropertyName("trusted-hosts")]
	public HasOrder TrustedHosts { get; set; } = new();

	[JsonPropertyName("consent-required")]
	public HasOrder ConsentRequired { get; set; } = new();
}
