namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ProtocolMapperTypes
{
	[JsonPropertyName("saml")]
	public List<ProtocolMapperType> Saml { get; set; } = [];

	[JsonPropertyName("docker-v2")]
	public List<ProtocolMapperType> DockerV2 { get; set; } = [];

	[JsonPropertyName("openid-connect")]
	public List<ProtocolMapperType> OpenIdConnect { get; set; } = [];
}
