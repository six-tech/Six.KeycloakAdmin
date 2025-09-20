---
title: Advanced Operations
description: Learn advanced Keycloak operations and complex usage patterns with Keycloak Admin
---

# Overview

Advanced operations in `Six.KeycloakAdmin` cover complex scenarios, bulk operations, and sophisticated permission management patterns. This guide demonstrates how to implement enterprise-grade Keycloak administration features.

Advanced operations include:

- **Bulk Operations** - Managing multiple entities efficiently
- **Complex Permission Structures** - Building sophisticated access control
- **Integration Patterns** - Connecting with external systems
- **Performance Optimization** - Handling large-scale operations
- **Advanced Authentication** - Complex authentication flows

# Bulk Operations

Bulk operations allow you to efficiently manage large numbers of users, groups, or roles simultaneously. This is essential for enterprise environments where you need to perform operations on hundreds or thousands of entities.

## Bulk User Management

``` csharp
public class BulkUserOperations
{
    private readonly IKeycloakAdminService _keycloakService;
    private readonly ILogger<BulkUserOperations> _logger;

    public BulkUserOperations(IKeycloakAdminService keycloakService, ILogger<BulkUserOperations> logger)
    {
        _keycloakService = keycloakService;
        _logger = logger;
    }

    public async Task<BulkOperationResult> CreateUsersFromCsvAsync(string realm, string csvContent)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        var result = new BulkOperationResult();
        
        try
        {
            var lines = csvContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var headers = lines[0].Split(',');
            
            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                var userData = new Dictionary<string, string>();
                
                for (int j = 0; j < headers.Length && j < values.Length; j++)
                {
                    userData[headers[j].Trim()] = values[j].Trim();
                }
                
                try
                {
                    var user = new User
                    {
                        UserName = userData["username"],
                        Email = userData["email"],
                        FirstName = userData["firstName"],
                        LastName = userData["lastName"],
                        Enabled = true,
                        EmailVerified = false
                    };
                    
                    var userId = await provider.Users.CreateAndRetrieveUserIdAsync(realm, user);
                    result.SuccessfulOperations.Add($"Created user: {user.UserName} (ID: {userId})");
                }
                catch (Exception ex)
                {
                    var error = $"Failed to create user {userData.GetValueOrDefault("username", "unknown")}: {ex.Message}";
                    result.FailedOperations.Add(error);
                    _logger.LogWarning(ex, "Failed to create user from CSV line {LineNumber}", i + 1);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to process CSV content");
            throw;
        }
        
        return result;
    }

    public async Task<BulkOperationResult> UpdateUsersInBulkAsync(
        string realm, 
        IEnumerable<string> userIds, 
        Action<User> updateAction)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        var result = new BulkOperationResult();
        
        foreach (var userId in userIds)
        {
            try
            {
                var user = await provider.Users.GetUserAsync(realm, userId);
                updateAction(user);
                
                var success = await provider.Users.UpdateUserAsync(realm, userId, user);
                if (success)
                {
                    result.SuccessfulOperations.Add($"Updated user: {userId}");
                }
                else
                {
                    result.FailedOperations.Add($"Failed to update user: {userId}");
                }
            }
            catch (Exception ex)
            {
                var error = $"Failed to update user {userId}: {ex.Message}";
                result.FailedOperations.Add(error);
                _logger.LogWarning(ex, "Failed to update user {UserId}", userId);
            }
        }
        
        return result;
    }

    public async Task<BulkOperationResult> DeleteUsersInBulkAsync(string realm, IEnumerable<string> userIds)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        var result = new BulkOperationResult();
        
        foreach (var userId in userIds)
        {
            try
            {
                var success = await provider.Users.DeleteUserAsync(realm, userId);
                if (success)
                {
                    result.SuccessfulOperations.Add($"Deleted user: {userId}");
                }
                else
                {
                    result.FailedOperations.Add($"Failed to delete user: {userId}");
                }
            }
            catch (Exception ex)
            {
                var error = $"Failed to delete user {userId}: {ex.Message}";
                result.FailedOperations.Add(error);
                _logger.LogWarning(ex, "Failed to delete user {UserId}", userId);
            }
        }
        
        return result;
    }
}

public class BulkOperationResult
{
    public List<string> SuccessfulOperations { get; set; } = new();
    public List<string> FailedOperations { get; set; } = new();
    public int TotalOperations => SuccessfulOperations.Count + FailedOperations.Count;
    public bool HasFailures => FailedOperations.Any();
}
```

## Bulk Role Management

``` csharp
public class BulkRoleOperations
{
    private readonly IKeycloakAdminService _keycloakService;
    private readonly ILogger<BulkRoleOperations> _logger;

    public BulkRoleOperations(IKeycloakAdminService keycloakService, ILogger<BulkRoleOperations> logger)
    {
        _keycloakService = keycloakService;
        _logger = logger;
    }

    public async Task<BulkOperationResult> CreateRolesFromTemplateAsync(
        string realm, 
        string clientId, 
        IEnumerable<RoleTemplate> templates)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        var result = new BulkOperationResult();
        
        foreach (var template in templates)
        {
            try
            {
                var role = new Role
                {
                    Name = template.Name,
                    Description = template.Description,
                    Composite = template.IsComposite ?? false,
                    ClientRole = true,
                    ContainerId = clientId
                };
                
                var success = await provider.Roles.CreateRoleAsync(realm, clientId, role);
                if (success)
                {
                    result.SuccessfulOperations.Add($"Created role: {template.Name}");
                    
                    // Add composite roles if specified
                    if (template.IsComposite == true && template.CompositeRoles?.Any() == true)
                    {
                        var compositeRoles = new List<Role>();
                        foreach (var compositeRoleName in template.CompositeRoles)
                        {
                            var compositeRole = await provider.Roles.GetRoleByNameAsync(realm, clientId, compositeRoleName);
                            if (compositeRole != null)
                            {
                                compositeRoles.Add(compositeRole);
                            }
                        }
                        
                        if (compositeRoles.Any())
                        {
                            await provider.Roles.AddCompositesToRoleAsync(realm, clientId, template.Name, compositeRoles);
                        }
                    }
                }
                else
                {
                    result.FailedOperations.Add($"Failed to create role: {template.Name}");
                }
            }
            catch (Exception ex)
            {
                var error = $"Failed to create role {template.Name}: {ex.Message}";
                result.FailedOperations.Add(error);
                _logger.LogWarning(ex, "Failed to create role {RoleName}", template.Name);
            }
        }
        
        return result;
    }

    public async Task<BulkOperationResult> AssignRolesToUsersAsync(
        string realm, 
        string clientId, 
        IEnumerable<UserRoleAssignment> assignments)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        var result = new BulkOperationResult();
        
        foreach (var assignment in assignments)
        {
            try
            {
                var role = await provider.Roles.GetRoleByNameAsync(realm, clientId, assignment.RoleName);
                if (role == null)
                {
                    result.FailedOperations.Add($"Role not found: {assignment.RoleName}");
                    continue;
                }
                
                var success = await provider.Roles.AddRoleToUserAsync(realm, clientId, assignment.UserId, new[] { role });
                if (success)
                {
                    result.SuccessfulOperations.Add($"Assigned role {assignment.RoleName} to user {assignment.UserId}");
                }
                else
                {
                    result.FailedOperations.Add($"Failed to assign role {assignment.RoleName} to user {assignment.UserId}");
                }
            }
            catch (Exception ex)
            {
                var error = $"Failed to assign role {assignment.RoleName} to user {assignment.UserId}: {ex.Message}";
                result.FailedOperations.Add(error);
                _logger.LogWarning(ex, "Failed to assign role to user");
            }
        }
        
        return result;
    }
}

public class RoleTemplate
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool? IsComposite { get; set; }
    public IEnumerable<string>? CompositeRoles { get; set; }
}

public class UserRoleAssignment
{
    public string UserId { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
}
```

# Complex Permission Structures

Building complex permission structures allows you to implement sophisticated access control models that can handle enterprise requirements for fine-grained permissions and hierarchical access control.

## Hierarchical Role System

``` csharp
public class HierarchicalRoleManager
{
    private readonly IKeycloakAdminService _keycloakService;
    private readonly ILogger<HierarchicalRoleManager> _logger;

    public HierarchicalRoleManager(IKeycloakAdminService keycloakService, ILogger<HierarchicalRoleManager> logger)
    {
        _keycloakService = keycloakService;
        _logger = logger;
    }

    public async Task<bool> CreateRoleHierarchyAsync(
        string realm, 
        string clientId, 
        RoleHierarchyNode rootNode)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            // Create root role
            var rootRole = new Role
            {
                Name = rootNode.Name,
                Description = rootNode.Description,
                Composite = true,
                ClientRole = true,
                ContainerId = clientId
            };
            
            var success = await provider.Roles.CreateRoleAsync(realm, clientId, rootRole);
            if (!success)
            {
                throw new InvalidOperationException($"Failed to create root role {rootNode.Name}");
            }
            
            // Create child roles recursively
            await CreateChildRolesAsync(realm, clientId, rootNode.Name, rootNode.Children);
            
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create role hierarchy");
            throw;
        }
    }

    private async Task CreateChildRolesAsync(
        string realm, 
        string clientId, 
        string parentRoleName, 
        IEnumerable<RoleHierarchyNode> children)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        foreach (var child in children)
        {
            try
            {
                var childRole = new Role
                {
                    Name = child.Name,
                    Description = child.Description,
                    Composite = child.Children?.Any() == true,
                    ClientRole = true,
                    ContainerId = clientId
                };
                
                var success = await provider.Roles.CreateRoleAsync(realm, clientId, childRole);
                if (success)
                {
                    // Add child role to parent
                    var parentRole = await provider.Roles.GetRoleByNameAsync(realm, clientId, parentRoleName);
                    var childRoleObj = await provider.Roles.GetRoleByNameAsync(realm, clientId, child.Name);
                    
                    if (parentRole != null && childRoleObj != null)
                    {
                        await provider.Roles.AddCompositesToRoleAsync(realm, clientId, parentRoleName, new[] { childRoleObj });
                    }
                    
                    // Create grandchildren recursively
                    if (child.Children?.Any() == true)
                    {
                        await CreateChildRolesAsync(realm, clientId, child.Name, child.Children);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to create child role {ChildName}", child.Name);
            }
        }
    }

    public async Task<IEnumerable<Role>> GetRoleHierarchyAsync(string realm, string clientId, string roleName)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var role = await provider.Roles.GetRoleByNameAsync(realm, clientId, roleName);
            if (role == null || role.Composite != true)
            {
                return Enumerable.Empty<Role>();
            }
            
            var compositeRoles = await provider.Roles.GetRoleCompositesAsync(realm, clientId, roleName);
            var hierarchy = new List<Role> { role };
            
            foreach (var compositeRole in compositeRoles)
            {
                var subHierarchy = await GetRoleHierarchyAsync(realm, clientId, compositeRole.Name);
                hierarchy.AddRange(subHierarchy);
            }
            
            return hierarchy;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get role hierarchy for {RoleName}", roleName);
            throw;
        }
    }
}

public class RoleHierarchyNode
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IEnumerable<RoleHierarchyNode>? Children { get; set; }
}
```

## Dynamic Permission Builder

``` csharp
public class DynamicPermissionBuilder
{
    private readonly IKeycloakAdminService _keycloakService;
    private readonly ILogger<DynamicPermissionBuilder> _logger;

    public DynamicPermissionBuilder(IKeycloakAdminService keycloakService, ILogger<DynamicPermissionBuilder> logger)
    {
        _keycloakService = keycloakService;
        _logger = logger;
    }

    public async Task<bool> CreateResourceBasedPermissionsAsync(
        string realm, 
        string clientId, 
        ResourcePermissionDefinition definition)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            // Create resource
            var resource = new AuthorizationResource
            {
                Name = definition.ResourceName,
                DisplayName = definition.ResourceDisplayName,
                Type = definition.ResourceType,
                Uri = definition.ResourceUri,
                Scopes = definition.Scopes?.Select(s => new AuthorizationScope { Name = s }).ToArray()
            };
            
            var resourceId = await provider.Clients.CreateAuthorizationResourceAsync(realm, clientId, resource);
            
            // Create permission
            var permission = new AuthorizationPermission
            {
                Name = definition.PermissionName,
                Type = "resource",
                Logic = "POSITIVE",
                DecisionStrategy = "UNANIMOUS",
                Resources = new[] { resourceId },
                Scopes = definition.Scopes?.Select(s => new AuthorizationScope { Name = s }).ToArray()
            };
            
            var permissionId = await provider.Clients.CreateAuthorizationPermissionAsync(realm, clientId, permission);
            
            // Create role for this permission
            var role = new Role
            {
                Name = $"{definition.PermissionName}_role",
                Description = $"Role for {definition.PermissionName} permission",
                ClientRole = true,
                ContainerId = clientId
            };
            
            var success = await provider.Roles.CreateRoleAsync(realm, clientId, role);
            
            return success;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create resource-based permissions");
            throw;
        }
    }
}

public class ResourcePermissionDefinition
{
    public string ResourceName { get; set; } = string.Empty;
    public string ResourceDisplayName { get; set; } = string.Empty;
    public string ResourceType { get; set; } = string.Empty;
    public string ResourceUri { get; set; } = string.Empty;
    public string PermissionName { get; set; } = string.Empty;
    public IEnumerable<string>? Scopes { get; set; }
}
```

# Integration Patterns

Integration patterns demonstrate how to connect `Six.KeycloakAdmin` with external systems, implement event-driven architectures, and build comprehensive identity management solutions.

## Event-Driven User Synchronization

``` csharp
public class UserSynchronizationService
{
    private readonly IKeycloakAdminService _keycloakService;
    private readonly ILogger<UserSynchronizationService> _logger;
    private readonly IEventBus _eventBus;

    public UserSynchronizationService(
        IKeycloakAdminService keycloakService, 
        ILogger<UserSynchronizationService> logger,
        IEventBus eventBus)
    {
        _keycloakService = keycloakService;
        _logger = logger;
        _eventBus = eventBus;
    }

    public async Task SynchronizeUsersFromExternalSystemAsync(string realm, string externalSystemId)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            // Get users from external system
            var externalUsers = await GetExternalUsersAsync(externalSystemId);
            
            // Get existing Keycloak users
            var existingUsers = await provider.Users.GetUsersAsync(realm);
            var existingUserMap = existingUsers.ToDictionary(u => u.UserName, u => u);
            
            foreach (var externalUser in externalUsers)
            {
                try
                {
                    if (existingUserMap.TryGetValue(externalUser.UserName, out var existingUser))
                    {
                        // Update existing user
                        await UpdateUserFromExternalAsync(provider, realm, existingUser, externalUser);
                        await _eventBus.PublishAsync(new UserUpdatedEvent
                        {
                            UserId = existingUser.Id,
                            ExternalSystemId = externalSystemId,
                            Timestamp = DateTime.UtcNow
                        });
                    }
                    else
                    {
                        // Create new user
                        var newUser = new User
                        {
                            UserName = externalUser.UserName,
                            Email = externalUser.Email,
                            FirstName = externalUser.FirstName,
                            LastName = externalUser.LastName,
                            Enabled = externalUser.IsActive,
                            EmailVerified = false,
                            Attributes = new Dictionary<string, IEnumerable<string>>
                            {
                                ["external_system_id"] = new[] { externalSystemId },
                                ["external_user_id"] = new[] { externalUser.ExternalId }
                            }
                        };
                        
                        var userId = await provider.Users.CreateAndRetrieveUserIdAsync(realm, newUser);
                        
                        await _eventBus.PublishAsync(new UserCreatedEvent
                        {
                            UserId = userId,
                            ExternalSystemId = externalSystemId,
                            ExternalUserId = externalUser.ExternalId,
                            Timestamp = DateTime.UtcNow
                        });
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to synchronize user {Username}", externalUser.UserName);
                    
                    await _eventBus.PublishAsync(new UserSynchronizationFailedEvent
                    {
                        ExternalSystemId = externalSystemId,
                        ExternalUserId = externalUser.ExternalId,
                        Error = ex.Message,
                        Timestamp = DateTime.UtcNow
                    });
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to synchronize users from external system {SystemId}", externalSystemId);
            throw;
        }
    }

    private async Task UpdateUserFromExternalAsync(
        IKeycloakAdminProvider provider, 
        string realm, 
        User existingUser, 
        ExternalUser externalUser)
    {
        // Update user properties
        existingUser.FirstName = externalUser.FirstName;
        existingUser.LastName = externalUser.LastName;
        existingUser.Email = externalUser.Email;
        existingUser.Enabled = externalUser.IsActive;
        
        // Update external system attributes
        if (existingUser.Attributes == null)
        {
            existingUser.Attributes = new Dictionary<string, IEnumerable<string>>();
        }
        
        existingUser.Attributes["external_system_id"] = new[] { externalUser.ExternalSystemId };
        existingUser.Attributes["external_user_id"] = new[] { externalUser.ExternalId };
        existingUser.Attributes["last_sync"] = new[] { DateTime.UtcNow.ToString("O") };
        
        await provider.Users.UpdateUserAsync(realm, existingUser.Id, existingUser);
    }

    private async Task<IEnumerable<ExternalUser>> GetExternalUsersAsync(string externalSystemId)
    {
        // Implementation would depend on the external system
        // This is a placeholder for demonstration
        return await Task.FromResult(Enumerable.Empty<ExternalUser>());
    }
}

public class ExternalUser
{
    public string ExternalId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string ExternalSystemId { get; set; } = string.Empty;
}

public interface IEventBus
{
    Task PublishAsync<T>(T @event) where T : class;
}

public class UserCreatedEvent
{
    public string UserId { get; set; } = string.Empty;
    public string ExternalSystemId { get; set; } = string.Empty;
    public string ExternalUserId { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}

public class UserUpdatedEvent
{
    public string UserId { get; set; } = string.Empty;
    public string ExternalSystemId { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}

public class UserSynchronizationFailedEvent
{
    public string ExternalSystemId { get; set; } = string.Empty;
    public string ExternalUserId { get; set; } = string.Empty;
    public string Error { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}
```

## Webhook Integration

``` csharp
public class KeycloakWebhookService
{
    private readonly IKeycloakAdminService _keycloakService;
    private readonly ILogger<KeycloakWebhookService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public KeycloakWebhookService(
        IKeycloakAdminService keycloakService, 
        ILogger<KeycloakWebhookService> logger,
        IHttpClientFactory httpClientFactory)
    {
        _keycloakService = keycloakService;
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public async Task NotifyUserChangesAsync(string realm, string userId, string operation, User user)
    {
        try
        {
            var webhookUrl = Environment.GetEnvironmentVariable("KEYCLOAK_WEBHOOK_URL");
            if (string.IsNullOrEmpty(webhookUrl))
            {
                return;
            }
            
            var webhookData = new
            {
                Event = operation,
                Realm = realm,
                UserId = userId,
                UserName = user.UserName,
                Email = user.Email,
                Timestamp = DateTime.UtcNow,
                UserData = new
                {
                    user.FirstName,
                    user.LastName,
                    user.Enabled,
                    user.EmailVerified
                }
            };
            
            var httpClient = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(webhookData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await httpClient.PostAsync(webhookUrl, content);
            
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Webhook notification failed with status {StatusCode}", response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send webhook notification for user {UserId}", userId);
        }
    }
}
```

# Performance Optimization

Performance optimization techniques help you handle large-scale operations efficiently and maintain responsive user experiences even with complex Keycloak environments.

## Batch Processing with Retry Logic

``` csharp
public class BatchProcessor
{
    private readonly IKeycloakAdminService _keycloakService;
    private readonly ILogger<BatchProcessor> _logger;

    public BatchProcessor(IKeycloakAdminService keycloakService, ILogger<BatchProcessor> logger)
    {
        _keycloakService = keycloakService;
        _logger = logger;
    }

    public async Task<BatchProcessingResult<T>> ProcessBatchAsync<T>(
        string realm,
        IEnumerable<T> items,
        Func<IKeycloakAdminProvider, string, T, Task<bool>> operation,
        int batchSize = 50,
        int maxRetries = 3)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        var result = new BatchProcessingResult<T>();
        var batches = items.Chunk(batchSize);
        
        foreach (var batch in batches)
        {
            var batchTasks = batch.Select(async item =>
            {
                var retryCount = 0;
                while (retryCount < maxRetries)
                {
                    try
                    {
                        var success = await operation(provider, realm, item);
                        if (success)
                        {
                            result.SuccessfulItems.Add(item);
                            return;
                        }
                        else
                        {
                            result.FailedItems.Add(new FailedItem<T> { Item = item, Error = "Operation returned false" });
                            return;
                        }
                    }
                    catch (Exception ex) when (retryCount < maxRetries - 1)
                    {
                        retryCount++;
                        _logger.LogWarning(ex, "Retry {RetryCount} failed for item in batch", retryCount);
                        await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, retryCount))); // Exponential backoff
                    }
                    catch (Exception ex)
                    {
                        result.FailedItems.Add(new FailedItem<T> { Item = item, Error = ex.Message });
                        _logger.LogError(ex, "Failed to process item after {RetryCount} retries", retryCount);
                        return;
                    }
                }
            });
            
            await Task.WhenAll(batchTasks);
            
            // Add small delay between batches to avoid overwhelming the system
            await Task.Delay(100);
        }
        
        return result;
    }
}

public class BatchProcessingResult<T>
{
    public List<T> SuccessfulItems { get; set; } = new();
    public List<FailedItem<T>> FailedItems { get; set; } = new();
    public int TotalItems => SuccessfulItems.Count + FailedItems.Count;
    public double SuccessRate => TotalItems > 0 ? (double)SuccessfulItems.Count / TotalItems : 0;
}

public class FailedItem<T>
{
    public T Item { get; set; } = default!;
    public string Error { get; set; } = string.Empty;
}
```

## Connection Pooling and Resource Management

``` csharp
public class OptimizedKeycloakService
{
    private readonly IKeycloakAdminService _keycloakService;
    private readonly ILogger<OptimizedKeycloakService> _logger;
    private readonly SemaphoreSlim _concurrencyLimiter;

    public OptimizedKeycloakService(
        IKeycloakAdminService keycloakService, 
        ILogger<OptimizedKeycloakService> logger)
    {
        _keycloakService = keycloakService;
        _logger = logger;
        _concurrencyLimiter = new SemaphoreSlim(10, 10); // Limit concurrent operations
    }

    public async Task<IEnumerable<User>> GetUsersWithOptimizationAsync(string realm, int maxUsers = 1000)
    {
        await _concurrencyLimiter.WaitAsync();
        
        try
        {
            var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
            
            // Get total count first
            var totalCount = await provider.Users.GetUsersCountAsync(realm) ?? 0;
            
            if (totalCount <= maxUsers)
            {
                // Get all users at once if within limit
                return await provider.Users.GetUsersAsync(realm);
            }
            
            // Process in batches for large user sets
            var allUsers = new List<User>();
            var batchSize = 100;
            var processed = 0;
            
            while (processed < totalCount && processed < maxUsers)
            {
                var batch = await provider.Users.GetUsersAsync(realm, first: processed, max: batchSize);
                var userList = batch.ToList();
                
                if (!userList.Any())
                    break;
                
                allUsers.AddRange(userList);
                processed += userList.Count;
                
                // Small delay between batches
                if (processed < totalCount && processed < maxUsers)
                {
                    await Task.Delay(50);
                }
            }
            
            return allUsers;
        }
        finally
        {
            _concurrencyLimiter.Release();
        }
    }

    public async Task<bool> UpdateUsersInParallelAsync(
        string realm, 
        IEnumerable<User> users, 
        Action<User> updateAction,
        int maxConcurrency = 5)
    {
        var semaphore = new SemaphoreSlim(maxConcurrency, maxConcurrency);
        var tasks = users.Select(async user =>
        {
            await semaphore.WaitAsync();
            try
            {
                var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
                updateAction(user);
                return await provider.Users.UpdateUserAsync(realm, user.Id, user);
            }
            finally
            {
                semaphore.Release();
            }
        });
        
        var results = await Task.WhenAll(tasks);
        return results.All(r => r);
    }
}
```
