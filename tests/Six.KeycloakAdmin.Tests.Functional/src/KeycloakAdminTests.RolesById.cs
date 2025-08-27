namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "RolesById")]
  [Theory]
  [InlineData("master")]
  public async Task GetRoleByIdAsync(string realm)
  {
    var roles = await _adminProvider.Roles.GetRolesAsync(realm);
    var roleId = roles.FirstOrDefault()?.Id;
    if(roleId != null)
    {
      var result = await _adminProvider.RolesById.GetRoleByIdAsync(realm, roleId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "RolesById")]
  [Theory]
  [InlineData("master")]
  public async Task GetRoleChildrenAsync(string realm)
  {
    var roles = await _adminProvider.Roles.GetRolesAsync(realm);
    var roleId = roles.FirstOrDefault()?.Id;
    if(roleId != null)
    {
      var result = await _adminProvider.RolesById.GetRoleChildrenAsync(realm, roleId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "RolesById")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetClientRolesForCompositeByIdAsync(string realm, string clientId)
  {
    var roles = await _adminProvider.Roles.GetRolesAsync(realm);
    var roleId = roles.FirstOrDefault()?.Id;
    if(roleId != null)
    {
      var clients = await _adminProvider.Clients.GetClientsAsync(realm);
      var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
      if(clientsId != null)
      {
        var result = await _adminProvider.RolesById.GetClientRolesForCompositeByIdAsync(realm, roleId, clientsId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "RolesById")]
  [Theory]
  [InlineData("master")]
  public async Task GetRealmRolesForCompositeByIdAsync(string realm)
  {
    var roles = await _adminProvider.Roles.GetRolesAsync(realm);
    var roleId = roles.FirstOrDefault()?.Id;
    if(roleId != null)
    {
      var result = await _adminProvider.RolesById.GetRealmRolesForCompositeByIdAsync(realm, roleId);
      Assert.NotNull(result);
    }
  }
  
  [Trait("Category", "RolesById")]
  [Theory(Skip = "Requires Keycloak authorization services to be enabled")]
  [InlineData("master")]
  public async Task GetRoleByIdAuthorizationPermissionsInitializedAsync(string realm)
  {
    var roles = await _adminProvider.Roles.GetRolesAsync(realm);
    var roleId = roles.FirstOrDefault()?.Id;
    if(roleId != null)
    {
      var result = await _adminProvider.RolesById.GetRoleByIdAuthorizationPermissionsInitializedAsync(realm, roleId);
      Assert.NotNull(result);
    }
  }
}
