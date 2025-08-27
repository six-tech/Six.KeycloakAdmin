namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "IdentityProviders")]
  [Theory]
  [InlineData("master")]
  public async Task GetIdentityProviderInstancesAsync(string realm)
  {
    var result = await _adminProvider.IdentityProviders.GetIdentityProviderInstancesAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "IdentityProviders")]
  [Theory]
  [InlineData("master")]
  public async Task GetIdentityProviderAsync(string realm)
  {
    var identityProviderInstances = await _adminProvider.IdentityProviders.GetIdentityProviderInstancesAsync(realm);
    var identityProviderAlias = identityProviderInstances.FirstOrDefault()?.Alias;
    if (identityProviderAlias != null)
    {
      var result = await _adminProvider.IdentityProviders.GetIdentityProviderAsync(realm, identityProviderAlias);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "IdentityProviders")]
  [Theory]
  [InlineData("master")]
  public async Task GetIdentityProviderAuthorizationPermissionsInitializedAsync(string realm)
  {
    var identityProviderInstances = await _adminProvider.IdentityProviders.GetIdentityProviderInstancesAsync(realm);
    var identityProviderAlias = identityProviderInstances.FirstOrDefault()?.Alias;
    if (identityProviderAlias != null)
    {
      var result = await _adminProvider.IdentityProviders.GetIdentityProviderAuthorizationPermissionsInitializedAsync(realm, identityProviderAlias);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "IdentityProviders")]
  [Theory]
  [InlineData("master")]
  public async Task GetIdentityProviderMapperTypesAsync(string realm)
  {
    var identityProviderInstances = await _adminProvider.IdentityProviders.GetIdentityProviderInstancesAsync(realm);
    var identityProviderAlias = identityProviderInstances.FirstOrDefault()?.Alias;
    if (identityProviderAlias != null)
    {
      var result = await _adminProvider.IdentityProviders.GetIdentityProviderMapperTypesAsync(realm, identityProviderAlias);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "IdentityProviders")]
  [Theory]
  [InlineData("master")]
  public async Task GetIdentityProviderMappersAsync(string realm)
  {
    var identityProviderInstances = await _adminProvider.IdentityProviders.GetIdentityProviderInstancesAsync(realm);
    var identityProviderAlias = identityProviderInstances.FirstOrDefault()?.Alias;
    if (identityProviderAlias != null)
    {
      var result = await _adminProvider.IdentityProviders.GetIdentityProviderMappersAsync(realm, identityProviderAlias);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "IdentityProviders")]
  [Theory]
  [InlineData("master")]
  public async Task GetIdentityProviderMapperByIdAsync(string realm)
  {
    var identityProviderInstances = await _adminProvider.IdentityProviders.GetIdentityProviderInstancesAsync(realm);
    var identityProviderAlias = identityProviderInstances.FirstOrDefault()?.Alias;
    if (identityProviderAlias != null)
    {
      var mappers = await _adminProvider.IdentityProviders.GetIdentityProviderMappersAsync(realm, identityProviderAlias);
      var mapperId = mappers.FirstOrDefault()?.Id;
      if (mapperId != null)
      {
        var result = await _adminProvider.IdentityProviders.GetIdentityProviderMapperByIdAsync(realm, identityProviderAlias, mapperId);
        Assert.NotNull(result);
      }
    }
  }

  [Trait("Category", "IdentityProviders")]
  [Theory]
  [InlineData("master")]
  public async Task GetIdentityProviderByProviderIdAsync(string realm)
  {
    var identityProviderInstances = await _adminProvider.IdentityProviders.GetIdentityProviderInstancesAsync(realm);
    var identityProviderId = identityProviderInstances.FirstOrDefault()?.ProviderId;
    if (identityProviderId != null)
    {
      var result = await _adminProvider.IdentityProviders.GetIdentityProviderByProviderIdAsync(realm, identityProviderId);
      Assert.NotNull(result);
    }
  }
}
