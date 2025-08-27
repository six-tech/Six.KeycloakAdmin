namespace Six.KeycloakAdmin.Tests.Functional;

public partial class KeycloakAdminTests
{
  [Trait("Category", "RoleMapper")]
  [Theory]
  [InlineData("master")]
  public async Task GetRoleMappingsForGroupAsync(string realm)
  {
    var groups = await _adminProvider.Groups.GetGroupHierarchyAsync(realm);
    var groupId = groups.FirstOrDefault()?.Id;
    if(groupId != null)
    {
      var result = await _adminProvider.GroupsRoleMapper.GetRoleMappingsForGroupAsync(realm, groupId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "RoleMapper")]
  [Theory]
  [InlineData("master")]
  public async Task GetRealmRoleMappingsForGroupAsync(string realm)
  {
    var groups = await _adminProvider.Groups.GetGroupHierarchyAsync(realm);
    var groupId = groups.FirstOrDefault()?.Id;
    if(groupId != null)
    {
      var result = await _adminProvider.GroupsRoleMapper.GetRealmRoleMappingsForGroupAsync(realm, groupId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "RoleMapper")]
  [Theory]
  [InlineData("master")]
  public async Task GetAvailableRealmRoleMappingsForGroupAsync(string realm)
  {
    var groups = await _adminProvider.Groups.GetGroupHierarchyAsync(realm);
    var groupId = groups.FirstOrDefault()?.Id;
    if(groupId != null)
    {
      var result = await _adminProvider.GroupsRoleMapper.GetAvailableRealmRoleMappingsForGroupAsync(realm, groupId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "RoleMapper")]
  [Theory]
  [InlineData("master")]
  public async Task GetEffectiveRealmRoleMappingsForGroupAsync(string realm)
  {
    var groups = await _adminProvider.Groups.GetGroupHierarchyAsync(realm);
    var groupId = groups.FirstOrDefault()?.Id;
    if(groupId != null)
    {
      var result = await _adminProvider.GroupsRoleMapper.GetEffectiveRealmRoleMappingsForGroupAsync(realm, groupId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "RoleMapper")]
  [Theory]
  [InlineData("master")]
  public async Task GetRoleMappingsForUserAsync(string realm)
  {
    var users = await _adminProvider.Users.GetUsersAsync(realm);
    var userId = users.FirstOrDefault()?.Id;
    if(userId != null)
    {
      var result = await _adminProvider.GroupsRoleMapper.GetRoleMappingsForUserAsync(realm, userId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "RoleMapper")]
  [Theory]
  [InlineData("master")]
  public async Task GetRealmRoleMappingsForUserAsync(string realm)
  {
    var users = await _adminProvider.Users.GetUsersAsync(realm);
    var userId = users.FirstOrDefault()?.Id;
    if(userId != null)
    {
      var result = await _adminProvider.GroupsRoleMapper.GetRealmRoleMappingsForUserAsync(realm, userId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "RoleMapper")]
  [Theory]
  [InlineData("master")]
  public async Task GetAvailableRealmRoleMappingsForUserAsync(string realm)
  {
    var users = await _adminProvider.Users.GetUsersAsync(realm);
    var userId = users.FirstOrDefault()?.Id;
    if(userId != null)
    {
      var result = await _adminProvider.GroupsRoleMapper.GetAvailableRealmRoleMappingsForUserAsync(realm, userId);
      Assert.NotNull(result);
    }
  }

  [Trait("Category", "RoleMapper")]
  [Theory]
  [InlineData("master")]
  public async Task GetEffectiveRealmRoleMappingsForUserAsync(string realm)
  {
    var users = await _adminProvider.Users.GetUsersAsync(realm);
    var userId = users.FirstOrDefault()?.Id;
    if(userId != null)
    {
      var result = await _adminProvider.GroupsRoleMapper.GetEffectiveRealmRoleMappingsForUserAsync(realm, userId);
      Assert.NotNull(result);
    }
  }
}
