namespace Six.KeycloakAdmin.Models.Users;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Credentials
{
  [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
  [JsonPropertyName("algorithm")] public string Algorithm { get; set; } = string.Empty;

  [JsonPropertyName("config")] public IDictionary<string, string> Config { get; set; } = new Dictionary<string, string>();
  [JsonPropertyName("counter")] public int? Counter { get; set; }
  [JsonPropertyName("createdDate")] public long? CreatedDate { get; set; }
  [JsonPropertyName("device")] public string Device { get; set; } = string.Empty;
  [JsonPropertyName("digits")] public int? Digits { get; set; }
  [JsonPropertyName("hashIterations")] public int? HashIterations { get; set; }

  [JsonPropertyName("hashedSaltedValue")]
  public string HashedSaltedValue { get; set; } = string.Empty;

  [JsonPropertyName("period")] public int? Period { get; set; }
  [JsonPropertyName("salt")] public string Salt { get; set; } = string.Empty;
  [JsonPropertyName("temporary")] public bool? Temporary { get; set; }
  [JsonPropertyName("type")] public string Type { get; set; } = string.Empty;
  [JsonPropertyName("value")] public string Value { get; set; } = string.Empty;
}
