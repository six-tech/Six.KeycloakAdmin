using Six.KeycloakAdmin.Models.Components;

namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class ClientRegistrationPolicy : KeycloakAdminServiceBase
{
  public ClientRegistrationPolicy(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  public async Task<IEnumerable<ComponentType>> GetRetrieveProvidersBasePathAsync(
    string realm,
    CancellationToken cancellationToken = default)
  {
    return await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/client-registration-policy/providers")
      .GetJsonAsync<IEnumerable<ComponentType>>(cancellationToken: cancellationToken)
      ;
  }
}
