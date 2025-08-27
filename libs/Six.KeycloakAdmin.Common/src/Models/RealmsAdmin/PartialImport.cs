using Six.KeycloakAdmin.Models.Clients;
using Six.KeycloakAdmin.Models.Groups;
using Six.KeycloakAdmin.Models.Users;

namespace Six.KeycloakAdmin.Models.RealmsAdmin;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record PartialImport
{
	public IEnumerable<Client> Clients { get; set; } = [];
	public IEnumerable<Group> Groups { get; set; } = [];
	public IEnumerable<IdentityProvider> IdentityProviders { get; set; } = [];
	public string IfResourceExists { get; set; } = string.Empty;
	public Policies Policy { get; set; } = new();
	public Roles Roles { get; set; } = new();
	public IEnumerable<User> Users { get; set; } = [];
}
