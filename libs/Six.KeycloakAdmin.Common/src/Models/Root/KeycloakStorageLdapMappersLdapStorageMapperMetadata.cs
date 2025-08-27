namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record KeycloakStorageLdapMappersLdapStorageMapperMetadata
{
	[JsonPropertyName("fedToKeycloakSyncSupported")]
	public bool? FedToKeycloakSyncSupported { get; set; }

	[JsonPropertyName("keycloakToFedSyncSupported")]
	public bool? KeycloakToFedSyncSupported { get; set; }

	[JsonPropertyName("fedToKeycloakSyncMessage")]
	public string FedToKeycloakSyncMessage { get; set; } = string.Empty;

	[JsonPropertyName("keycloakToFedSyncMessage")]
	public string KeycloakToFedSyncMessage { get; set; } = string.Empty;
}
