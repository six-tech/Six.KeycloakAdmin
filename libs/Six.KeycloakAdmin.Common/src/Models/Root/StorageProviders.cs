namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record StorageProviders
{
  [JsonPropertyName("ldap")] public HasOrder Ldap { get; set; } = new();

	[JsonPropertyName("kerberos")]
	public HasOrder Kerberos { get; set; } = new();
}
