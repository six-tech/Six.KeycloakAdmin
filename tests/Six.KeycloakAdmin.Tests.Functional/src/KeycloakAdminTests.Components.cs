namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "Components")]
  [Theory]
  [InlineData("master")]
  public async Task GetComponentsAsync(string realm)
  {
    var result = await _adminProvider.Components.GetComponentsAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "Components")]
  [Theory]
  [InlineData("master")]
  public async Task GetComponentAsync(string realm)
  {
    var components = await _adminProvider.Components.GetComponentsAsync(realm);
    var componentId = components.FirstOrDefault()?.Id;
    if(componentId != null)
    {
      var result = await _adminProvider.Components.GetComponentAsync(realm, componentId);
      Assert.NotNull(result);
    }
  }
}
