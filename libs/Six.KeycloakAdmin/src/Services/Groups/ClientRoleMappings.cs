using System.Net.Http;
using Six.KeycloakAdmin.Models.Roles;

namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class ClientRoleMappings : KeycloakAdminServiceBase
{
  public ClientRoleMappings(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  public async Task<bool> AddClientRoleMappingsToGroupAsync(string realm,
    string groupId,
    string clientId,
    IEnumerable<Role> roles,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/role-mappings/clients/{clientId}")
      .PostJsonAsync(roles, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IEnumerable<Role>> GetClientRoleMappingsForGroupAsync(string realm,
    string groupId,
    string clientId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/role-mappings/clients/{clientId}")
      .GetJsonAsync<IEnumerable<Role>>(cancellationToken: cancellationToken)
      ;

  public async Task<bool> DeleteClientRoleMappingsFromGroupAsync(string realm,
    string groupId,
    string clientId,
    IEnumerable<Role> roles,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/role-mappings/clients/{clientId}")
      .SendJsonAsync(HttpMethod.Delete,
        roles,
        cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IEnumerable<Role>> GetAvailableClientRoleMappingsForGroupAsync(string realm,
    string groupId,
    string clientId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/role-mappings/clients/{clientId}/available")
      .GetJsonAsync<IEnumerable<Role>>(cancellationToken: cancellationToken)
      ;

  public async Task<IEnumerable<Role>> GetEffectiveClientRoleMappingsForGroupAsync(string realm,
    string groupId,
    string clientId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/role-mappings/clients/{clientId}/composite")
      .GetJsonAsync<IEnumerable<Role>>(cancellationToken: cancellationToken)
      ;

  public async Task<bool> AddClientRoleMappingsToUserAsync(string realm,
    string userId,
    string clientId,
    IEnumerable<Role> roles,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/role-mappings/clients/{clientId}")
      .PostJsonAsync(roles, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IEnumerable<Role>> GetClientRoleMappingsForUserAsync(string realm,
    string userId,
    string clientId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/role-mappings/clients/{clientId}")
      .GetJsonAsync<IEnumerable<Role>>(cancellationToken: cancellationToken)
      ;

  public async Task<bool> DeleteClientRoleMappingsFromUserAsync(string realm,
    string userId,
    string clientId,
    IEnumerable<Role> roles,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/role-mappings/clients/{clientId}")
      .SendJsonAsync(HttpMethod.Delete,
        roles,
        cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IEnumerable<Role>> GetAvailableClientRoleMappingsForUserAsync(string realm,
    string userId,
    string clientId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/role-mappings/clients/{clientId}/available")
      .GetJsonAsync<IEnumerable<Role>>(cancellationToken: cancellationToken)
      ;

  public async Task<IEnumerable<Role>> GetEffectiveClientRoleMappingsForUserAsync(string realm,
    string userId,
    string clientId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/role-mappings/clients/{clientId}/composite")
      .GetJsonAsync<IEnumerable<Role>>(cancellationToken: cancellationToken)
      ;
}
