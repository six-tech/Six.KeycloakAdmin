using System.Net.Http;
using Six.KeycloakAdmin.Models.Common;
using Six.KeycloakAdmin.Models.Roles;

namespace Six.KeycloakAdmin.Services;

public class RolesById : KeycloakAdminServiceBase
{
  public RolesById(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  public async Task<Role> GetRoleByIdAsync(string realm,
    string roleId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}")
      .GetJsonAsync<Role>(cancellationToken: cancellationToken)
      ;

  public async Task<bool> UpdateRoleByIdAsync(string realm,
    string roleId,
    Role role,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}")
      .PutJsonAsync(role, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> DeleteRoleByIdAsync(string realm,
    string roleId,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}")
      .DeleteAsync(cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> MakeRoleCompositeAsync(string realm,
    string roleId,
    IEnumerable<Role> roles,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}/composites")
      .PostJsonAsync(roles, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IEnumerable<Role>> GetRoleChildrenAsync(string realm,
    string roleId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}/composites")
      .GetJsonAsync<IEnumerable<Role>>(cancellationToken: cancellationToken)
      ;

  public async Task<bool> RemoveRolesFromCompositeAsync(string realm,
    string roleId,
    IEnumerable<Role> roles,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}/composites")
      .SendJsonAsync(HttpMethod.Delete, roles, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IEnumerable<Role>> GetClientRolesForCompositeByIdAsync(string realm,
    string roleId,
    string clientId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}/composites/clients/{clientId}")
      .GetJsonAsync<IEnumerable<Role>>(cancellationToken: cancellationToken)
      ;

  public async Task<IEnumerable<Role>> GetRealmRolesForCompositeByIdAsync(string realm,
    string roleId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}/composites/realm")
      .GetJsonAsync<IEnumerable<Role>>(cancellationToken: cancellationToken)
      ;

  public async Task<ManagementPermission> GetRoleByIdAuthorizationPermissionsInitializedAsync(string realm,
    string roleId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}/management/permissions")
      .GetJsonAsync<ManagementPermission>(cancellationToken: cancellationToken)
      ;

  public async Task<ManagementPermission> SetRoleByIdAuthorizationPermissionsInitializedAsync(string realm,
    string roleId,
    ManagementPermission managementPermission,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/roles-by-id/{roleId}/management/permissions")
      .PutJsonAsync(managementPermission, cancellationToken: cancellationToken)
      .ReceiveJson<ManagementPermission>()
      ;
}
