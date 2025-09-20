---
title: User Management
description: Learn how to create, update, and manage Keycloak users using <strong>Keycloak Admin</strong>
---

# Overview

User management is a core administrative function in Keycloak that allows you to provision, maintain, and manage user accounts. `Six.KeycloakAdmin` provides comprehensive tools for all aspects of user lifecycle management.

The library provides methods for:

- **Creating** new user accounts with profile information
- **Retrieving** user data with search and filtering capabilities
- **Updating** user profiles and account settings
- **Deleting** user accounts when they're no longer needed
- **Managing** user group memberships and role assignments

# Creating a New User

Creating users is a core administrative function that allows you to provision new accounts in your Keycloak realm. This example shows how to create a basic user with essential profile information and proper validation.

## Basic User Creation

``` csharp
public async Task<string> CreateUserAsync(string realm, string username, string email, string firstName, string lastName)
{
    var provider = await GetAdminProviderAsync();
    
    var newUser = new User
    {
        UserName = username,
        Email = email,
        FirstName = firstName,
        LastName = lastName,
        Enabled = true,
        EmailVerified = true
    };

    // Create user and get the ID
    var userId = await provider.Users.CreateAndRetrieveUserIdAsync(realm, newUser);
    
    if (string.IsNullOrEmpty(userId))
    {
        throw new InvalidOperationException("Failed to create user");
    }

    return userId;
}
```

## Advanced User Creation

``` csharp
public async Task<string> CreateAdvancedUserAsync(string realm, UserCreateRequest request)
{
    var provider = await GetAdminProviderAsync();
    
    var newUser = new User
    {
        UserName = request.Username,
        Email = request.Email,
        FirstName = request.FirstName,
        LastName = request.LastName,
        Enabled = request.Enabled ?? true,
        EmailVerified = request.EmailVerified ?? false,
        RequiredActions = request.RequiredActions?.ToList() ?? new List<string>(),
        Attributes = request.CustomAttributes ?? new Dictionary<string, IEnumerable<string>>(),
        Groups = request.GroupIds?.ToList() ?? new List<string>()
    };

    // Add custom attributes if provided
    if (request.CustomAttributes != null)
    {
        foreach (var attribute in request.CustomAttributes)
        {
            newUser.Attributes[attribute.Key] = attribute.Value;
        }
    }

    var userId = await provider.Users.CreateAndRetrieveUserIdAsync(realm, newUser);
    
    if (string.IsNullOrEmpty(userId))
    {
        throw new InvalidOperationException($"Failed to create user {request.Username}");
    }

    return userId;
}

public class UserCreateRequest
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool? Enabled { get; set; }
    public bool? EmailVerified { get; set; }
    public IEnumerable<string>? RequiredActions { get; set; }
    public Dictionary<string, IEnumerable<string>>? CustomAttributes { get; set; }
    public IEnumerable<string>? GroupIds { get; set; }
}
```

## Bulk User Creation

``` csharp
public async Task<IEnumerable<string>> CreateMultipleUsersAsync(string realm, IEnumerable<UserCreateRequest> users)
{
    var provider = await GetAdminProviderAsync();
    var createdUserIds = new List<string>();
    
    foreach (var userRequest in users)
    {
        try
        {
            var userId = await CreateAdvancedUserAsync(realm, userRequest);
            createdUserIds.Add(userId);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to create user {Username}", userRequest.Username);
            // Continue with other users
        }
    }
    
    return createdUserIds;
}
```

# Retrieving User Information

Retrieving user information is essential for user administration, profile management, and integration with other systems. These methods provide various ways to query user data, from individual lookups to bulk operations with filtering and pagination.

## Get User by ID

``` csharp
public async Task<User> GetUserAsync(string realm, string userId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get user by ID
    var user = await provider.Users.GetUserAsync(realm, userId);
    return user;
}
```

## Get All Users

``` csharp
public async Task<IEnumerable<User>> GetAllUsersAsync(string realm)
{
    var provider = await GetAdminProviderAsync();
    
    // Get all users in realm
    var users = await provider.Users.GetUsersAsync(realm);
    return users;
}
```

## Search and Filter Users

``` csharp
public async Task<IEnumerable<User>> SearchUsersAsync(string realm, string searchTerm)
{
    var provider = await GetAdminProviderAsync();
    
    // Search users by username, email, or name
    var users = await provider.Users.GetUsersAsync(
        realm, 
        q: searchTerm, 
        search: true);
    return users;
}

public async Task<IEnumerable<User>> GetUsersByEmailAsync(string realm, string email)
{
    var provider = await GetAdminProviderAsync();
    
    // Get users by specific email
    var users = await provider.Users.GetUsersAsync(
        realm, 
        email: email, 
        exact: true);
    return users;
}

public async Task<IEnumerable<User>> GetEnabledUsersAsync(string realm)
{
    var provider = await GetAdminProviderAsync();
    
    // Get only enabled users
    var users = await provider.Users.GetUsersAsync(realm, enabled: true);
    return users;
}
```

## Pagination and Performance

``` csharp
public async Task<int> GetUserCountAsync(string realm)
{
    var provider = await GetAdminProviderAsync();
    
    // Get total user count
    var count = await provider.Users.GetUsersCountAsync(realm);
    return count ?? 0;
}

public async Task<IEnumerable<User>> GetUsersInBatchesAsync(string realm, int batchSize = 100)
{
    var provider = await GetAdminProviderAsync();
    var allUsers = new List<User>();
    var first = 0;
    
    while (true)
    {
        var users = await provider.Users.GetUsersAsync(realm, first: first, max: batchSize);
        var userList = users.ToList();
        
        if (!userList.Any())
            break;
            
        allUsers.AddRange(userList);
        first += batchSize;
        
        if (userList.Count < batchSize)
            break;
    }
    
    return allUsers;
}
```

# Updating User Profiles

Updating user profiles allows administrators to modify user information, correct data, or update user status. This is essential for maintaining accurate user records and managing user lifecycle.

## Basic User Update

``` csharp
public async Task<bool> UpdateUserAsync(string realm, string userId, User updatedUser)
{
    var provider = await GetAdminProviderAsync();
    
    // Update existing user
    var success = await provider.Users.UpdateUserAsync(realm, userId, updatedUser);
    return success;
}
```

## Update Specific User Properties

``` csharp
public async Task<bool> UpdateUserProfileAsync(string realm, string userId, string firstName, string lastName, string email)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        // Get existing user
        var existingUser = await provider.Users.GetUserAsync(realm, userId);
        
        // Update properties
        existingUser.FirstName = firstName;
        existingUser.LastName = lastName;
        existingUser.Email = email;
        
        // Save changes
        var success = await provider.Users.UpdateUserAsync(realm, userId, existingUser);
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to update user profile for user {UserId}", userId);
        throw;
    }
}

public async Task<bool> UpdateUserStatusAsync(string realm, string userId, bool enabled)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        var existingUser = await provider.Users.GetUserAsync(realm, userId);
        existingUser.Enabled = enabled;
        
        var success = await provider.Users.UpdateUserAsync(realm, userId, existingUser);
        
        if (success)
        {
            var status = enabled ? "enabled" : "disabled";
            _logger.LogInformation("User {UserId} {Status} in realm {Realm}", userId, status, realm);
        }
        
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to update user status for user {UserId}", userId);
        throw;
    }
}
```

## Bulk User Updates

``` csharp
public async Task<IEnumerable<string>> UpdateMultipleUsersAsync(
    string realm, 
    IEnumerable<string> userIds, 
    Action<User> updateAction)
{
    var provider = await GetAdminProviderAsync();
    var updatedUserIds = new List<string>();
    
    foreach (var userId in userIds)
    {
        try
        {
            var user = await provider.Users.GetUserAsync(realm, userId);
            updateAction(user);
            
            var success = await provider.Users.UpdateUserAsync(realm, userId, user);
            if (success)
            {
                updatedUserIds.Add(userId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to update user {UserId}", userId);
        }
    }
    
    return updatedUserIds;
}

// Example usage: Enable all users in a group
public async Task EnableUsersInGroupAsync(string realm, string groupId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get all users in the group
    var groupUsers = await provider.Groups.GetGroupMembersAsync(realm, groupId);
    var userIds = groupUsers.Select(u => u.Id);
    
    // Enable all users in the group
    await UpdateMultipleUsersAsync(realm, userIds, user => user.Enabled = true);
}
```

# Deleting Users

Removing users who are no longer active or have left the organization helps maintain data hygiene and security. This operation permanently removes the user account and all associated data.

## Basic User Deletion

``` csharp
public async Task<bool> DeleteUserAsync(string realm, string userId)
{
    var provider = await GetAdminProviderAsync();
    
    // Delete user
    var success = await provider.Users.DeleteUserAsync(realm, userId);
    return success;
}
```

## Safe User Deletion

``` csharp
public async Task<bool> DeleteUserSafelyAsync(string realm, string userId)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        // First, get the user to check if they exist
        var user = await provider.Users.GetUserAsync(realm, userId);
        
        if (user == null)
        {
            _logger.LogWarning("User {UserId} not found in realm {Realm}", userId, realm);
            return false;
        }
        
        // Check if user is enabled
        if (user.Enabled == true)
        {
            _logger.LogWarning("Attempting to delete enabled user {UserId}", userId);
        }
        
        // Delete the user
        var success = await provider.Users.DeleteUserAsync(realm, userId);
        
        if (success)
        {
            _logger.LogInformation("Successfully deleted user {UserId} from realm {Realm}", userId, realm);
        }
        
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to delete user {UserId} from realm {Realm}", userId, realm);
        throw;
    }
}
```

## Bulk User Deletion

``` csharp
public async Task<IEnumerable<string>> DeleteMultipleUsersAsync(string realm, IEnumerable<string> userIds)
{
    var provider = await GetAdminProviderAsync();
    var deletedUserIds = new List<string>();
    
    foreach (var userId in userIds)
    {
        try
        {
            var success = await provider.Users.DeleteUserAsync(realm, userId);
            if (success)
            {
                deletedUserIds.Add(userId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to delete user {UserId}", userId);
        }
    }
    
    return deletedUserIds;
}
```

# User Groups and Roles

Managing user group memberships and role assignments is crucial for implementing proper access control and organizational structure. These operations allow you to organize users into logical groups and assign appropriate permissions.

## Group Management

``` csharp
public async Task<IEnumerable<Group>> GetUserGroupsAsync(string realm, string userId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get groups that user belongs to
    var groups = await provider.Users.GetUserGroupsAsync(realm, userId);
    return groups;
}

public async Task<bool> AddUserToGroupAsync(string realm, string userId, string groupId)
{
    var provider = await GetAdminProviderAsync();
    
    // Add user to group
    var success = await provider.Users.AddUserToGroupAsync(realm, userId, groupId);
    return success;
}

public async Task<bool> RemoveUserFromGroupAsync(string realm, string userId, string groupId)
{
    var provider = await GetAdminProviderAsync();
    
    // Remove user from group
    var success = await provider.Users.RemoveUserFromGroupAsync(realm, userId, groupId);
    return success;
}

public async Task<int> GetUserGroupsCountAsync(string realm, string userId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get count of groups user belongs to
    var count = await provider.Users.GetUserGroupsCountAsync(realm, userId);
    return count ?? 0;
}
```

## Role Management

``` csharp
public async Task<bool> AssignRoleToUserAsync(string realm, string clientId, string userId, string roleName)
{
    var provider = await GetAdminProviderAsync();
    
    // Get the role first
    var role = await provider.Roles.GetRoleByNameAsync(realm, clientId, roleName);
    
    // Assign role to user
    var success = await provider.Roles.AddRoleToUserAsync(realm, clientId, userId, new[] { role });
    return success;
}

public async Task<bool> RemoveRoleFromUserAsync(string realm, string clientId, string userId, string roleName)
{
    var provider = await GetAdminProviderAsync();
    
    // Get the role first
    var role = await provider.Roles.GetRoleByNameAsync(realm, clientId, roleName);
    
    // Remove role from user
    var success = await provider.Roles.RemoveRoleFromUserAsync(realm, clientId, userId, new[] { role });
    return success;
}

public async Task<IEnumerable<Role>> GetUserRolesAsync(string realm, string clientId, string userId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get all roles assigned to a user
    var roles = await provider.Roles.GetUsersWithRoleNameAsync(realm, clientId, roleName);
    return roles;
}
```

# Complete User Management Service

This comprehensive example demonstrates how to build a complete user management service that handles all aspects of user lifecycle management.

``` csharp
public class KeycloakUserService
{
    private readonly IKeycloakAdminService _keycloakService;
    private readonly string _realm;
    private readonly ILogger<KeycloakUserService> _logger;

    public KeycloakUserService(
        IKeycloakAdminService keycloakService, 
        string realm,
        ILogger<KeycloakUserService> logger)
    {
        _keycloakService = keycloakService;
        _realm = realm;
        _logger = logger;
    }

    public async Task<string> CreateUserWithRoleAsync(
        string username, 
        string email, 
        string firstName, 
        string lastName, 
        string clientId, 
        string roleName)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            // 1. Create user
            var newUser = new User
            {
                UserName = username,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Enabled = true,
                EmailVerified = true
            };

            var userId = await provider.Users.CreateAndRetrieveUserIdAsync(_realm, newUser);
            
            if (string.IsNullOrEmpty(userId))
            {
                throw new InvalidOperationException("Failed to create user");
            }

            // 2. Assign role to user
            var role = await provider.Roles.GetRoleByNameAsync(_realm, clientId, roleName);
            if (role != null)
            {
                await provider.Roles.AddRoleToUserAsync(_realm, clientId, userId, new[] { role });
            }

            _logger.LogInformation("Successfully created user {Username} with role {RoleName}", username, roleName);
            return userId;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create user with role: {Message}", ex.Message);
            throw new InvalidOperationException($"Failed to create user with role: {ex.Message}", ex);
        }
    }

    public async Task<bool> UpdateUserProfileAsync(string userId, string firstName, string lastName, string email)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            // Get existing user
            var existingUser = await provider.Users.GetUserAsync(_realm, userId);
            
            // Update properties
            existingUser.FirstName = firstName;
            existingUser.LastName = lastName;
            existingUser.Email = email;
            
            // Save changes
            var success = await provider.Users.UpdateUserAsync(_realm, userId, existingUser);
            
            if (success)
            {
                _logger.LogInformation("Successfully updated profile for user {UserId}", userId);
            }
            
            return success;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update user profile: {Message}", ex.Message);
            throw new InvalidOperationException($"Failed to update user profile: {ex.Message}", ex);
        }
    }

    public async Task<bool> DeactivateUserAsync(string userId)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            // Get existing user
            var existingUser = await provider.Users.GetUserAsync(_realm, userId);
            
            // Disable user
            existingUser.Enabled = false;
            
            // Save changes
            var success = await provider.Users.UpdateUserAsync(_realm, userId, existingUser);
            
            if (success)
            {
                _logger.LogInformation("Successfully deactivated user {UserId}", userId);
            }
            
            return success;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to deactivate user: {Message}", ex.Message);
            throw new InvalidOperationException($"Failed to deactivate user: {ex.Message}", ex);
        }
    }

    public async Task<bool> ReactivateUserAsync(string userId)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var existingUser = await provider.Users.GetUserAsync(_realm, userId);
            existingUser.Enabled = true;
            
            var success = await provider.Users.UpdateUserAsync(_realm, userId, existingUser);
            
            if (success)
            {
                _logger.LogInformation("Successfully reactivated user {UserId}", userId);
            }
            
            return success;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to reactivate user: {Message}", ex.Message);
            throw new InvalidOperationException($"Failed to reactivate user: {ex.Message}", ex);
        }
    }
}
```
