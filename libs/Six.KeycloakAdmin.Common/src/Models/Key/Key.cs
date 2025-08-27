namespace Six.KeycloakAdmin.Models.Key;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Key
{
	[JsonPropertyName("providerId")]
	public string ProviderId { get; set; } = string.Empty;
	[JsonPropertyName("providerPriority")]
	public int? ProviderPriority { get; set; }
	[JsonPropertyName("kid")]
	public string Kid { get; set; } = string.Empty;
	[JsonPropertyName("status")]
	public string Status { get; set; } = string.Empty;
	[JsonPropertyName("type")]
	public string Type { get; set; } = string.Empty;
	[JsonPropertyName("algorithm")]
	public string Algorithm { get; set; } = string.Empty;
	[JsonPropertyName("publicKey")]
	public string PublicKey { get; set; } = string.Empty;
	[JsonPropertyName("certificate")]
	public string Certificate { get; set; } = string.Empty;
}
