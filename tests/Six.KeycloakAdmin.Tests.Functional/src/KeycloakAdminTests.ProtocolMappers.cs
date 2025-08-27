namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "ProtocolMappers")]
  [Theory]
  [InlineData("master")]
  public async Task GetProtocolMappersAsync(string realm)
  {
    var clientScopes = await _adminProvider.ClientScopes.GetClientScopesAsync(realm);

    var clientScopeId = clientScopes.FirstOrDefault(x => x.ProtocolMappers.Any())?.Id;

    if(clientScopeId != null)
    {
      var result = await _adminProvider.ProtocolMappers.GetProtocolMappersAsync(realm, clientScopeId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "ProtocolMappers")]
  [Theory]
  [InlineData("master")]
  public async Task GetProtocolMapperAsync(string realm)
  {
    var clientScopes = await _adminProvider.ClientScopes.GetClientScopesAsync(realm);
    var clientScopeId = clientScopes.FirstOrDefault(x => x.ProtocolMappers.Any())?.Id;
    if(clientScopeId != null)
    {
      var protocolMappers = await _adminProvider.ProtocolMappers.GetProtocolMappersAsync(realm, clientScopeId);
      var protocolMapperId = protocolMappers.FirstOrDefault()?.Id;
      if(protocolMapperId != null)
      {
        var result = await _adminProvider.ProtocolMappers.GetProtocolMapperAsync(realm, clientScopeId, protocolMapperId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "ProtocolMappers")]
  [Theory]
  [InlineData("master")]
  public async Task GetProtocolMappersByNameAsync(string realm)
  {
    var clientScopes = await _adminProvider.ClientScopes.GetClientScopesAsync(realm);
    var clientScopeId = clientScopes.FirstOrDefault(x => x.ProtocolMappers.Any())?.Id;
    if(clientScopeId != null)
    {
      var protocolMappers = await _adminProvider.ProtocolMappers.GetProtocolMappersAsync(realm, clientScopeId);
      var protocol = protocolMappers.FirstOrDefault()?.Name;
      if(protocol != null)
      {
        var result = await _adminProvider.ProtocolMappers.GetProtocolMappersByNameAsync(realm, clientScopeId, protocol);
        Assert.NotNull(result);
      }
    }
  }
}
