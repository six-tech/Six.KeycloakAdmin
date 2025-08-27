using Six.KeycloakAdmin.Models.AuthorizationPermissions;
using Six.KeycloakAdmin.Models.AuthorizationScopes;
using Six.KeycloakAdmin.Models.Clients;
using AuthorizationResources_AuthorizationResource = Six.KeycloakAdmin.Models.AuthorizationResources.AuthorizationResource;

namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class ClientAuthorization : KeycloakAdminServiceBase
{
  public ClientAuthorization(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  #region Permissions

  public async Task<AuthorizationPermission> CreateAuthorizationPermissionAsync(string realm,
    string clientId,
    AuthorizationPermission permission,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/permission")
      .AppendPathSegment(permission.Type == AuthorizationPermissionType.Scope ? "/scope" : "/resource")
      .PostJsonAsync(permission, cancellationToken: cancellationToken)
      .ReceiveJson<AuthorizationPermission>()
      ;

  public async Task<AuthorizationPermission> GetAuthorizationPermissionByIdAsync(string realm,
    string clientId,
    AuthorizationPermissionType permissionType,
    string permissionId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/permission")
      .AppendPathSegment(permissionType == AuthorizationPermissionType.Scope ? "/scope" : "/resource")
      .AppendPathSegment($"/{permissionId}")
      .GetJsonAsync<AuthorizationPermission>(cancellationToken: cancellationToken)
      ;

  public async Task<IEnumerable<AuthorizationPermission>> GetAuthorizationPermissionsAsync(string realm,
    string clientId,
    AuthorizationPermissionType? ofPermissionType = null,
    int? first = null,
    int? max = null,
    string? name = null,
    string? resource = null,
    string? scope = null,
    CancellationToken cancellationToken = default)
  {
    var queryParams = new Dictionary<string, object?>
    {
      [nameof(first)] = first,
      [nameof(max)] = max,
      [nameof(name)] = name,
      [nameof(resource)] = resource,
      [nameof(scope)] = scope
    };

    var request = (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/permission");

    if(ofPermissionType.HasValue)
      request = request.AppendPathSegment(ofPermissionType.Value == AuthorizationPermissionType.Scope
        ? "/scope"
        : "/resource");

    return await request.SetQueryParams(queryParams)
      .GetJsonAsync<IEnumerable<AuthorizationPermission>>(cancellationToken: cancellationToken)
      ;
  }

  public async Task<bool> UpdateAuthorizationPermissionAsync(string realm,
    string clientId,
    AuthorizationPermission permission,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/permission")
      .AppendPathSegment(permission.Type == AuthorizationPermissionType.Scope ? "/scope" : "/resource")
      .AppendPathSegment($"/{permission.Id}")
      .PutJsonAsync(permission, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> DeleteAuthorizationPermissionAsync(string realm,
    string clientId,
    AuthorizationPermissionType permissionType,
    string permissionId,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/permission")
      .AppendPathSegment(permissionType == AuthorizationPermissionType.Scope ? "/scope" : "/resource")
      .AppendPathSegment($"/{permissionId}")
      .DeleteAsync(cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IEnumerable<Policy>> GetAuthorizationPermissionAssociatedPoliciesAsync(string realm,
    string clientId,
    string permissionId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment(
        $"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy/{permissionId}/associatedPolicies")
      .GetJsonAsync<IEnumerable<Policy>>(cancellationToken: cancellationToken)
      ;

  public async Task<IEnumerable<AuthorizationScope>> GetAuthorizationPermissionAssociatedScopesAsync(string realm,
    string clientId,
    string permissionId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy/{permissionId}/scopes")
      .GetJsonAsync<IEnumerable<AuthorizationScope>>(cancellationToken: cancellationToken)
      ;

  public async Task<IEnumerable<AuthorizationResources_AuthorizationResource>> GetAuthorizationPermissionAssociatedResourcesAsync(string realm,
    string clientId,
    string permissionId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment(
        $"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy/{permissionId}/resources")
      .GetJsonAsync<IEnumerable<AuthorizationResources_AuthorizationResource>>(cancellationToken: cancellationToken)
      ;

  #endregion

  #region Policy

  public async Task<RolePolicy> CreateRolePolicyAsync(string realm,
    string clientId,
    RolePolicy policy,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
      .AppendPathSegment(policy.Type == PolicyType.Role ? "/role" : string.Empty)
      .PostJsonAsync(policy, cancellationToken: cancellationToken)
      .ReceiveJson<RolePolicy>()
      ;

  public async Task<UserPolicy> CreateUserPolicyAsync(string realm,
    string clientId,
    UserPolicy policy,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
      .AppendPathSegment(policy.Type == PolicyType.User ? "/user" : string.Empty)
      .PostJsonAsync(policy, cancellationToken: cancellationToken)
      .ReceiveJson<UserPolicy>()
      ;

  public async Task<GroupPolicy> CreateGroupPolicyAsync(string realm,
    string clientId,
    GroupPolicy policy,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
      .AppendPathSegment(policy.Type == PolicyType.Group ? "/group" : string.Empty)
      .PostJsonAsync(policy, cancellationToken: cancellationToken)
      .ReceiveJson<GroupPolicy>()
      ;

  public async Task<RolePolicy> GetRolePolicyByIdAsync(string realm,
    string clientId,
    PolicyType policyType,
    string rolePolicyId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
      .AppendPathSegment(policyType == PolicyType.Role ? "/role" : string.Empty)
      .AppendPathSegment($"/{rolePolicyId}")
      .GetJsonAsync<RolePolicy>(cancellationToken: cancellationToken)
      ;

  public async Task<UserPolicy> GetUserPolicyByIdAsync(string realm,
    string clientId,
    PolicyType policyType,
    string userPolicyId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
      .AppendPathSegment(policyType == PolicyType.User ? "/user" : string.Empty)
      .AppendPathSegment($"/{userPolicyId}")
      .GetJsonAsync<UserPolicy>(cancellationToken: cancellationToken)
      ;

  public async Task<GroupPolicy> GetGroupPolicyByIdAsync(string realm,
    string clientId,
    PolicyType policyType,
    string groupPolicyId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
      .AppendPathSegment(policyType == PolicyType.Group ? "/group" : string.Empty)
      .AppendPathSegment($"/{groupPolicyId}")
      .GetJsonAsync<GroupPolicy>(cancellationToken: cancellationToken)
      ;

  public async Task<IEnumerable<Policy>> GetAuthorizationPoliciesAsync(string realm,
    string clientId,
    int? first = null,
    int? max = null,
    string? name = null,
    string? resource = null,
    string? scope = null,
    bool? permission = null,
    CancellationToken cancellationToken = default)
  {
    var queryParams = new Dictionary<string, object?>
    {
      [nameof(first)] = first,
      [nameof(max)] = max,
      [nameof(name)] = name,
      [nameof(resource)] = resource,
      [nameof(scope)] = scope,
      [nameof(permission)] = permission
    };

    return await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
      .SetQueryParams(queryParams)
      .GetJsonAsync<IEnumerable<Policy>>(cancellationToken: cancellationToken)
      ;
  }

  public async Task<IEnumerable<RolePolicy>> GetRolePoliciesAsync(string realm,
    string clientId,
    int? first = null,
    int? max = null,
    string? name = null,
    string? resource = null,
    string? scope = null,
    bool? permission = null,
    CancellationToken cancellationToken = default)
  {
    var queryParams = new Dictionary<string, object?>
    {
      [nameof(first)] = first,
      [nameof(max)] = max,
      [nameof(name)] = name,
      [nameof(resource)] = resource,
      [nameof(scope)] = scope,
      [nameof(permission)] = permission
    };

    return await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy/role")
      .SetQueryParams(queryParams)
      .GetJsonAsync<IEnumerable<RolePolicy>>(cancellationToken: cancellationToken)
      ;
  }

  public async Task<bool> UpdateRolePolicyAsync(string realm,
    string clientId,
    RolePolicy policy,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
      .AppendPathSegment(policy.Type == PolicyType.Role ? "/role" : string.Empty)
      .AppendPathSegment($"/{policy.Id}")
      .PutJsonAsync(policy, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> UpdateUserPolicyAsync(string realm,
    string clientId,
    UserPolicy policy,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
      .AppendPathSegment(policy.Type == PolicyType.User ? "/user" : string.Empty)
      .AppendPathSegment($"/{policy.Id}")
      .PutJsonAsync(policy, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> UpdateGroupPolicyAsync(string realm,
    string clientId,
    GroupPolicy policy,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
      .AppendPathSegment(policy.Type == PolicyType.Group ? "/group" : string.Empty)
      .AppendPathSegment($"/{policy.Id}")
      .PutJsonAsync(policy, cancellationToken: cancellationToken);
    
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> DeleteRolePolicyAsync(string realm,
    string clientId,
    PolicyType policyType,
    string rolePolicyId,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
      .AppendPathSegment(policyType == PolicyType.Role ? "/role" : string.Empty)
      .AppendPathSegment($"/{rolePolicyId}")
      .DeleteAsync(cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> DeleteUserPolicyAsync(string realm,
    string clientId,
    PolicyType policyType,
    string userPolicyId,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
      .AppendPathSegment(policyType == PolicyType.User ? "/user" : string.Empty)
      .AppendPathSegment($"/{userPolicyId}")
      .DeleteAsync(cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> DeleteGroupPolicyAsync(string realm,
    string clientId,
    PolicyType policyType,
    string groupPolicyId,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/authz/resource-server/policy")
      .AppendPathSegment(policyType == PolicyType.Group ? "/group" : string.Empty)
      .AppendPathSegment($"/{groupPolicyId}")
      .DeleteAsync(cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  #endregion
}
