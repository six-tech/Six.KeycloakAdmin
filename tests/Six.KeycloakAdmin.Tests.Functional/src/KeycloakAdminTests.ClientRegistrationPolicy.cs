namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "ClientRegistrationPolicy")]
  [Theory]
  [InlineData("master")]
  public async Task GetRetrieveProvidersBasePathAsync(string realm)
  {
    var result = await _adminProvider.ClientRegistrationPolicy.GetRetrieveProvidersBasePathAsync(realm);
    Assert.NotNull(result);
  }
}
