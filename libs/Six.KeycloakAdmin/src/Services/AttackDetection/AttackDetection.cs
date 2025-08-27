using Six.KeycloakAdmin.Models.AttackDetection;

namespace Six.KeycloakAdmin.Services;

[PublicAPI]
public class AttackDetection : KeycloakAdminServiceBase
{
  public AttackDetection(KeycloakAdminProviderBase internalAdminProvider) : base(internalAdminProvider) { }

  public async Task<bool> ClearUserLoginFailuresAsync(
    string realm,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/attack-detection/brute-force/users")
      .DeleteAsync(cancellationToken: cancellationToken);

    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<bool> ClearUserLoginFailuresAsync(
    string realm,
    string userId,
    CancellationToken cancellationToken = default)
  {
    var response = await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/attack-detection/brute-force/users/{userId}")
      .DeleteAsync(cancellationToken: cancellationToken)
      ;

    return response.ResponseMessage.IsSuccessStatusCode;
  }

  public async Task<UserNameStatus> GetUserNameStatusInBruteForceDetectionAsync(
    string realm,
    string userId,
    CancellationToken cancellationToken = default)

  {
    return await (await InternalAdminProvider.GetRequestBuilderAsync(realm))
      .AppendPathSegment($"/admin/realms/{realm}/attack-detection/brute-force/users/{userId}")
      .GetJsonAsync<UserNameStatus>(cancellationToken: cancellationToken)
      ;
  }
}
