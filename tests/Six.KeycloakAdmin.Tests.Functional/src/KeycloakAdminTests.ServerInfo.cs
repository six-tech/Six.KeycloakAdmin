namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "ServerInfo")]
  [Theory]
  [InlineData("master")]
  public async Task GetServerInfoAsync(string realm)
  {
    var result = await _adminProvider.ServerInfo.GetServerInfoAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "ServerInfo")]
  [Theory]
  [InlineData("master")]
  public async Task CorsPreflightAsync(string realm)
  {
    bool? result = await _adminProvider.ServerInfo.CorsPreflightAsync(realm);
    Assert.True(result);
  }
}
