namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ClientInstallations
{
	[JsonPropertyName("docker-v2")]
	public List<ClientInstallation> DockerV2 { get; set; } = [];

	[JsonPropertyName("saml")]
	public List<ClientInstallation> Saml { get; set; } = [];

	[JsonPropertyName("openid-connect")]
	public List<ClientInstallation> OpenIdConnect { get; set; } = [];
}
