namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record KeycloakStorageUserStorageProviderMetadata
{
	[JsonPropertyName("synchronizable")]
	public bool? Synchronizable { get; set; }
}
