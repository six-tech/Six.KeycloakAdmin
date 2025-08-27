namespace Six.KeycloakAdmin.Models.Clients;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ClientScopeEvaluateResourceProtocolMapperEvaluation
{
	[JsonPropertyName("containerId")]
	public string ContainerId { get; set; } = string.Empty;
	[JsonPropertyName("containerName")]
	public string ContainerName { get; set; } = string.Empty;
	[JsonPropertyName("containerType")]
	public string ContainerType { get; set; } = string.Empty;
	[JsonPropertyName("mapperId")]
	public string MapperId { get; set; } = string.Empty;
	[JsonPropertyName("mapperName")]
	public string MapperName { get; set; } = string.Empty;
	[JsonPropertyName("protocolMapper")]
	public string ProtocolMapper { get; set; } = string.Empty;
}
