namespace Six.KeycloakAdmin.Models.ClientAttributeCertificate;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record KeyStoreConfig
{
	[JsonPropertyName("format")]
	public string Format { get; set; } = string.Empty;
	[JsonPropertyName("keyAlias")]
	public string KeyAlias { get; set; } = string.Empty;
	[JsonPropertyName("keyPassword")]
	public string KeyPassword { get; set; } = string.Empty;
	[JsonPropertyName("realmAlias")]
	public string RealmAlias { get; set; } = string.Empty;
	[JsonPropertyName("realmCertificate")]
	public string RealmCertificate { get; set; } = string.Empty;
	[JsonPropertyName("storePassword")]
	public string StorePassword { get; set; } = string.Empty;
}
