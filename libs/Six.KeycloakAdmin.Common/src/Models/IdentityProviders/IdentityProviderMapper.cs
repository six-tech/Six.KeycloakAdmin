namespace Six.KeycloakAdmin.Models.IdentityProviders;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record IdentityProviderMapper
{
  [JsonPropertyName("config")]
  public IDictionary<string, object> Config { get; set; } = new Dictionary<string, object>();

  [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;

  [JsonPropertyName("identityProviderAlias")]
  public string IdentityProviderAlias { get; set; } = string.Empty;

  [JsonPropertyName("identityProviderMapper")]
  // ReSharper disable once InconsistentNaming
  public string _IdentityProviderMapper { get; set; } = string.Empty;

  [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
}
