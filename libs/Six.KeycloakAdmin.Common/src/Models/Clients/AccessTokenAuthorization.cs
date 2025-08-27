namespace Six.KeycloakAdmin.Models.Clients;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AccessTokenAuthorization
{
	[JsonPropertyName("permissions")]
	public IEnumerable<Permission> Permissions { get; set; } = [];
}
