namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record OpenIdConnect
{
  [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;

  [JsonPropertyName("protocol")] public Protocol Protocol { get; set; }

  [JsonPropertyName("protocolMapper")] public string ProtocolMapper { get; set; } = string.Empty;

  [JsonPropertyName("consentRequired")] public bool? ConsentRequired { get; set; }

  [JsonPropertyName("config")] public OpenIdConnectConfig Config { get; set; } = new();
}
