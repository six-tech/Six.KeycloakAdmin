using Six.KeycloakAdmin.Models.Users;

namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "AttackDetection")]
  [Theory]
  [InlineData("Insurance", "vermeulen")]
  public async Task GetUserNameStatusInBruteForceDetectionAsync(string realm, string search)
  {
    var users = await _adminProvider.Users.GetUsersAsync(realm, search: search);
    var enumerable = users as User[] ?? users.ToArray();
    
    var user = enumerable.ToList().FirstOrDefault();
    string? userId = user?.Id;

    if(userId is not null)
    {
      var result = await _adminProvider.AttackDetection.GetUserNameStatusInBruteForceDetectionAsync(realm, userId);
      Assert.NotNull(result);
    }
  }
}
