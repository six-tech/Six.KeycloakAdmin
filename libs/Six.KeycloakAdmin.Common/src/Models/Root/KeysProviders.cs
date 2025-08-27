namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record KeysProviders
{
	[JsonPropertyName("rsa")]
	public HasOrder Rsa { get; set; } = new();

	[JsonPropertyName("java-keystore")]
	public HasOrder JavaKeystore { get; set; } = new();

	[JsonPropertyName("rsa-generated")]
	public HasOrder RsaGenerated { get; set; } = new();

	[JsonPropertyName("aes-generated")]
	public HasOrder AesGenerated { get; set; } = new();

	[JsonPropertyName("ecdsa-generated")]
	public HasOrder EcdsaGenerated { get; set; } = new();

	[JsonPropertyName("hmac-generated")]
	public HasOrder HmacGenerated { get; set; } = new();
}
