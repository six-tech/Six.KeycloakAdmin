using Six.KeycloakAdmin.Models.ClientScopes;

namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class ClientScopes : KeycloakAdminServiceBase
{
  public ClientScopes(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  public async Task<bool> CreateClientScopeAsync(string realm,
    ClientScope clientScope,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/client-scopes")
      .PostJsonAsync(clientScope, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IEnumerable<ClientScope>> GetClientScopesAsync(string realm,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/client-scopes")
      .GetJsonAsync<IEnumerable<ClientScope>>(cancellationToken: cancellationToken)
      ;

  public async Task<ClientScope> GetClientScopeAsync(string realm,
    string clientScopeId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}")
      .GetJsonAsync<ClientScope>(cancellationToken: cancellationToken)
      ;

  public async Task<bool> UpdateClientScopeAsync(string realm,
    string clientScopeId,
    ClientScope clientScope,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}")
      .PutJsonAsync(clientScope, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> DeleteClientScopeAsync(string realm,
    string clientScopeId,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}")
      .DeleteAsync(cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }
}
