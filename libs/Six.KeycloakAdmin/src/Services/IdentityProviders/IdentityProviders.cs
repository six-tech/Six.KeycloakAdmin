using Six.KeycloakAdmin.Models.Common;
using Six.KeycloakAdmin.Models.IdentityProviders;

namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class IdentityProviders : KeycloakAdminServiceBase
{
  public IdentityProviders(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  public async Task<IDictionary<string, object>> ImportIdentityProviderAsync(string realm,
    string input,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/identity-provider/import-config")
      .PostMultipartAsync(content => content.AddFile(Path.GetFileName(input), Path.GetDirectoryName(input)),
        cancellationToken: cancellationToken)
      .ReceiveJson<IDictionary<string, object>>()
      ;

  public async Task<bool> CreateIdentityProviderAsync(string realm,
    IdentityProvider identityProvider,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances")
      .PostJsonAsync(identityProvider, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IEnumerable<IdentityProvider>> GetIdentityProviderInstancesAsync(string realm,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances")
      .GetJsonAsync<IEnumerable<IdentityProvider>>(cancellationToken: cancellationToken)
      ;

  public async Task<IdentityProvider> GetIdentityProviderAsync(string realm,
    string identityProviderAlias,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{identityProviderAlias}")
      .GetJsonAsync<IdentityProvider>(cancellationToken: cancellationToken)
      ;


  public async Task<IdentityProviderToken> GetIdentityProviderTokenAsync(string realm,
    string identityProviderAlias,
    CancellationToken cancellationToken = default)
  {
    // See: https://github.com/keycloak/keycloak-documentation/blob/master/server_development/topics/identity-brokering/tokens.adoc

    return await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/auth/realms/{realm}/broker/{identityProviderAlias}/token")
      .GetJsonAsync<IdentityProviderToken>(cancellationToken: cancellationToken)
      ;
  }


  public async Task<bool> UpdateIdentityProviderAsync(string realm,
    string identityProviderAlias,
    IdentityProvider identityProvider,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{identityProviderAlias}")
      .PutJsonAsync(identityProvider, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> DeleteIdentityProviderAsync(string realm,
    string identityProviderAlias,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{identityProviderAlias}")
      .DeleteAsync(cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> ExportIdentityProviderPublicBrokerConfigurationAsync(string realm,
    string identityProviderAlias,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{identityProviderAlias}/export")
      .GetAsync(cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<ManagementPermission> GetIdentityProviderAuthorizationPermissionsInitializedAsync(string realm,
    string identityProviderAlias,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment(
        $"/admin/realms/{realm}/identity-provider/instances/{identityProviderAlias}/management/permissions")
      .GetJsonAsync<ManagementPermission>(cancellationToken: cancellationToken)
      ;

  public async Task<ManagementPermission> SetIdentityProviderAuthorizationPermissionsInitializedAsync(string realm,
    string identityProviderAlias,
    ManagementPermission managementPermission,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment(
        $"/admin/realms/{realm}/identity-provider/instances/{identityProviderAlias}/management/permissions")
      .PutJsonAsync(managementPermission, cancellationToken: cancellationToken)
      .ReceiveJson<ManagementPermission>()
      ;

  public async Task<IDictionary<string, object>> GetIdentityProviderMapperTypesAsync(string realm,
    string identityProviderAlias,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{identityProviderAlias}/mapper-types")
      .GetJsonAsync<IDictionary<string, object>>(cancellationToken: cancellationToken)
      ;

  public async Task<bool> AddIdentityProviderMapperAsync(string realm,
    string identityProviderAlias,
    IdentityProviderMapper identityProviderMapper,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{identityProviderAlias}/mappers")
      .PostJsonAsync(identityProviderMapper, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IEnumerable<IdentityProviderMapper>> GetIdentityProviderMappersAsync(string realm,
    string identityProviderAlias,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/identity-provider/instances/{identityProviderAlias}/mappers")
      .GetJsonAsync<IEnumerable<IdentityProviderMapper>>(cancellationToken: cancellationToken)
      ;

  public async Task<IdentityProviderMapper> GetIdentityProviderMapperByIdAsync(string realm,
    string identityProviderAlias,
    string mapperId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment(
        $"/admin/realms/{realm}/identity-provider/instances/{identityProviderAlias}/mappers/{mapperId}")
      .GetJsonAsync<IdentityProviderMapper>(cancellationToken: cancellationToken)
      ;

  public async Task<bool> UpdateIdentityProviderMapperAsync(string realm,
    string identityProviderAlias,
    string mapperId,
    IdentityProviderMapper identityProviderMapper,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment(
        $"/admin/realms/{realm}/identity-provider/instances/{identityProviderAlias}/mappers/{mapperId}")
      .PutJsonAsync(identityProviderMapper, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> DeleteIdentityProviderMapperAsync(
    string realm,
    string identityProviderAlias,
    string mapperId,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment(
        $"/admin/realms/{realm}/identity-provider/instances/{identityProviderAlias}/mappers/{mapperId}")
      .DeleteAsync(cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IdentityProviderInfo> GetIdentityProviderByProviderIdAsync(string realm,
    string providerId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/identity-provider/providers/{providerId}")
      .GetJsonAsync<IdentityProviderInfo>(cancellationToken: cancellationToken)
      ;
}
