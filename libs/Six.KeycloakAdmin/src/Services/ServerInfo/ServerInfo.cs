namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class ServerInfo : KeycloakAdminServiceBase
{
  public ServerInfo(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  public async Task<Models.Root.ServerInfo> GetServerInfoAsync(string realm, CancellationToken cancellationToken = default) =>
    await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment("/admin/serverinfo/")
      .GetJsonAsync<Models.Root.ServerInfo>(cancellationToken: cancellationToken)
      ;

  public async Task<bool> CorsPreflightAsync(string realm, CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm)).AppendPathSegment("/admin/serverinfo/")
      .OptionsAsync(cancellationToken: cancellationToken)
      ;
    return response.ResponseMessage.IsSuccessStatusCode;
  }
}
