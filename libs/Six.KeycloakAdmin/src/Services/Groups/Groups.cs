using Six.KeycloakAdmin.Models.Common;
using Six.KeycloakAdmin.Models.Groups;
using Six.KeycloakAdmin.Models.Users;

namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class Groups : KeycloakAdminServiceBase
{
  public Groups(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  public async Task<bool> CreateGroupAsync(string realm, Group group, CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/groups")
      .PostJsonAsync(group, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IEnumerable<Group>> GetGroupHierarchyAsync(string realm,
    int? first = null,
    int? max = null,
    string? search = null,
    CancellationToken cancellationToken = default)
  {
    var queryParams = new Dictionary<string, object?>
    {
      [nameof(first)] = first, [nameof(max)] = max, [nameof(search)] = search, ["briefRepresentation"] = false
    };

    return await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/groups")
      .SetQueryParams(queryParams)
      .GetJsonAsync<IEnumerable<Group>>(cancellationToken: cancellationToken)
      ;
  }

  public async Task<int> GetGroupsCountAsync(string realm,
    string? search = null,
    bool? top = null,
    CancellationToken cancellationToken = default)
  {
    var queryParams = new Dictionary<string, object?> { [nameof(search)] = search, [nameof(top)] = top };

    var result = await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/groups/count")
      .SetQueryParams(queryParams)
      .GetJsonAsync<CountDto>(cancellationToken: cancellationToken)
      ;

    return result.Count;
  }

  public async Task<Group> GetGroupAsync(string realm,
    string groupId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}")
      .GetJsonAsync<Group>(cancellationToken: cancellationToken)
      ;

  public async Task<bool> UpdateGroupAsync(string realm,
    string groupId,
    Group group,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}")
      .PutJsonAsync(group, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> DeleteGroupAsync(string realm,
    string groupId,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}")
      .DeleteAsync(cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> SetOrCreateGroupChildAsync(string realm,
    string groupId,
    Group group,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/children")
      .PostJsonAsync(group, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IEnumerable<Group>> GetGroupChildrenAsync(string realm,
    string groupId,
    int? first = null,
    int? max = null,
    CancellationToken cancellationToken = default)
  {
    var queryParams = new Dictionary<string, object?>
    {
      [nameof(first)] = first, [nameof(max)] = max, ["briefRepresentation"] = false
    };

    return await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/children")
      .SetQueryParams(queryParams)
      .GetJsonAsync<IEnumerable<Group>>(cancellationToken: cancellationToken)
      ;
  }

  public async Task<ManagementPermission> GetGroupClientAuthorizationPermissionsInitializedAsync(string realm,
    string groupId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/management/permissions")
      .GetJsonAsync<ManagementPermission>(cancellationToken: cancellationToken)
      ;

  public async Task<ManagementPermission> SetGroupClientAuthorizationPermissionsInitializedAsync(string realm,
    string groupId,
    ManagementPermission managementPermission,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/management/permissions")
      .PutJsonAsync(managementPermission, cancellationToken: cancellationToken)
      .ReceiveJson<ManagementPermission>()
      ;

  public async Task<IEnumerable<User>> GetGroupUsersAsync(string realm,
    string groupId,
    int? first = null,
    int? max = null,
    CancellationToken cancellationToken = default)
  {
    var queryParams = new Dictionary<string, object?> { [nameof(first)] = first, [nameof(max)] = max };

    return await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/members")
      .SetQueryParams(queryParams)
      .GetJsonAsync<IEnumerable<User>>(cancellationToken: cancellationToken)
      ;
  }
}
