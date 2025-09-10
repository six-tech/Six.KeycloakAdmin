---
title: Role Management
description: Learn how to create, configure, and manage Keycloak roles using Keycloak Admin
---

# Overview

Role management is the foundation of access control in Keycloak. `Six.KeycloakAdmin` provides comprehensive tools for creating, configuring, and managing roles that define what users can access and what operations they can perform.

The library provides methods for:

- **Creating** new roles with custom permissions and descriptions
- **Retrieving** role information and configurations
- **Updating** existing role definitions and properties
- **Deleting** roles that are no longer needed
- **Managing** role assignments and composite role structures

# Creating Client Roles

Creating client-specific roles allows you to define granular permissions for individual applications. This is essential for implementing proper access control where different clients have different permission requirements.

## Basic Role Creation

``` csharp
public async Task<bool> CreateClientRoleAsync(string realm, string clientId, string roleName, string description = "")
{
    var provider = await GetAdminProviderAsync();
    
    var newRole = new Role
    {
        Name = roleName,
        Description = description
    };

    // Create role for specific client
    var success = await provider.Roles.CreateRoleAsync(realm, clientId, newRole);
    return success;
}
```

## Advanced Role Configuration

``` csharp
public async Task<bool> CreateAdvancedRoleAsync(string realm, string clientId, RoleCreateRequest request)
{
    var provider = await GetAdminProviderAsync();
    
    var newRole = new Role
    {
        Name = request.Name,
        Description = request.Description,
        Composite = request.IsComposite ?? false,
        ClientRole = true,
        ContainerId = clientId
    };

    var success = await provider.Roles.CreateRoleAsync(realm, clientId, newRole);
    
    if (success && request.IsComposite == true && request.CompositeRoles?.Any() == true)
    {
        // Add composite roles if specified
        success = await provider.Roles.AddCompositesToRoleAsync(
            realm, clientId, request.Name, request.CompositeRoles);
    }
    
    return success;
}

public class RoleCreateRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool? IsComposite { get; set; }
    public IEnumerable<Role>? CompositeRoles { get; set; }
}
```

## Bulk Role Creation

``` csharp
public async Task<IEnumerable<string>> CreateMultipleRolesAsync(
    string realm, 
    string clientId, 
    IEnumerable<RoleCreateRequest> roles)
{
    var provider = await GetAdminProviderAsync();
    var createdRoleNames = new List<string>();
    
    foreach (var roleRequest in roles)
    {
        try
        {
            var success = await CreateAdvancedRoleAsync(realm, clientId, roleRequest);
            if (success)
            {
                createdRoleNames.Add(roleRequest.Name);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to create role {RoleName}", roleRequest.Name);
        }
    }
    
    return createdRoleNames;
}
```

# Retrieving Role Information

Retrieving role information is essential for understanding the current permission structure and making informed decisions about role assignments. These methods provide different ways to query role data.

## Get All Client Roles

``` csharp
public async Task<IEnumerable<Role>> GetClientRolesAsync(string realm, string clientId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get all roles for a client
    var roles = await provider.Roles.GetRolesAsync(realm, clientId);
    return roles;
}
```

## Get Role by Name

``` csharp
public async Task<Role> GetRoleByNameAsync(string realm, string clientId, string roleName)
{
    var provider = await GetAdminProviderAsync();
    
    // Get specific role by name
    var role = await provider.Roles.GetRoleByNameAsync(realm, clientId, roleName);
    return role;
}
```

## Search and Filter Roles

``` csharp
public async Task<IEnumerable<Role>> SearchRolesAsync(string realm, string clientId, string searchTerm)
{
    var provider = await GetAdminProviderAsync();
    
    // Search roles by name
    var roles = await provider.Roles.GetRolesAsync(
        realm, 
        clientId, 
        search: searchTerm);
    return roles;
}

public async Task<IEnumerable<Role>> GetRolesWithPaginationAsync(
    string realm, 
    string clientId, 
    int first = 0, 
    int max = 100)
{
    var provider = await GetAdminProviderAsync();
    
    // Get roles with pagination
    var roles = await provider.Roles.GetRolesAsync(
        realm, 
        clientId, 
        first: first, 
        max: max);
    return roles;
}
```

# Updating Role Definitions

Modifying existing roles allows you to update role descriptions, change role hierarchies, or adjust role configurations without recreating the entire role structure.

## Basic Role Update

``` csharp
public async Task<bool> UpdateRoleAsync(string realm, string clientId, string roleName, Role updatedRole)
{
    var provider = await GetAdminProviderAsync();
    
    // Update existing role
    var success = await provider.Roles.UpdateRoleByNameAsync(realm, clientId, roleName, updatedRole);
    return success;
}
```

## Update Specific Role Properties

``` csharp
public async Task<bool> UpdateRoleDescriptionAsync(string realm, string clientId, string roleName, string newDescription)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        // Get existing role
        var existingRole = await provider.Roles.GetRoleByNameAsync(realm, clientId, roleName);
        
        // Update description
        existingRole.Description = newDescription;
        
        // Save changes
        var success = await provider.Roles.UpdateRoleByNameAsync(realm, clientId, roleName, existingRole);
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to update role description for role {RoleName}", roleName);
        throw;
    }
}
```

## Bulk Role Updates

``` csharp
public async Task<IEnumerable<string>> UpdateMultipleRolesAsync(
    string realm, 
    string clientId, 
    IEnumerable<string> roleNames, 
    Action<Role> updateAction)
{
    var provider = await GetAdminProviderAsync();
    var updatedRoleNames = new List<string>();
    
    foreach (var roleName in roleNames)
    {
        try
        {
            var role = await provider.Roles.GetRoleByNameAsync(realm, clientId, roleName);
            updateAction(role);
            
            var success = await provider.Roles.UpdateRoleByNameAsync(realm, clientId, roleName, role);
            if (success)
            {
                updatedRoleNames.Add(roleName);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to update role {RoleName}", roleName);
        }
    }
    
    return updatedRoleNames;
}
```

# Deleting Roles

Removing roles that are no longer needed helps maintain a clean permission structure and reduces complexity in your access control system.

## Basic Role Deletion

``` csharp
public async Task<bool> DeleteRoleAsync(string realm, string clientId, string roleName)
{
    var provider = await GetAdminProviderAsync();
    
    // Delete role
    var success = await provider.Roles.DeleteRoleByNameAsync(realm, clientId, roleName);
    return success;
}
```

## Safe Role Deletion

``` csharp
public async Task<bool> DeleteRoleSafelyAsync(string realm, string clientId, string roleName)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        // First, get the role to check if it exists
        var role = await provider.Roles.GetRoleByNameAsync(realm, clientId, roleName);
        
        if (role == null)
        {
            _logger.LogWarning("Role {RoleName} not found in client {ClientId}", roleName, clientId);
            return false;
        }
        
        // Check if role is composite
        if (role.Composite == true)
        {
            _logger.LogWarning("Attempting to delete composite role {RoleName}", roleName);
        }
        
        // Delete the role
        var success = await provider.Roles.DeleteRoleByNameAsync(realm, clientId, roleName);
        
        if (success)
        {
            _logger.LogInformation("Successfully deleted role {RoleName} from client {ClientId}", roleName, clientId);
        }
        
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to delete role {RoleName} from client {ClientId}", roleName, clientId);
        throw;
    }
}
```

# Role Assignment to Users

Role assignment is the core of access control implementation. These methods allow you to grant and revoke permissions by assigning or removing roles from users, enabling fine-grained access control.

## Assign Role to User

``` csharp
public async Task<bool> AssignRoleToUserAsync(string realm, string clientId, string userId, string roleName)
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
        
        // Assign role to user
        var success = await provider.Roles.AddRoleToUserAsync(realm, clientId, userId, new[] { role });
        
        if (success)
        {
            _logger.LogInformation("Successfully assigned role {RoleName} to user {UserId}", roleName, userId);
        }
        
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to assign role {RoleName} to user {UserId}", roleName, userId);
        throw;
    }
}
```

## Remove Role from User

``` csharp
public async Task<bool> RemoveRoleFromUserAsync(string realm, string clientId, string userId, string roleName)
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
        
        // Remove role from user
        var success = await provider.Roles.RemoveRoleFromUserAsync(realm, clientId, userId, new[] { role });
        
        if (success)
        {
            _logger.LogInformation("Successfully removed role {RoleName} from user {UserId}", roleName, userId);
        }
        
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to remove role {RoleName} from user {UserId}", roleName, userId);
        throw;
    }
}
```

## Get User Roles

``` csharp
public async Task<IEnumerable<Role>> GetUserRolesAsync(string realm, string clientId, string userId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get all roles assigned to a user
    var roles = await provider.Roles.GetUsersWithRoleNameAsync(realm, clientId, roleName);
    return roles;
}
```

## Bulk Role Assignment

``` csharp
public async Task<bool> AssignMultipleRolesToUserAsync(
    string realm, 
    string clientId, 
    string userId, 
    IEnumerable<string> roleNames)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        var roles = new List<Role>();
        
        // Get all roles
        foreach (var roleName in roleNames)
        {
            var role = await provider.Roles.GetRoleByNameAsync(realm, clientId, roleName);
            if (role != null)
            {
                roles.Add(role);
            }
        }
        
        if (roles.Any())
        {
            // Assign all roles at once
            var success = await provider.Roles.AddRoleToUserAsync(realm, clientId, userId, roles);
            
            if (success)
            {
                _logger.LogInformation("Successfully assigned {RoleCount} roles to user {UserId}", roles.Count, userId);
            }
            
            return success;
        }
        
        return false;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to assign multiple roles to user {UserId}", userId);
        throw;
    }
}
```

# Composite Roles

Composite roles allow you to build complex permission structures by combining multiple roles. This is powerful for implementing hierarchical permission models where roles can inherit permissions from other roles.

## Creating Composite Roles

``` csharp
public async Task<bool> CreateCompositeRoleAsync(string realm, string clientId, string roleName, IEnumerable<Role> compositeRoles)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        // Create the base role first
        var baseRole = new Role 
        { 
            Name = roleName,
            Composite = true,
            ClientRole = true,
            ContainerId = clientId
        };
        
        var success = await provider.Roles.CreateRoleAsync(realm, clientId, baseRole);
        
        if (success && compositeRoles.Any())
        {
            // Add composite roles
            success = await provider.Roles.AddCompositesToRoleAsync(realm, clientId, roleName, compositeRoles);
            
            if (success)
            {
                _logger.LogInformation("Successfully created composite role {RoleName} with {CompositeCount} composite roles", 
                    roleName, compositeRoles.Count());
            }
        }
        
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to create composite role {RoleName}", roleName);
        throw;
    }
}
```

## Managing Composite Role Components

``` csharp
public async Task<IEnumerable<Role>> GetCompositeRolesAsync(string realm, string clientId, string roleName)
{
    var provider = await GetAdminProviderAsync();
    
    // Get composite roles for a role
    var compositeRoles = await provider.Roles.GetRoleCompositesAsync(realm, clientId, roleName);
    return compositeRoles;
}

public async Task<bool> AddCompositeToRoleAsync(string realm, string clientId, string roleName, IEnumerable<Role> newCompositeRoles)
{
    var provider = await GetAdminProviderAsync();
    
    // Add new composite roles to existing role
    var success = await provider.Roles.AddCompositesToRoleAsync(realm, clientId, roleName, newCompositeRoles);
    return success;
}

public async Task<bool> RemoveCompositeFromRoleAsync(string realm, string clientId, string roleName, IEnumerable<Role> compositeRolesToRemove)
{
    var provider = await GetAdminProviderAsync();
    
    // Remove composite roles from existing role
    var success = await provider.Roles.RemoveCompositesFromRoleAsync(realm, clientId, roleName, compositeRolesToRemove);
    return success;
}
```

## Application and Realm Roles for Composites

``` csharp
public async Task<IEnumerable<Role>> GetApplicationRolesForCompositeAsync(string realm, string clientId, string roleName, string targetClientId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get application roles available for composite
    var roles = await provider.Roles.GetApplicationRolesForCompositeAsync(realm, clientId, roleName, targetClientId);
    return roles;
}

public async Task<IEnumerable<Role>> GetRealmRolesForCompositeAsync(string realm, string clientId, string roleName)
{
    var provider = await GetAdminProviderAsync();
    
    // Get realm roles available for composite
    var roles = await provider.Roles.GetRealmRolesForCompositeAsync(realm, clientId, roleName);
    return roles;
}
```

# Role Analysis and Reporting

Understanding how roles are used across your system is crucial for maintaining a clean access control structure.

## Get Users with Role

``` csharp
public async Task<IEnumerable<User>> GetUsersWithRoleAsync(string realm, string clientId, string roleName)
{
    var provider = await GetAdminProviderAsync();
    
    // Get all users that have a specific role
    var users = await provider.Roles.GetUsersWithRoleNameAsync(realm, clientId, roleName);
    return users;
}
```

## Get Groups with Role

``` csharp
public async Task<IEnumerable<Group>> GetGroupsWithRoleAsync(string realm, string clientId, string roleName)
{
    var provider = await GetAdminProviderAsync();
    
    // Get all groups that have a specific role
    var groups = await provider.Roles.GetGroupsWithRoleNameAsync(realm, clientId, roleName);
    return groups;
}
```

## Role Usage Analysis

``` csharp
public async Task<RoleUsageReport> AnalyzeRoleUsageAsync(string realm, string clientId, string roleName)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        var role = await provider.Roles.GetRoleByNameAsync(realm, clientId, roleName);
        var usersWithRole = await provider.Roles.GetUsersWithRoleNameAsync(realm, clientId, roleName);
        var groupsWithRole = await provider.Roles.GetGroupsWithRoleNameAsync(realm, clientId, roleName);
        var compositeRoles = await provider.Roles.GetRoleCompositesAsync(realm, clientId, roleName);
        
        return new RoleUsageReport
        {
            RoleName = roleName,
            TotalUsers = usersWithRole.Count(),
            TotalGroups = groupsWithRole.Count(),
            CompositeRoles = compositeRoles.Count(),
            IsComposite = role?.Composite ?? false,
            Description = role?.Description ?? string.Empty
        };
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to analyze role usage for {RoleName}", roleName);
        throw;
    }
}

public class RoleUsageReport
{
    public string RoleName { get; set; } = string.Empty;
    public int TotalUsers { get; set; }
    public int TotalGroups { get; set; }
    public int CompositeRoles { get; set; }
    public bool IsComposite { get; set; }
    public string Description { get; set; } = string.Empty;
}
```

# Complete Role Management Service

This comprehensive example demonstrates how to build a complete role management service that handles all aspects of role lifecycle management.

``` csharp
public class KeycloakRoleManagementService
{
    private readonly IKeycloakAdminService _keycloakService;
    private readonly ILogger<KeycloakRoleManagementService> _logger;

    public KeycloakRoleManagementService(
        IKeycloakAdminService keycloakService,
        ILogger<KeycloakRoleManagementService> logger)
    {
        _keycloakService = keycloakService;
        _logger = logger;
    }

    public async Task<bool> CreateRoleWithPermissionsAsync(
        string realm, 
        string clientId, 
        string roleName, 
        string description, 
        bool isComposite = false)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var newRole = new Role
            {
                Name = roleName,
                Description = description,
                Composite = isComposite,
                ClientRole = true,
                ContainerId = clientId
            };

            var success = await provider.Roles.CreateRoleAsync(realm, clientId, newRole);
            
            if (success)
            {
                _logger.LogInformation("Successfully created role {RoleName} in client {ClientId}", roleName, clientId);
            }
            
            return success;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create role {RoleName} in client {ClientId}", roleName, clientId);
            throw;
        }
    }

    public async Task<bool> AssignRoleToUserAsync(string realm, string clientId, string userId, string roleName)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var role = await provider.Roles.GetRoleByNameAsync(realm, clientId, roleName);
            
            if (role == null)
            {
                _logger.LogWarning("Role {RoleName} not found in client {ClientId}", roleName, clientId);
                return false;
            }
            
            var success = await provider.Roles.AddRoleToUserAsync(realm, clientId, userId, new[] { role });
            
            if (success)
            {
                _logger.LogInformation("Successfully assigned role {RoleName} to user {UserId}", roleName, userId);
            }
            
            return success;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to assign role {RoleName} to user {UserId}", roleName, userId);
            throw;
        }
    }

    public async Task<bool> RemoveRoleFromUserAsync(string realm, string clientId, string userId, string roleName)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var role = await provider.Roles.GetRoleByNameAsync(realm, clientId, roleName);
            
            if (role == null)
            {
                _logger.LogWarning("Role {RoleName} not found in client {ClientId}", roleName, clientId);
                return false;
            }
            
            var success = await provider.Roles.RemoveRoleFromUserAsync(realm, clientId, userId, new[] { role });
            
            if (success)
            {
                _logger.LogInformation("Successfully removed role {RoleName} from user {UserId}", roleName, userId);
            }
            
            return success;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to remove role {RoleName} from user {UserId}", roleName, userId);
            throw;
        }
    }

    public async Task<IEnumerable<Role>> GetUserRolesAsync(string realm, string clientId, string userId)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var roles = await provider.Roles.GetUsersWithRoleNameAsync(realm, clientId, roleName);
            return roles;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get roles for user {UserId}", userId);
            throw;
        }
    }
}
```
