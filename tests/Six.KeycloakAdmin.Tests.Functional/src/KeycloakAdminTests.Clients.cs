#pragma warning disable CS0618 // Type or member is obsolete
namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("master")]
  public async Task GetClientsAsync(string realm)
  {
    var result = await _adminProvider.Clients.GetClientsAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetClientAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    
    if(clientsId is not null)
    {
      var result = await _adminProvider.Clients.GetClientAsync(realm, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GenerateClientSecretAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var result = await _adminProvider.Clients.GenerateClientSecretAsync(realm, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetClientSecretAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var result = await _adminProvider.Clients.GetClientSecretAsync(realm, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetDefaultClientScopesAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var result = await _adminProvider.Clients.GetDefaultClientScopesAsync(realm, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory(Skip = "Not working yet")]
  [InlineData("Insurance", "insurance-product")]
  public async Task GenerateClientExampleAccessTokenAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;

    if(clientsId != null && realm != "null")
    {
      var result = await _adminProvider.Clients.GenerateClientExampleAccessTokenAsync(realm, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetProtocolMappersInTokenGenerationAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var result = await _adminProvider.Clients.GetProtocolMappersInTokenGenerationAsync(realm, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetClientGrantedScopeMappingsAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var result = await _adminProvider.Clients.GetClientGrantedScopeMappingsAsync(realm, clientsId, realm);
      Assert.NotNull(result);
      result = await _adminProvider.Clients.GetClientGrantedScopeMappingsAsync(realm, clientsId, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetClientNotGrantedScopeMappingsAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var result = await _adminProvider.Clients.GetClientNotGrantedScopeMappingsAsync(realm, clientsId, realm);
      Assert.NotNull(result);
      result = await _adminProvider.Clients.GetClientNotGrantedScopeMappingsAsync(realm, clientsId, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetClientProviderAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var providerInstances = await _adminProvider.IdentityProviders.GetIdentityProviderInstancesAsync(realm);
      var providerInstanceId = providerInstances.FirstOrDefault()?.ProviderId;
      if(providerInstanceId != null)
      {
        string result = await _adminProvider.Clients.GetClientProviderAsync(realm, clientsId, providerInstanceId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "Clients")]
  [Theory(Skip = "Requires Keycloak authorization services to be enabled")]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetClientAuthorizationPermissionsInitializedAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var result = await _adminProvider.Clients.GetClientAuthorizationPermissionsInitializedAsync(realm, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetClientOfflineSessionCountAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      int? result = await _adminProvider.Clients.GetClientOfflineSessionCountAsync(realm, clientsId);
      Assert.True(result >= 0);
    }
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetClientOfflineSessionsAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var result = await _adminProvider.Clients.GetClientOfflineSessionsAsync(realm, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetOptionalClientScopesAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var result = await _adminProvider.Clients.GetOptionalClientScopesAsync(realm, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GenerateClientRegistrationAccessTokenAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var result = await _adminProvider.Clients.GenerateClientRegistrationAccessTokenAsync(realm, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory()]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetUserForServiceAccountAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var result = await _adminProvider.Clients.GetUserForServiceAccountAsync(realm, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetClientSessionCountAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      int? result = await _adminProvider.Clients.GetClientSessionCountAsync(realm, clientsId);
      Assert.True(result >= 0);
    }
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task TestClientClusterNodesAvailableAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var result = await _adminProvider.Clients.TestClientClusterNodesAvailableAsync(realm, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetClientUserSessionsAsync(string realm, string clientId)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    var clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
    if(clientsId != null)
    {
      var result = await _adminProvider.Clients.GetClientUserSessionsAsync(realm, clientsId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Clients")]
  [Theory(Skip = "Pending to figure out test configuration")]
  [InlineData("Insurance", "insurance-product")]
  public async Task GetResourcesOwnedByClientAsync(string realm, string clientId)
  {
    var result = await _adminProvider.Clients.GetResourcesOwnedByClientAsync(realm, clientId);
    Assert.NotNull(result);
  }
}
