namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "Key")]
  [Theory]
  [InlineData("master")]
  public async Task GetKeysAsync(string realm)
  {
    var result = await _adminProvider.Keys.GetKeysAsync(realm);
    Assert.NotNull(result);
  }
}
