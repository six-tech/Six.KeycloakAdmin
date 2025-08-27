namespace Six.KeycloakAdmin.Models.Clients;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AccessTokenAccess
{
	[JsonPropertyName("roles")]
	public IEnumerable<string> Roles { get; set; } = [];
	[JsonPropertyName("verify_caller")]
	public bool? VerifyCaller { get; set; }
}
