namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "RealmsAdmin")]
  [Theory]
  [InlineData("master")]
  public async Task GetRealmsAsync(string realm)
  {
    var result = await _adminProvider.Realms.GetRealmsAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "RealmsAdmin")]
  [Theory]
  [InlineData("master")]
  public async Task GetRealmAsync(string realm)
  {
    var result = await _adminProvider.Realms.GetRealmAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "RealmsAdmin")]
  [Theory]
  [InlineData("master")]
  public async Task GetAdminEventsAsync(string realm)
  {
    var result = await _adminProvider.Realms.GetAdminEventsAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "RealmsAdmin")]
  [Theory]
  [InlineData("master")]
  public async Task GetClientSessionStatsAsync(string realm)
  {
    var result = await _adminProvider.Realms.GetClientSessionStatsAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "RealmsAdmin")]
  [Theory]
  [InlineData("master")]
  public async Task GetRealmDefaultClientScopesAsync(string realm)
  {
    var result = await _adminProvider.Realms.GetRealmDefaultClientScopesAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "RealmsAdmin")]
  [Theory]
  [InlineData("master")]
  public async Task GetRealmGroupHierarchyAsync(string realm)
  {
    var result = await _adminProvider.Realms.GetRealmGroupHierarchyAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "RealmsAdmin")]
  [Theory]
  [InlineData("master")]
  public async Task GetRealmOptionalClientScopesAsync(string realm)
  {
    var result = await _adminProvider.Realms.GetRealmOptionalClientScopesAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "RealmsAdmin")]
  [Theory]
  [InlineData("master")]
  public async Task GetEventsAsync(string realm)
  {
    var result = await _adminProvider.Realms.GetEventsAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "RealmsAdmin")]
  [Theory]
  [InlineData("master")]
  public async Task GetRealmEventsProviderConfigurationAsync(string realm)
  {
    var result = await _adminProvider.Realms.GetRealmEventsProviderConfigurationAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "RealmsAdmin")]
  [Theory]
  [InlineData("master")]
  public async Task GetRealmGroupByPathAsync(string realm)
  {
    var groups = await _adminProvider.Realms.GetRealmGroupHierarchyAsync(realm);
    var path = groups.FirstOrDefault()?.Path;
    if(path != null)
    {
      var result = await _adminProvider.Realms.GetRealmGroupByPathAsync(realm, path);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "RealmsAdmin")]
  [Theory(Skip = "Requires Keycloak authorization services to be enabled")]
  [InlineData("master")]
  public async Task GetRealmUsersManagementPermissionsAsync(string realm)
  {
    var result = await _adminProvider.Realms.GetRealmUsersManagementPermissionsAsync(realm);
    Assert.NotNull(result);
  }
}
