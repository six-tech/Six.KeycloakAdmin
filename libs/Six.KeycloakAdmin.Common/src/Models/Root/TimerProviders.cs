namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record TimerProviders
{
	[JsonPropertyName("basic")]
	public HasOrder Basic { get; set; } = new ();
}
