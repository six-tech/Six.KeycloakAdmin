namespace Six.KeycloakAdmin.Models.Clients;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AccessTokenCertConf
{
	[JsonPropertyName("x5t#S256")]
	public string X5Ts256 { get; set; } = string.Empty;
}
