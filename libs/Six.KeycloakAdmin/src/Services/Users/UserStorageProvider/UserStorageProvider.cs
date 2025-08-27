using Six.KeycloakAdmin.Models.UserStorageProvider;

namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class UserStorageProvider : KeycloakAdminServiceBase
{
  public UserStorageProvider(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  [Obsolete("Not working yet")]
  public async Task<bool> RemoveImportedUsersAsync(
    string realm,
    string storageProviderId,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/user-storage/{storageProviderId}/remove-imported-users")
      .PostAsync(new StringContent(""), cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  [Obsolete("Not working yet")]
  public async Task<SynchronizationResult> TriggerUserSynchronizationAsync(
    string realm,
    string storageProviderId,
    UserSyncActions action,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/user-storage/{storageProviderId}/sync")
      .SetQueryParam(nameof(action),
        action == UserSyncActions.Full
          ? "triggerFullSync"
          : "triggerChangedUsersSync")
      .PostAsync(new StringContent(""), cancellationToken: cancellationToken)
      .ReceiveJson<SynchronizationResult>()
      ;

  [Obsolete("Not working yet")]
  public async Task<bool> UnlinkImportedUsersAsync(
    string realm,
    string storageProviderId,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/user-storage/{storageProviderId}/unlink-users")
      .PostAsync(new StringContent(""), cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  [Obsolete("Not working yet")]
  public async Task<SynchronizationResult> TriggerLdapMapperSynchronizationAsync(
    string realm,
    string storageProviderId,
    string mapperId,
    LdapMapperSyncActions direction,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/user-storage/{storageProviderId}/mappers/{mapperId}/sync")
      .SetQueryParam(nameof(direction),
        direction == LdapMapperSyncActions.FedToKeycloak
          ? "fedToKeycloak"
          : "keycloakToFed")
      .PostAsync(new StringContent(""), cancellationToken: cancellationToken)
      .ReceiveJson<SynchronizationResult>()
      ;
}
