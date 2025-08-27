namespace Six.KeycloakAdmin.TokenProvider;

[ExcludeFromCodeCoverage]
internal sealed record AdminTokenResponse
{
  [JsonPropertyName("access_token")] public string AccessToken { get; init; } = string.Empty;

  [JsonPropertyName("expires_in")] public int ExpiresIn { get; init; }

  [JsonPropertyName("token_type")] public string TokenType { get; init; } = string.Empty;
  
  [JsonPropertyName("refresh_token")] public string? RefreshToken { get; init; }
  
  [JsonPropertyName("refresh_expires_in")] public int RefreshExpiresIn { get; init; }
}