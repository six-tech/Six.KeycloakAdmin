using Six.KeycloakAdmin.Models.AuthorizationResources;

namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class AuthZResource : KeycloakAdminServiceBase
{
  public AuthZResource(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  public async Task<string> CreateResourceAsync(string realm,
    string resourceServerId,
    AuthorizationResource resource,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{resourceServerId}/authz/resource-server/resource")
      .PostJsonAsync(resource, cancellationToken: cancellationToken)
      .ReceiveJson<AuthorizationResource>()
      ;
    
    return response.Id;
  }

  public async Task<IEnumerable<AuthorizationResource>> GetResourcesAsync(string realm,
    string? resourceServerId = null,
    bool deep = false,
    int? first = null,
    int? max = null,
    string? name = null,
    string? owner = null,
    string? type = null,
    string? uri = null,
    CancellationToken cancellationToken = default)
  {
    var queryParams = new Dictionary<string, object?>
    {
      [nameof(deep)] = deep,
      [nameof(first)] = first,
      [nameof(max)] = max,
      [nameof(name)] = name,
      [nameof(owner)] = owner,
      [nameof(type)] = type,
      [nameof(uri)] = uri
    };

    return await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/clients/{resourceServerId}/authz/resource-server/resource")
      .SetQueryParams(queryParams)
      .GetJsonAsync<IEnumerable<AuthorizationResource>>(cancellationToken: cancellationToken)
      ;
  }

  public async Task<AuthorizationResource> GetResourceAsync(string realm,
    string resourceServerId,
    string resourceId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment(
        $"/admin/realms/{realm}/clients/{resourceServerId}/authz/resource-server/resource/{resourceId}")
      .GetJsonAsync<AuthorizationResource>(cancellationToken: cancellationToken)
      ;

  public async Task<bool> UpdateResourceAsync(string realm,
    string resourceServerId,
    string resourceId,
    AuthorizationResource resource,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment(
        $"/admin/realms/{realm}/clients/{resourceServerId}/authz/resource-server/resource/{resourceId}")
      .PutJsonAsync(resource, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> DeleteResourceAsync(string realm,
    string resourceServerId,
    string resourceId,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment(
        $"/admin/realms/{realm}/clients/{resourceServerId}/authz/resource-server/resource/{resourceId}")
      .DeleteAsync(cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }
}
