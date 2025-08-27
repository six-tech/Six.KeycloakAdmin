namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record EventsListener
{
  [JsonPropertyName("internal")] public bool? Internal { get; set; }

  [JsonPropertyName("providers")] public EventsListenerProviders Providers { get; set; } = new();
}
