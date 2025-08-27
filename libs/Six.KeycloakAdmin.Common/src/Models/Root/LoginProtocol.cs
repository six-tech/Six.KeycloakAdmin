namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record LoginProtocol
{
  [JsonPropertyName("internal")] public bool? Internal { get; set; }

  [JsonPropertyName("providers")] public LoginProtocolProviders Providers { get; set; } = new();
}
