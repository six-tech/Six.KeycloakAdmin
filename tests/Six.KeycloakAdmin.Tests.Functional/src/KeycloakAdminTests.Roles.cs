namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetRolesForClientAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var result = await _adminProvider.Roles.GetRolesAsync(realm, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetRoleByNameForClientAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var roles = await _adminProvider.Roles.GetRolesAsync(realm, clientsId);
      var roleName = roles.FirstOrDefault()?.Name;
      if(roleName != null)
      {
        var result = await _adminProvider.Roles.GetRoleByNameAsync(realm, clientsId, roleName);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetRoleCompositesForClientAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var roles = await _adminProvider.Roles.GetRolesAsync(realm, clientsId);
      var roleName = roles.FirstOrDefault()?.Name;
      if(roleName != null)
      {
        var result = await _adminProvider.Roles.GetRoleCompositesAsync(realm, clientsId, roleName);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetApplicationRolesForCompositeForClientAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var roles = await _adminProvider.Roles.GetRolesAsync(realm, clientsId);
      var roleName = roles.FirstOrDefault()?.Name;
      if(roleName != null)
      {
        var result = await _adminProvider.Roles.GetApplicationRolesForCompositeAsync(realm, clientsId, roleName, clientsId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetRealmRolesForCompositeForClientAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var roles = await _adminProvider.Roles.GetRolesAsync(realm, clientsId);
      var roleName = roles.FirstOrDefault()?.Name;
      if(roleName != null)
      {
        var result = await _adminProvider.Roles.GetRealmRolesForCompositeAsync(realm, clientsId, roleName);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetGroupsWithRoleNameForClientAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var roles = await _adminProvider.Roles.GetRolesAsync(realm, clientsId);
      var roleName = roles.FirstOrDefault()?.Name;
      if(roleName != null)
      {
#pragma warning disable CS0618 // Type or member is obsolete
        var result = await _adminProvider.Roles.GetGroupsWithRoleNameAsync(realm, clientsId, roleName);
#pragma warning restore CS0618 // Type or member is obsolete
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetRoleAuthorizationPermissionsInitializedForClientAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var roles = await _adminProvider.Roles.GetRolesAsync(realm, clientsId);
      var roleName = roles.FirstOrDefault()?.Name;
      if(roleName != null)
      {
        var result = await _adminProvider.Roles.GetRoleAuthorizationPermissionsInitializedAsync(realm, clientsId, roleName);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetUsersWithRoleNameForClientAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var roles = await _adminProvider.Roles.GetRolesAsync(realm, clientsId);
      var roleName = roles.FirstOrDefault()?.Name;
      if(roleName != null)
      {
        var result = await _adminProvider.Roles.GetUsersWithRoleNameAsync(realm, clientsId, roleName);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("master")]
  public async Task GetRolesForRealmAsync(string realm)
  {
    var result = await _adminProvider.Roles.GetRolesAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("master")]
  public async Task GetRoleByNameForRealmAsync(string realm)
  {
    var roles = await _adminProvider.Roles.GetRolesAsync(realm);
    var roleName = roles.FirstOrDefault()?.Name;
    if(roleName != null)
    {
      var result = await _adminProvider.Roles.GetRoleByNameAsync(realm, roleName);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("master")]
  public async Task GetRoleCompositesForRealmAsync(string realm)
  {
    var roles = await _adminProvider.Roles.GetRolesAsync(realm);
    var roleName = roles.FirstOrDefault()?.Name;
    if(roleName != null)
    {
      var result = await _adminProvider.Roles.GetRoleCompositesAsync(realm, roleName);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetApplicationRolesForCompositeForRealmAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var roles = await _adminProvider.Roles.GetRolesAsync(realm);
      var roleName = roles.FirstOrDefault()?.Name;
      if(roleName != null)
      {
        var result = await _adminProvider.Roles.GetApplicationRolesForCompositeAsync(realm, roleName, clientsId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("master")]
  public async Task GetRealmRolesForCompositeForRealmAsync(string realm)
  {
    var roles = await _adminProvider.Roles.GetRolesAsync(realm);
    var roleName = roles.FirstOrDefault()?.Name;
    if(roleName != null)
    {
      var result = await _adminProvider.Roles.GetRealmRolesForCompositeAsync(realm, roleName);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("master")]
  public async Task GetGroupsWithRoleNameForRealmAsync(string realm)
  {
    var roles = await _adminProvider.Roles.GetRolesAsync(realm);
    var roleName = roles.FirstOrDefault()?.Name;
    if(roleName != null)
    {
#pragma warning disable CS0618 // Type or member is obsolete
      var result = await _adminProvider.Roles.GetGroupsWithRoleNameAsync(realm, roleName);
#pragma warning restore CS0618 // Type or member is obsolete
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Roles")]
  [Theory(Skip = "Requires Keycloak authorization services to be enabled")]
  [InlineData("master")]
  public async Task GetRoleAuthorizationPermissionsInitializedForRealmAsync(string realm)
  {
    var roles = await _adminProvider.Roles.GetRolesAsync(realm);
    var roleName = roles.FirstOrDefault()?.Name;
    if(roleName != null)
    {
      var result = await _adminProvider.Roles.GetRoleAuthorizationPermissionsInitializedAsync(realm, roleName);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Roles")]
  [Theory]
  [InlineData("master")]
  public async Task GetUsersWithRoleNameForRealmAsync(string realm)
  {
    var roles = await _adminProvider.Roles.GetRolesAsync(realm);
    var roleName = roles.FirstOrDefault()?.Name;
    if(roleName != null)
    {
      var result = await _adminProvider.Roles.GetUsersWithRoleNameAsync(realm, roleName);
      Assert.NotNull(result);
    }
  }
}
