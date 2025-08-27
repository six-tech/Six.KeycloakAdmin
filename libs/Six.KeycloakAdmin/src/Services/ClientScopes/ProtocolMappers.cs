using Six.KeycloakAdmin.Models.ProtocolMappers;

namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class ProtocolMappers : KeycloakAdminServiceBase
{
  public ProtocolMappers(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  public async Task<bool> CreateMultipleProtocolMappersAsync(string realm,
    string clientScopeId,
    IEnumerable<ProtocolMapper> protocolMapperRepresentations,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/protocol-mappers/add-models")
      .PostJsonAsync(protocolMapperRepresentations, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> CreateProtocolMapperAsync(string realm,
    string clientScopeId,
    ProtocolMapper protocolMapperRepresentation,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/protocol-mappers/models")
      .PostJsonAsync(protocolMapperRepresentation, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IEnumerable<ProtocolMapper>> GetProtocolMappersAsync(string realm,
    string clientScopeId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/protocol-mappers/models")
      .GetJsonAsync<IEnumerable<ProtocolMapper>>(cancellationToken: cancellationToken)
      ;

  public async Task<ProtocolMapper> GetProtocolMapperAsync(string realm,
    string clientScopeId,
    string protocolMapperId,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment(
        $"/admin/realms/{realm}/client-scopes/{clientScopeId}/protocol-mappers/models/{protocolMapperId}")
      .GetJsonAsync<ProtocolMapper>(cancellationToken: cancellationToken)
      ;

  public async Task<bool> UpdateProtocolMapperAsync(string realm,
    string clientScopeId,
    string protocolMapperId,
    ProtocolMapper protocolMapperRepresentation,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment(
        $"/admin/realms/{realm}/client-scopes/{clientScopeId}/protocol-mappers/models/{protocolMapperId}")
      .PutJsonAsync(protocolMapperRepresentation, cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> DeleteProtocolMapperAsync(string realm,
    string clientScopeId,
    string protocolMapperId,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment(
        $"/admin/realms/{realm}/client-scopes/{clientScopeId}/protocol-mappers/models/{protocolMapperId}")
      .DeleteAsync(cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<IEnumerable<ProtocolMapper>> GetProtocolMappersByNameAsync(string realm,
    string clientScopeId,
    string protocol,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/client-scopes/{clientScopeId}/protocol-mappers/protocol/{protocol}")
      .GetJsonAsync<IEnumerable<ProtocolMapper>>(cancellationToken: cancellationToken)
      ;
}
