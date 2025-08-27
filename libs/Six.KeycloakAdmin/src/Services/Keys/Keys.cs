using Six.KeycloakAdmin.Models.Key;

namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class Keys : KeycloakAdminServiceBase
{
  public Keys(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  public async Task<KeysMetadata> GetKeysAsync(string realm, CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/keys")
      .GetJsonAsync<KeysMetadata>(cancellationToken: cancellationToken)
      ;
}
