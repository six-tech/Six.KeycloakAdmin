using Six.KeycloakAdmin.Models.ClientInitialAccess;

namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class ClientInitialAccess : KeycloakAdminServiceBase
{
  public ClientInitialAccess(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  public async Task<ClientInitialAccessPresentation> CreateInitialAccessTokenAsync(string realm,
    ClientInitialAccessCreatePresentation create, CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/clients-initial-access")
      .PostJsonAsync(create, cancellationToken: cancellationToken)
      .ReceiveJson<ClientInitialAccessPresentation>()
      ;

  public async Task<IEnumerable<ClientInitialAccessPresentation>> GetClientInitialAccessAsync(string realm,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/clients-initial-access")
      .GetJsonAsync<IEnumerable<ClientInitialAccessPresentation>>(cancellationToken: cancellationToken)
      ;

  public async Task<bool> DeleteInitialAccessTokenAsync(string realm, string clientInitialAccessTokenId,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients-initial-access/{clientInitialAccessTokenId}")
      .DeleteAsync(cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }
}
