namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ScriptingProviders
{
	[JsonPropertyName("script-based-auth")]
	public HasOrder ScriptBasedAuth { get; set; } = new();
}
