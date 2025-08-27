namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Timer
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

 [JsonPropertyName("providers")] public TimerProviders Providers { get; set; } = new();
}
