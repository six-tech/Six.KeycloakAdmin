namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "ScopeMappings")]
  [Theory]
  [InlineData("master")]
  public async Task GetScopeMappingsAsync(string realm)
  {
    var clientScopes = await _adminProvider.ClientScopes.GetClientScopesAsync(realm);
    var clientScopeId = clientScopes.FirstOrDefault()?.Id;
    if(clientScopeId != null)
    {
      var result = await _adminProvider.ScopeMappings.GetScopeMappingsAsync(realm, clientScopeId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "ScopeMappings")]
  [Theory]
  [InlineData("master")]
  public async Task GetClientRolesForClientScopeAsync(string realm)
  {
    var clientScopes = await _adminProvider.ClientScopes.GetClientScopesAsync(realm);
    var clientScopeId = clientScopes.FirstOrDefault()?.Id;
    if(clientScopeId != null)
    {
      var clients = await _adminProvider.Clients.GetClientsAsync(realm);
      var clientId = clients.FirstOrDefault()?.Id;
      if(clientId != null)
      {
        var result = await _adminProvider.ScopeMappings.GetClientRolesForClientScopeAsync(realm, clientScopeId, clientId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "ScopeMappings")]
  [Theory]
  [InlineData("master")]
  public async Task GetAvailableClientRolesForClientScopeAsync(string realm)
  {
    var clientScopes = await _adminProvider.ClientScopes.GetClientScopesAsync(realm);
    var clientScopeId = clientScopes.FirstOrDefault()?.Id;
    if(clientScopeId != null)
    {
      var clients = await _adminProvider.Clients.GetClientsAsync(realm);
      var clientId = clients.FirstOrDefault()?.Id;
      if(clientId != null)
      {
        var result =
          await _adminProvider.ScopeMappings.GetAvailableClientRolesForClientScopeAsync(realm, clientScopeId, clientId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "ScopeMappings")]
  [Theory]
  [InlineData("master")]
  public async Task GetEffectiveClientRolesForClientScopeAsync(string realm)
  {
    var clientScopes = await _adminProvider.ClientScopes.GetClientScopesAsync(realm);
    var clientScopeId = clientScopes.FirstOrDefault()?.Id;
    if(clientScopeId != null)
    {
      var clients = await _adminProvider.Clients.GetClientsAsync(realm);
      var clientId = clients.FirstOrDefault()?.Id;
      if(clientId != null)
      {
        var result =
          await _adminProvider.ScopeMappings.GetEffectiveClientRolesForClientScopeAsync(realm, clientScopeId, clientId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "ScopeMappings")]
  [Theory]
  [InlineData("master")]
  public async Task GetRealmRolesForClientScopeAsync(string realm)
  {
    var clientScopes = await _adminProvider.ClientScopes.GetClientScopesAsync(realm);
    var clientScopeId = clientScopes.FirstOrDefault()?.Id;
    if(clientScopeId != null)
    {
      var result = await _adminProvider.ScopeMappings.GetRealmRolesForClientScopeAsync(realm, clientScopeId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "ScopeMappings")]
  [Theory]
  [InlineData("master")]
  public async Task GetAvailableRealmRolesForClientScopeAsync(string realm)
  {
    var clientScopes = await _adminProvider.ClientScopes.GetClientScopesAsync(realm);
    var clientScopeId = clientScopes.FirstOrDefault()?.Id;
    if(clientScopeId != null)
    {
      var result = await _adminProvider.ScopeMappings.GetAvailableRealmRolesForClientScopeAsync(realm, clientScopeId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "ScopeMappings")]
  [Theory]
  [InlineData("master")]
  public async Task GetEffectiveRealmRolesForClientScopeAsync(string realm)
  {
    var clientScopes = await _adminProvider.ClientScopes.GetClientScopesAsync(realm);
    var clientScopeId = clientScopes.FirstOrDefault()?.Id;
    if(clientScopeId != null)
    {
      var result = await _adminProvider.ScopeMappings.GetEffectiveRealmRolesForClientScopeAsync(realm, clientScopeId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "ScopeMappings")]
  [Theory]
  [InlineData("master")]
  public async Task GetScopeMappingsForClientAsync(string realm)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientId = clients.FirstOrDefault()?.Id;
    if(clientId != null)
    {
      var result = await _adminProvider.ScopeMappings.GetScopeMappingsForClientAsync(realm, clientId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "ScopeMappings")]
  [Theory]
  [InlineData("master")]
  public async Task GetClientRolesScopeMappingsForClientAsync(string realm)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientId = clients.FirstOrDefault()?.Id;
    if(clientId != null)
    {
      var result = await _adminProvider.ScopeMappings.GetClientRolesScopeMappingsForClientAsync(realm, clientId, clientId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "ScopeMappings")]
  [Theory]
  [InlineData("master")]
  public async Task GetAvailableClientRolesForClientScopeForClientAsync(string realm)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientId = clients.FirstOrDefault()?.Id;
    if(clientId != null)
    {
      var result =
        await _adminProvider.ScopeMappings.GetAvailableClientRolesForClientScopeForClientAsync(realm, clientId, clientId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "ScopeMappings")]
  [Theory]
  [InlineData("master")]
  public async Task GetEffectiveClientRolesForClientScopeForClientAsync(string realm)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientId = clients.FirstOrDefault()?.Id;
    if(clientId != null)
    {
      var result =
        await _adminProvider.ScopeMappings.GetEffectiveClientRolesForClientScopeForClientAsync(realm, clientId, clientId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "ScopeMappings")]
  [Theory]
  [InlineData("master")]
  public async Task GetRealmRolesScopeMappingsForClientAsync(string realm)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientId = clients.FirstOrDefault()?.Id;
    if(clientId != null)
    {
      var result = await _adminProvider.ScopeMappings.GetRealmRolesScopeMappingsForClientAsync(realm, clientId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "ScopeMappings")]
  [Theory]
  [InlineData("master")]
  public async Task GetAvailableRealmRolesForClientScopeForClientAsync(string realm)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientId = clients.FirstOrDefault()?.Id;
    if(clientId != null)
    {
      var result = await _adminProvider.ScopeMappings.GetAvailableRealmRolesForClientScopeForClientAsync(realm, clientId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "ScopeMappings")]
  [Theory]
  [InlineData("master")]
  public async Task GetEffectiveRealmRolesForClientScopeForClientAsync(string realm)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientId = clients.FirstOrDefault()?.Id;
    if(clientId != null)
    {
      var result = await _adminProvider.ScopeMappings.GetEffectiveRealmRolesForClientScopeForClientAsync(realm, clientId);
      Assert.NotNull(result);
    }
  }
}
