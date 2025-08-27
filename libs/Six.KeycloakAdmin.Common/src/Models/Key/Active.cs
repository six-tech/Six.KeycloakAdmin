namespace Six.KeycloakAdmin.Models.Key;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Active
{
	[JsonPropertyName("HS256")]
	public string Hs256 { get; set; } = string.Empty;
	[JsonPropertyName("RS256")]
	public string Rs256 { get; set; } = string.Empty;
	[JsonPropertyName("AES")]
	public string Aes { get; set; } = string.Empty;
}
