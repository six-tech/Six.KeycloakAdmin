namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "ClientScopes")]
  [Theory]
  [InlineData("master")]
  public async Task GetClientScopesAsync(string realm)
  {
    var result = await _adminProvider.ClientScopes.GetClientScopesAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "ClientScopes")]
  [Theory]
  [InlineData("master")]
  public async Task GetClientScopeAsync(string realm)
  {
    var clientScopes = await _adminProvider.ClientScopes.GetClientScopesAsync(realm);
    var clientScopeId = clientScopes.FirstOrDefault()?.Id;
    if(clientScopeId != null)
    {
      var result = await _adminProvider.ClientScopes.GetClientScopeAsync(realm, clientScopeId);
      Assert.NotNull(result);
    }
  }
}
