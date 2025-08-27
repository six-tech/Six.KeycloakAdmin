namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "ClientAttributeCertificate")]
  [Theory]
  [InlineData("master")]
  public async Task GetKeyInfoAsync(string realm)
  {
    var clients = await _adminProvider.Clients.GetClientsAsync(realm);
    (string clientId, string attribute) = clients
      .Where(x => x.Attributes.Any())
      .Select(client => (client.Id, client.Attributes.FirstOrDefault().Key))
      .FirstOrDefault();

    if(clientId != null)
    {
      var result = await _adminProvider.ClientAttributeCertificate.GetKeyInfoAsync(realm, clientId, attribute);
      Assert.NotNull(result);
    }
  }
}
