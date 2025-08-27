namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "Users")]
  [Theory]
  [InlineData("master")]
  public async Task GetUsersAsync(string realm)
  {
    var result = await _adminProvider.Users.GetUsersAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "Users")]
  [Theory]
  [InlineData("master")]
  public async Task GetUsersCountAsync(string realm)
  {
    int? result = await _adminProvider.Users.GetUsersCountAsync(realm);
    Assert.True(result >= 0);
  }

  [Trait("Category", "Users")]
  [Theory]
  [InlineData("master")]
  public async Task GetUserAsync(string realm)
  {
    var users = await _adminProvider.Users.GetUsersAsync(realm);
    var userId = users.FirstOrDefault()?.Id;
    if(userId != null)
    {
      var result = await _adminProvider.Users.GetUserAsync(realm, userId);
      Assert.NotNull(result);
      Assert.Equal(userId, result.Id);
    }
  }

  [Trait("Category", "Users")]
  [Theory]
  [InlineData("Insurance", "vermeulen")]
  public async Task GetUserSocialLoginsAsync(string realm, string search)
  {
    var users = await _adminProvider.Users.GetUsersAsync(realm, search: search);
    var userId = users.FirstOrDefault()?.Id;
    if(userId != null)
    {
      var result = await _adminProvider.Users.GetUserSocialLoginsAsync(realm, userId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Users")]
  [Theory]
  [InlineData("Insurance", "vermeulen")]
  public async Task GetUserGroupsAsync(string realm, string search)
  {
    var users = await _adminProvider.Users.GetUsersAsync(realm, search: search);
    var userId = users.FirstOrDefault()?.Id;
    if(userId != null)
    {
      var result = await _adminProvider.Users.GetUserGroupsAsync(realm, userId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Users")]
  [Theory]
  [InlineData("Insurance", "vermeulen")]
  public async Task GetUserGroupsCountAsync(string realm, string search)
  {
    var users = await _adminProvider.Users.GetUsersAsync(realm, search: search);
    var userId = users.FirstOrDefault()?.Id;
    if(userId != null)
    {
      int? result = await _adminProvider.Users.GetUserGroupsCountAsync(realm, userId);
      Assert.True(result >= 0);
    }
  }

  [Trait("Category", "Users")]
  [Theory]
  [InlineData("Insurance", "vermeulen")]
  public async Task GetUserSessionsAsync(string realm, string search)
  {
    var users = await _adminProvider.Users.GetUsersAsync(realm, search: search);
    var userId = users.FirstOrDefault()?.Id;
    if(userId != null)
    {
      var result = await _adminProvider.Users.GetUserSessionsAsync(realm, userId);
      Assert.NotNull(result);
    }
  }
}
