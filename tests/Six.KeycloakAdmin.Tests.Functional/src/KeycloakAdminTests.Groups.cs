namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "Groups")]
  [Theory]
  [InlineData("master")]
  public async Task GetGroupHierarchyAsync(string realm)
  {
    var result = await _adminProvider.Groups.GetGroupHierarchyAsync(realm);
    Assert.NotNull(result);
  }

  [Trait("Category", "Groups")]
  [Theory]
  [InlineData("master")]
  public async Task GetGroupsCountAsync(string realm)
  {
    int? result = await _adminProvider.Groups.GetGroupsCountAsync(realm);
    Assert.True(result >= 0);
  }

  [Trait("Category", "Groups")]
  [Theory]
  [InlineData("master")]
  public async Task GetGroupAsync(string realm)
  {
    var groups = await _adminProvider.Groups.GetGroupHierarchyAsync(realm);
    var groupId = groups.FirstOrDefault()?.Id;
    if(groupId != null)
    {
      var result = await _adminProvider.Groups.GetGroupAsync(realm, groupId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Groups")]
  [Theory]
  [InlineData("master")]
  public async Task GetGroupClientAuthorizationPermissionsInitializedAsync(string realm)
  {
    var groups = await _adminProvider.Groups.GetGroupHierarchyAsync(realm);
    var groupId = groups.FirstOrDefault()?.Id;
    if(groupId != null)
    {
      var result = await _adminProvider.Groups.GetGroupClientAuthorizationPermissionsInitializedAsync(realm, groupId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "Groups")]
  [Theory]
  [InlineData("master")]
  public async Task GetGroupUsersAsync(string realm)
  {
    var groups = await _adminProvider.Groups.GetGroupHierarchyAsync(realm);
    var groupId = groups.FirstOrDefault()?.Id;
    if(groupId != null)
    {
      var result = await _adminProvider.Groups.GetGroupUsersAsync(realm, groupId);
      Assert.NotNull(result);
    }
  }
}
