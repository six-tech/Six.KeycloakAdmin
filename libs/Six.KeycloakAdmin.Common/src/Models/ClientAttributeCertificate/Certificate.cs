namespace Six.KeycloakAdmin.Models.ClientAttributeCertificate;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Certificate
{
	[JsonPropertyName("certificate")]
	// ReSharper disable once InconsistentNaming
	public string _Certificate { get; set; } = string.Empty;
	[JsonPropertyName("kid")]
	public string Kid { get; set; } = string.Empty;
	[JsonPropertyName("privateKey")]
	public string PrivateKey { get; set; } = string.Empty;
	[JsonPropertyName("publicKey")]
	public string PublicKey { get; set; } = string.Empty;
}
