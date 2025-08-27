namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "ClientRoleMappings")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetClientRoleMappingsForGroupAsync(string realm, string clientId)
  {
    var groups = await _adminProvider.Groups.GetGroupHierarchyAsync(realm);
    var groupId = groups.FirstOrDefault()?.Id;
    if (groupId != null)
    {
      var clients = await _adminProvider.Clients.GetClientsAsync(realm);
      var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
      
      if (clientId != null && clientsId != null)
      {
        var result = await _adminProvider.ClientRoleMappings.GetClientRoleMappingsForGroupAsync(realm, groupId, clientsId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "ClientRoleMappings")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetAvailableClientRoleMappingsForGroupAsync(string realm, string clientId)
  {
    var groups = await _adminProvider.Groups.GetGroupHierarchyAsync(realm);
    var groupId = groups.FirstOrDefault()?.Id;
    if (groupId != null)
    {
      var clients = await _adminProvider.Clients.GetClientsAsync(realm);
      var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
      
      if (clientId != null && clientsId != null)
      {
        var result = await _adminProvider.ClientRoleMappings.GetAvailableClientRoleMappingsForGroupAsync(realm, groupId, clientsId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "ClientRoleMappings")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetEffectiveClientRoleMappingsForGroupAsync(string realm, string clientId)
  {
    var groups = await _adminProvider.Groups.GetGroupHierarchyAsync(realm);
    var groupId = groups.FirstOrDefault()?.Id;
    if (groupId != null)
    {
      var clients = await _adminProvider.Clients.GetClientsAsync(realm);
      var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
      
      if (clientId != null && clientsId != null)
      {
        var result = await _adminProvider.ClientRoleMappings.GetEffectiveClientRoleMappingsForGroupAsync(realm, groupId, clientsId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "ClientRoleMappings")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetClientRoleMappingsForUserAsync(string realm, string clientId)
  {
    var users = await _adminProvider.Users.GetUsersAsync(realm);
    var userId = users.FirstOrDefault()?.Id;
    if (userId != null)
    {
      var clients = await _adminProvider.Clients.GetClientsAsync(realm);
      var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
      
      if (clientId != null && clientsId != null)
      {
        var result = await _adminProvider.ClientRoleMappings.GetClientRoleMappingsForUserAsync(realm, userId, clientsId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "ClientRoleMappings")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetAvailableClientRoleMappingsForUserAsync(string realm, string clientId)
  {
    var users = await _adminProvider.Users.GetUsersAsync(realm);
    var userId = users.FirstOrDefault()?.Id;
    if (userId != null)
    {
      var clients = await _adminProvider.Clients.GetClientsAsync(realm);
      var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
      
      if (clientId != null && clientsId != null)
      {
        var result = await _adminProvider.ClientRoleMappings.GetAvailableClientRoleMappingsForUserAsync(realm, userId, clientsId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "ClientRoleMappings")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetEffectiveClientRoleMappingsForUserAsync(string realm, string clientId)
  {
    var users = await _adminProvider.Users.GetUsersAsync(realm);
    var userId = users.FirstOrDefault()?.Id;
    if (userId != null)
    {
      var clients = await _adminProvider.Clients.GetClientsAsync(realm);
      var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
      
      if (clientId != null && clientsId != null)
      {
        var result = await _adminProvider.ClientRoleMappings.GetEffectiveClientRoleMappingsForUserAsync(realm, userId, clientsId);
        Assert.NotNull(result);
      }
    }
  }
}
