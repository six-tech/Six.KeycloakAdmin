namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record EventsListenerProviders
{
  [JsonPropertyName("jboss-logging")] public HasOrder JbossLogging { get; set; } = new ();

	[JsonPropertyName("email")]
	public HasOrder Email { get; set; } = new ();
}
