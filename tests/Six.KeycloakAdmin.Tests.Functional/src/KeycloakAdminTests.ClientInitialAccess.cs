namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "ClientInitialAccess")]
  [Theory]
  [InlineData("master")]
  public async Task GetClientInitialAccessAsync(string realm)
  {
    var result = await _adminProvider.ClientInitialAccess.GetClientInitialAccessAsync(realm);
    Assert.NotNull(result);
  }
}
