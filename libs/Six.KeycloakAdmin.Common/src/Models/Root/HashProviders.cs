namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record HashProviders
{
	[JsonPropertyName("SHA-384")]
	public HasOrder Sha384 { get; set; } = new ();

	[JsonPropertyName("SHA-256")]
	public HasOrder Sha256 { get; set; } = new ();

	[JsonPropertyName("SHA-512")]
	public HasOrder Sha512 { get; set; } = new ();
}
