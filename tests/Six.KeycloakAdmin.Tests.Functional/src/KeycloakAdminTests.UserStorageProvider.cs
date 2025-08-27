using Six.KeycloakAdmin.Services;

namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "UserStorageProvider")]
  [Theory(Skip = "Not working yet")]
  [InlineData("master")]
  public async Task TriggerUserSynchronizationAsync(string realm)
  {
    string storageProviderId = "";

#pragma warning disable CS0618 // Type or member is obsolete
    var result = await _adminProvider.UserStorageProvider
      .TriggerUserSynchronizationAsync(realm, storageProviderId, UserSyncActions.Full);
#pragma warning restore CS0618 // Type or member is obsolete

    Assert.NotNull(result);
  }

  [Trait("Category", "UserStorageProvider")]
  [Theory(Skip = "Not working yet")]
  [InlineData("master")]
  public async Task TriggerLdapMapperSynchronizationAsync(string realm)
  {
    string storageProviderId = "";
    string mapperId = "";

#pragma warning disable CS0618 // Type or member is obsolete
    var result = await _adminProvider.UserStorageProvider
      .TriggerLdapMapperSynchronizationAsync(realm, storageProviderId, mapperId, LdapMapperSyncActions.KeycloakToFed);
#pragma warning restore CS0618 // Type or member is obsolete

    Assert.NotNull(result);
  }
}
