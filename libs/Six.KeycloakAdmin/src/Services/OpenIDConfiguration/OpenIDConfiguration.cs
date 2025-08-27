namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class OpenIDConfiguration : KeycloakAdminServiceBase
{
  public OpenIDConfiguration(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  public async Task<OpenIDConfiguration> GetOpenIdConfigurationAsync(string realm,
    CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment($"/realms/{realm}/.well-known/openid-configuration")
      .GetJsonAsync<OpenIDConfiguration>(cancellationToken: cancellationToken)
      ;
}
