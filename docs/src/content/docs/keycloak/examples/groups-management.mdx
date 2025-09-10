---
title: Groups Management
description: Learn how to create, configure, and manage Keycloak groups using Keycloak Admin
---

# Overview

Group management in Keycloak provides a powerful way to organize users into logical collections and apply permissions at scale. `Six.KeycloakAdmin` offers comprehensive tools for creating, managing, and organizing groups to simplify user administration and access control.

The library provides methods for:

- **Creating** new groups with hierarchical structures
- **Retrieving** group information and member lists
- **Updating** group properties and configurations
- **Deleting** groups that are no longer needed
- **Managing** group memberships and role assignments

# Creating Groups

Creating groups allows you to organize users into logical collections that can be used for bulk operations, permission management, and organizational structure. Groups can be hierarchical, enabling complex organizational models.

## Basic Group Creation

``` csharp
public async Task<string> CreateGroupAsync(string realm, string groupName, string description = "")
{
    var provider = await GetAdminProviderAsync();
    
    var newGroup = new Group
    {
        Name = groupName,
        Description = description
    };

    // Create group and get the ID
    var groupId = await provider.Groups.CreateAndRetrieveGroupIdAsync(realm, newGroup);
    
    if (string.IsNullOrEmpty(groupId))
    {
        throw new InvalidOperationException("Failed to create group");
    }

    return groupId;
}
```

## Advanced Group Configuration

``` csharp
public async Task<string> CreateAdvancedGroupAsync(string realm, GroupCreateRequest request)
{
    var provider = await GetAdminProviderAsync();
    
    var newGroup = new Group
    {
        Name = request.Name,
        Description = request.Description,
        Attributes = request.CustomAttributes ?? new Dictionary<string, IEnumerable<string>>()
    };

    // Add custom attributes if provided
    if (request.CustomAttributes != null)
    {
        foreach (var attribute in request.CustomAttributes)
        {
            newGroup.Attributes[attribute.Key] = attribute.Value;
        }
    }

    var groupId = await provider.Groups.CreateAndRetrieveGroupIdAsync(realm, newGroup);
    
    if (string.IsNullOrEmpty(groupId))
    {
        throw new InvalidOperationException($"Failed to create group {request.Name}");
    }

    return groupId;
}

public class GroupCreateRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Dictionary<string, IEnumerable<string>>? CustomAttributes { get; set; }
    public string? ParentGroupId { get; set; }
}
```

## Hierarchical Group Structure

``` csharp
public async Task<string> CreateSubgroupAsync(string realm, string parentGroupId, string subgroupName, string description = "")
{
    var provider = await GetAdminProviderAsync();
    
    var newSubgroup = new Group
    {
        Name = subgroupName,
        Description = description,
        ParentId = parentGroupId
    };

    var subgroupId = await provider.Groups.CreateAndRetrieveGroupIdAsync(realm, newSubgroup);
    
    if (string.IsNullOrEmpty(subgroupId))
    {
        throw new InvalidOperationException("Failed to create subgroup");
    }

    return subgroupId;
}

public async Task<string> CreateDepartmentStructureAsync(string realm, string departmentName)
{
    var provider = await GetAdminProviderAsync();
    
    // Create main department group
    var departmentGroup = new Group
    {
        Name = departmentName,
        Description = $"Main group for {departmentName} department"
    };

    var departmentId = await provider.Groups.CreateAndRetrieveGroupIdAsync(realm, departmentGroup);
    
    if (string.IsNullOrEmpty(departmentId))
    {
        throw new InvalidOperationException($"Failed to create department group {departmentName}");
    }

    // Create common subgroups
    var subgroups = new[] { "Managers", "Employees", "Contractors" };
    
    foreach (var subgroupName in subgroups)
    {
        var subgroup = new Group
        {
            Name = subgroupName,
            Description = $"{subgroupName} within {departmentName}",
            ParentId = departmentId
        };

        await provider.Groups.CreateAndRetrieveGroupIdAsync(realm, subgroup);
    }

    return departmentId;
}
```

# Retrieving Group Information

Retrieving group information is essential for understanding the organizational structure and making informed decisions about group management. These methods provide various ways to query group data.

## Get Group by ID

``` csharp
public async Task<Group> GetGroupAsync(string realm, string groupId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get group by ID
    var group = await provider.Groups.GetGroupAsync(realm, groupId);
    return group;
}
```

## Get All Groups

``` csharp
public async Task<IEnumerable<Group>> GetAllGroupsAsync(string realm)
{
    var provider = await GetAdminProviderAsync();
    
    // Get all groups in realm
    var groups = await provider.Groups.GetGroupsAsync(realm);
    return groups;
}
```

## Search and Filter Groups

``` csharp
public async Task<IEnumerable<Group>> SearchGroupsAsync(string realm, string searchTerm)
{
    var provider = await GetAdminProviderAsync();
    
    // Search groups by name
    var groups = await provider.Groups.GetGroupsAsync(
        realm, 
        q: searchTerm, 
        search: true);
    return groups;
}

public async Task<IEnumerable<Group>> GetGroupsWithPaginationAsync(string realm, int first = 0, int max = 100)
{
    var provider = await GetAdminProviderAsync();
    
    // Get groups with pagination
    var groups = await provider.Groups.GetGroupsAsync(
        realm, 
        first: first, 
        max: max);
    return groups;
}

public async Task<IEnumerable<Group>> GetTopLevelGroupsAsync(string realm)
{
    var provider = await GetAdminProviderAsync();
    
    // Get only top-level groups (no parent)
    var allGroups = await provider.Groups.GetGroupsAsync(realm);
    return allGroups.Where(g => string.IsNullOrEmpty(g.ParentId));
}
```

## Hierarchical Group Navigation

``` csharp
public async Task<IEnumerable<Group>> GetSubgroupsAsync(string realm, string parentGroupId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get all subgroups of a parent group
    var allGroups = await provider.Groups.GetGroupsAsync(realm);
    return allGroups.Where(g => g.ParentId == parentGroupId);
}

public async Task<Group?> GetParentGroupAsync(string realm, string groupId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get the parent group of a specific group
    var group = await provider.Groups.GetGroupAsync(realm, groupId);
    
    if (group?.ParentId != null)
    {
        return await provider.Groups.GetGroupAsync(realm, group.ParentId);
    }
    
    return null;
}

public async Task<IEnumerable<Group>> GetGroupHierarchyAsync(string realm, string groupId)
{
    var provider = await GetAdminProviderAsync();
    
    var hierarchy = new List<Group>();
    var currentGroupId = groupId;
    
    while (!string.IsNullOrEmpty(currentGroupId))
    {
        var group = await provider.Groups.GetGroupAsync(realm, currentGroupId);
        if (group != null)
        {
            hierarchy.Add(group);
            currentGroupId = group.ParentId;
        }
        else
        {
            break;
        }
    }
    
    // Return hierarchy from root to leaf
    hierarchy.Reverse();
    return hierarchy;
}
```

# Updating Group Properties

Modifying existing groups allows you to update group information, change organizational structure, or adjust group configurations without recreating the entire group structure.

## Basic Group Update

``` csharp
public async Task<bool> UpdateGroupAsync(string realm, string groupId, Group updatedGroup)
{
    var provider = await GetAdminProviderAsync();
    
    // Update existing group
    var success = await provider.Groups.UpdateGroupAsync(realm, groupId, updatedGroup);
    return success;
}
```

## Update Specific Group Properties

``` csharp
public async Task<bool> UpdateGroupNameAsync(string realm, string groupId, string newName)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        // Get existing group
        var existingGroup = await provider.Groups.GetGroupAsync(realm, groupId);
        
        // Update name
        existingGroup.Name = newName;
        
        // Save changes
        var success = await provider.Groups.UpdateGroupAsync(realm, groupId, existingGroup);
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to update group name for group {GroupId}", groupId);
        throw;
    }
}

public async Task<bool> UpdateGroupDescriptionAsync(string realm, string groupId, string newDescription)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        var existingGroup = await provider.Groups.GetGroupAsync(realm, groupId);
        existingGroup.Description = newDescription;
        
        var success = await provider.Groups.UpdateGroupAsync(realm, groupId, existingGroup);
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to update group description for group {GroupId}", groupId);
        throw;
    }
}

public async Task<bool> MoveGroupAsync(string realm, string groupId, string newParentGroupId)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        var existingGroup = await provider.Groups.GetGroupAsync(realm, groupId);
        existingGroup.ParentId = newParentGroupId;
        
        var success = await provider.Groups.UpdateGroupAsync(realm, groupId, existingGroup);
        
        if (success)
        {
            _logger.LogInformation("Successfully moved group {GroupId} to new parent {ParentId}", groupId, newParentGroupId);
        }
        
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to move group {GroupId} to new parent {ParentId}", groupId, newParentGroupId);
        throw;
    }
}
```

## Bulk Group Updates

``` csharp
public async Task<IEnumerable<string>> UpdateMultipleGroupsAsync(
    string realm, 
    IEnumerable<string> groupIds, 
    Action<Group> updateAction)
{
    var provider = await GetAdminProviderAsync();
    var updatedGroupIds = new List<string>();
    
    foreach (var groupId in groupIds)
    {
        try
        {
            var group = await provider.Groups.GetGroupAsync(realm, groupId);
            updateAction(group);
            
            var success = await provider.Groups.UpdateGroupAsync(realm, groupId, group);
            if (success)
            {
                updatedGroupIds.Add(groupId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to update group {GroupId}", groupId);
        }
    }
    
    return updatedGroupIds;
}

// Example usage: Update all groups in a department
public async Task UpdateDepartmentGroupsAsync(string realm, string departmentGroupId, string newDescription)
{
    var provider = await GetAdminProviderAsync();
    
    // Get all subgroups of the department
    var subgroups = await GetSubgroupsAsync(realm, departmentGroupId);
    var subgroupIds = subgroups.Select(g => g.Id);
    
    // Update all subgroups with new description
    await UpdateMultipleGroupsAsync(realm, subgroupIds, group => 
    {
        group.Description = $"{group.Description} - {newDescription}";
    });
}
```

# Deleting Groups

Removing groups that are no longer needed helps maintain a clean organizational structure and reduces complexity in your group management system.

## Basic Group Deletion

``` csharp
public async Task<bool> DeleteGroupAsync(string realm, string groupId)
{
    var provider = await GetAdminProviderAsync();
    
    // Delete group
    var success = await provider.Groups.DeleteGroupAsync(realm, groupId);
    return success;
}
```

## Safe Group Deletion

``` csharp
public async Task<bool> DeleteGroupSafelyAsync(string realm, string groupId)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        // First, get the group to check if it exists
        var group = await provider.Groups.GetGroupAsync(realm, groupId);
        
        if (group == null)
        {
            _logger.LogWarning("Group {GroupId} not found in realm {Realm}", groupId, realm);
            return false;
        }
        
        // Check if group has members
        var members = await provider.Groups.GetGroupMembersAsync(realm, groupId);
        if (members.Any())
        {
            _logger.LogWarning("Attempting to delete group {GroupId} with {MemberCount} members", groupId, members.Count());
        }
        
        // Check if group has subgroups
        var subgroups = await GetSubgroupsAsync(realm, groupId);
        if (subgroups.Any())
        {
            _logger.LogWarning("Attempting to delete group {GroupId} with {SubgroupCount} subgroups", groupId, subgroups.Count());
        }
        
        // Delete the group
        var success = await provider.Groups.DeleteGroupAsync(realm, groupId);
        
        if (success)
        {
            _logger.LogInformation("Successfully deleted group {GroupId} from realm {Realm}", groupId, realm);
        }
        
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to delete group {GroupId} from realm {Realm}", groupId, realm);
        throw;
    }
}
```

## Recursive Group Deletion

``` csharp
public async Task<bool> DeleteGroupRecursivelyAsync(string realm, string groupId)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        // Get all subgroups first
        var subgroups = await GetSubgroupsAsync(realm, groupId);
        
        // Delete subgroups recursively
        foreach (var subgroup in subgroups)
        {
            await DeleteGroupRecursivelyAsync(realm, subgroup.Id);
        }
        
        // Now delete the main group
        var success = await provider.Groups.DeleteGroupAsync(realm, groupId);
        
        if (success)
        {
            _logger.LogInformation("Successfully deleted group {GroupId} and all subgroups", groupId);
        }
        
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to delete group {GroupId} recursively", groupId);
        throw;
    }
}
```

# Group Membership Management

Managing group memberships is crucial for organizing users and implementing bulk operations. These methods allow you to add and remove users from groups efficiently.

## Add User to Group

``` csharp
public async Task<bool> AddUserToGroupAsync(string realm, string groupId, string userId)
{
    var provider = await GetAdminProviderAsync();
    
    // Add user to group
    var success = await provider.Users.AddUserToGroupAsync(realm, userId, groupId);
    return success;
}
```

## Remove User from Group

``` csharp
public async Task<bool> RemoveUserFromGroupAsync(string realm, string groupId, string userId)
{
    var provider = await GetAdminProviderAsync();
    
    // Remove user from group
    var success = await provider.Users.RemoveUserFromGroupAsync(realm, userId, groupId);
    return success;
}
```

## Get Group Members

``` csharp
public async Task<IEnumerable<User>> GetGroupMembersAsync(string realm, string groupId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get all users in a group
    var members = await provider.Groups.GetGroupMembersAsync(realm, groupId);
    return members;
}

public async Task<int> GetGroupMemberCountAsync(string realm, string groupId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get count of members in a group
    var count = await provider.Groups.GetGroupMembersCountAsync(realm, groupId);
    return count ?? 0;
}
```

## Bulk Membership Operations

``` csharp
public async Task<bool> AddMultipleUsersToGroupAsync(string realm, string groupId, IEnumerable<string> userIds)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        var successCount = 0;
        
        foreach (var userId in userIds)
        {
            try
            {
                var success = await provider.Users.AddUserToGroupAsync(realm, userId, groupId);
                if (success)
                {
                    successCount++;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to add user {UserId} to group {GroupId}", userId, groupId);
            }
        }
        
        _logger.LogInformation("Successfully added {SuccessCount} out of {TotalCount} users to group {GroupId}", 
            successCount, userIds.Count(), groupId);
        
        return successCount > 0;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to add multiple users to group {GroupId}", groupId);
        throw;
    }
}

public async Task<bool> RemoveMultipleUsersFromGroupAsync(string realm, string groupId, IEnumerable<string> userIds)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        var successCount = 0;
        
        foreach (var userId in userIds)
        {
            try
            {
                var success = await provider.Users.RemoveUserFromGroupAsync(realm, userId, groupId);
                if (success)
                {
                    successCount++;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to remove user {UserId} from group {GroupId}", userId, groupId);
            }
        }
        
        _logger.LogInformation("Successfully removed {SuccessCount} out of {TotalCount} users from group {GroupId}", 
            successCount, userIds.Count(), groupId);
        
        return successCount > 0;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to remove multiple users from group {GroupId}", groupId);
        throw;
    }
}
```

# Group Role Management

Managing roles at the group level allows you to implement efficient permission management where entire groups of users can be granted or denied access to resources.

## Assign Role to Group

``` csharp
public async Task<bool> AssignRoleToGroupAsync(string realm, string clientId, string groupId, string roleName)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        // Get the role first
        var role = await provider.Roles.GetRoleByNameAsync(realm, clientId, roleName);
        
        if (role == null)
        {
            _logger.LogWarning("Role {RoleName} not found in client {ClientId}", roleName, clientId);
            return false;
        }
        
        // Assign role to group
        var success = await provider.Roles.AddRoleToGroupAsync(realm, clientId, groupId, new[] { role });
        
        if (success)
        {
            _logger.LogInformation("Successfully assigned role {RoleName} to group {GroupId}", roleName, groupId);
        }
        
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to assign role {RoleName} to group {GroupId}", roleName, groupId);
        throw;
    }
}
```

## Remove Role from Group

``` csharp
public async Task<bool> RemoveRoleFromGroupAsync(string realm, string clientId, string groupId, string roleName)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        // Get the role first
        var role = await provider.Roles.GetRoleByNameAsync(realm, clientId, roleName);
        
        if (role == null)
        {
            _logger.LogWarning("Role {RoleName} not found in client {ClientId}", roleName, clientId);
            return false;
        }
        
        // Remove role from group
        var success = await provider.Roles.RemoveRoleFromGroupAsync(realm, clientId, groupId, new[] { role });
        
        if (success)
        {
            _logger.LogInformation("Successfully removed role {RoleName} from group {GroupId}", roleName, groupId);
        }
        
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to remove role {RoleName} from group {GroupId}", roleName, groupId);
        throw;
    }
}
```

## Get Group Roles

``` csharp
public async Task<IEnumerable<Role>> GetGroupRolesAsync(string realm, string clientId, string groupId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get all roles assigned to a group
    var roles = await provider.Roles.GetGroupsWithRoleNameAsync(realm, clientId, roleName);
    return roles;
}
```

# Complete Group Management Service

This comprehensive example demonstrates how to build a complete group management service that handles all aspects of group lifecycle management.

``` csharp
public class KeycloakGroupManagementService
{
    private readonly IKeycloakAdminService _keycloakService;
    private readonly ILogger<KeycloakGroupManagementService> _logger;

    public KeycloakGroupManagementService(
        IKeycloakAdminService keycloakService,
        ILogger<KeycloakGroupManagementService> logger)
    {
        _keycloakService = keycloakService;
        _logger = logger;
    }

    public async Task<string> CreateDepartmentGroupAsync(string realm, string departmentName, string description)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var newGroup = new Group
            {
                Name = departmentName,
                Description = description
            };

            var groupId = await provider.Groups.CreateAndRetrieveGroupIdAsync(realm, newGroup);
            
            if (string.IsNullOrEmpty(groupId))
            {
                throw new InvalidOperationException($"Failed to create department group {departmentName}");
            }

            _logger.LogInformation("Successfully created department group {DepartmentName} with ID {GroupId}", departmentName, groupId);
            return groupId;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create department group {DepartmentName}", departmentName);
            throw;
        }
    }

    public async Task<string> CreateSubgroupAsync(string realm, string parentGroupId, string subgroupName, string description)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var newSubgroup = new Group
            {
                Name = subgroupName,
                Description = description,
                ParentId = parentGroupId
            };

            var subgroupId = await provider.Groups.CreateAndRetrieveGroupIdAsync(realm, newSubgroup);
            
            if (string.IsNullOrEmpty(subgroupId))
            {
                throw new InvalidOperationException($"Failed to create subgroup {subgroupName}");
            }

            _logger.LogInformation("Successfully created subgroup {SubgroupName} under parent {ParentId}", subgroupName, parentGroupId);
            return subgroupId;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create subgroup {SubgroupName}", subgroupName);
            throw;
        }
    }

    public async Task<bool> AddUserToGroupAsync(string realm, string groupId, string userId)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var success = await provider.Users.AddUserToGroupAsync(realm, userId, groupId);
            
            if (success)
            {
                _logger.LogInformation("Successfully added user {UserId} to group {GroupId}", userId, groupId);
            }
            
            return success;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add user {UserId} to group {GroupId}", userId, groupId);
            throw;
        }
    }

    public async Task<bool> RemoveUserFromGroupAsync(string realm, string groupId, string userId)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var success = await provider.Users.RemoveUserFromGroupAsync(realm, userId, groupId);
            
            if (success)
            {
                _logger.LogInformation("Successfully removed user {UserId} from group {GroupId}", userId, groupId);
            }
            
            return success;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to remove user {UserId} from group {GroupId}", userId, groupId);
            throw;
        }
    }

    public async Task<IEnumerable<User>> GetGroupMembersAsync(string realm, string groupId)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var members = await provider.Groups.GetGroupMembersAsync(realm, groupId);
            return members;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get members for group {GroupId}", groupId);
            throw;
        }
    }

    public async Task<bool> DeleteGroupAsync(string realm, string groupId)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var success = await provider.Groups.DeleteGroupAsync(realm, groupId);
            
            if (success)
            {
                _logger.LogInformation("Successfully deleted group {GroupId}", groupId);
            }
            
            return success;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete group {GroupId}", groupId);
            throw;
        }
    }
}
```
