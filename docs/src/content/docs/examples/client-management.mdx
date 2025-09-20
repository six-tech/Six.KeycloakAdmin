---
title: Client Management
description: Learn how to create, configure, and manage Keycloak clients using Keycloak Admin
---

# Overview

Client management is a fundamental aspect of Keycloak administration. `Six.KeycloakAdmin` provides comprehensive tools for creating, configuring, and managing OAuth clients, including OpenID Connect applications, service accounts, and confidential clients.

Keycloak clients represent applications that can authenticate users and access resources. The library provides methods for:

- **Creating** new clients with custom configurations
- **Retrieving** client information and settings
- **Updating** existing client configurations
- **Deleting** clients that are no longer needed
- **Managing** client secrets and credentials

# Creating a New Client

Creating a new client in Keycloak is a fundamental operation that sets up an application's identity and authentication configuration. This example shows how to create a typical OpenID Connect client with common settings for web applications.

## Basic Client Creation

``` csharp
public async Task<string> CreateClientAsync(string realm)
{
    var provider = await GetAdminProviderAsync();
    
    var newClient = new Client
    {
        ClientId = "my-application",
        Name = "My Application",
        Enabled = true,
        Protocol = "openid-connect",
        PublicClient = false,
        StandardFlowEnabled = true,
        DirectAccessGrantsEnabled = true,
        ServiceAccountsEnabled = true,
        RedirectUris = new[] { "http://localhost:3000/callback" },
        WebOrigins = new[] { "http://localhost:3000" }
    };

    // Create client and get the ID
    var clientId = await provider.Clients.CreateAndRetrieveClientIdAsync(realm, newClient);
    
    if (string.IsNullOrEmpty(clientId))
    {
        throw new InvalidOperationException("Failed to create client");
    }

    return clientId;
}
```

## Advanced Client Configuration

``` csharp
public async Task<string> CreateAdvancedClientAsync(string realm, string clientId, string clientName)
{
    var provider = await GetAdminProviderAsync();
    
    var newClient = new Client
    {
        ClientId = clientId,
        Name = clientName,
        Enabled = true,
        Protocol = "openid-connect",
        PublicClient = false,
        StandardFlowEnabled = true,
        ImplicitFlowEnabled = false,
        DirectAccessGrantsEnabled = true,
        ServiceAccountsEnabled = true,
        BearerOnly = false,
        ConsentRequired = false,
        FrontChannelLogout = true,
        FullScopeAllowed = true,
        NodeReregistrationTimeout = 0,
        RedirectUris = new[] 
        { 
            "https://app.example.com/callback",
            "https://app.example.com/silent-renew"
        },
        WebOrigins = new[] { "https://app.example.com" },
        Attributes = new Dictionary<string, object>
        {
            ["saml.assertion.signature"] = "false",
            ["saml.force.post.binding"] = "false",
            ["saml.multivalued.roles"] = "false",
            ["saml.encrypt"] = "false",
            ["saml.server.signature"] = "false",
            ["saml.server.signature.keyinfo.ext"] = "false",
            ["exclude.session.state.from.auth.response"] = "false",
            ["saml_force_name_id_format"] = "false",
            ["saml.client.signature"] = "false",
            ["tls.client.certificate.bound.access.tokens"] = "false",
            ["saml.authnstatement"] = "false",
            ["display.on.consent.screen"] = "false",
            ["saml.onetimeuse.condition"] = "false"
        }
    };

    var createdClientId = await provider.Clients.CreateAndRetrieveClientIdAsync(realm, newClient);
    return createdClientId;
}
```

## Service Account Client

``` csharp
public async Task<string> CreateServiceAccountClientAsync(string realm, string clientId)
{
    var provider = await GetAdminProviderAsync();
    
    var serviceAccountClient = new Client
    {
        ClientId = clientId,
        Name = $"{clientId} Service Account",
        Enabled = true,
        Protocol = "openid-connect",
        PublicClient = false,
        StandardFlowEnabled = false,
        ImplicitFlowEnabled = false,
        DirectAccessGrantsEnabled = false,
        ServiceAccountsEnabled = true,
        BearerOnly = false,
        ConsentRequired = false,
        FullScopeAllowed = true
    };

    var createdClientId = await provider.Clients.CreateAndRetrieveClientIdAsync(realm, serviceAccountClient);
    return createdClientId;
}
```

# Retrieving Client Information

Retrieving client information is essential for understanding the current configuration and making informed decisions about client management. These methods provide different ways to query client data, from specific lookups to comprehensive searches.

## Get Client by ID

``` csharp
public async Task<Client> GetClientAsync(string realm, string clientId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get client by ID
    var keycloakClient = await provider.Clients.GetClientAsync(realm, clientId);
    return keycloakClient;
}
```

## Get All Clients

``` csharp
public async Task<IEnumerable<Client>> GetAllClientsAsync(string realm)
{
    var provider = await GetAdminProviderAsync();
    
    // Get all clients in realm
    var clients = await provider.Clients.GetClientsAsync(realm);
    return clients;
}
```

## Search and Filter Clients

``` csharp
public async Task<IEnumerable<Client>> SearchClientsAsync(string realm, string searchTerm)
{
    var provider = await GetAdminProviderAsync();
    
    // Search clients by name or ID
    var clients = await provider.Clients.GetClientsAsync(
        realm, 
        q: searchTerm, 
        search: true);
    return clients;
}

public async Task<IEnumerable<Client>> GetClientsWithPaginationAsync(string realm, int first = 0, int max = 100)
{
    var provider = await GetAdminProviderAsync();
    
    // Get clients with pagination
    var clients = await provider.Clients.GetClientsAsync(
        realm, 
        first: first, 
        max: max);
    return clients;
}

public async Task<IEnumerable<Client>> GetEnabledClientsAsync(string realm)
{
    var provider = await GetAdminProviderAsync();
    
    // Get only enabled clients
    var allClients = await provider.Clients.GetClientsAsync(realm);
    return allClients.Where(c => c.Enabled == true);
}
```

# Updating Client Configuration

Updating client configurations allows you to modify settings, add new redirect URIs, or change authentication flows without recreating the entire client. This is useful for maintaining client configurations as your application evolves.

## Basic Client Update

``` csharp
public async Task<bool> UpdateClientAsync(string realm, string clientId, Client updatedClient)
{
    var provider = await GetAdminProviderAsync();
    
    // Update existing client
    var success = await provider.Clients.UpdateClientAsync(realm, clientId, updatedClient);
    return success;
}
```

## Update Specific Client Properties

``` csharp
public async Task<bool> UpdateClientRedirectUrisAsync(string realm, string clientId, string[] newRedirectUris)
{
    var provider = await GetAdminProviderAsync();
    
    // Get existing client
    var existingClient = await provider.Clients.GetClientAsync(realm, clientId);
    
    // Update redirect URIs
    existingClient.RedirectUris = newRedirectUris;
    
    // Save changes
    var success = await provider.Clients.UpdateClientAsync(realm, clientId, existingClient);
    return success;
}

public async Task<bool> EnableClientAsync(string realm, string clientId)
{
    var provider = await GetAdminProviderAsync();
    
    var existingClient = await provider.Clients.GetClientAsync(realm, clientId);
    existingClient.Enabled = true;
    
    var success = await provider.Clients.UpdateClientAsync(realm, clientId, existingClient);
    return success;
}
```

## Bulk Client Updates

``` csharp
public async Task<IEnumerable<string>> UpdateMultipleClientsAsync(
    string realm, 
    IEnumerable<string> clientIds, 
    Action<Client> updateAction)
{
    var provider = await GetAdminProviderAsync();
    var updatedClientIds = new List<string>();
    
    foreach (var clientId in clientIds)
    {
        try
        {
            var client = await provider.Clients.GetClientAsync(realm, clientId);
            updateAction(client);
            
            var success = await provider.Clients.UpdateClientAsync(realm, clientId, client);
            if (success)
            {
                updatedClientIds.Add(clientId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to update client {ClientId}", clientId);
        }
    }
    
    return updatedClientIds;
}
```

# Deleting Clients

Removing clients that are no longer needed helps maintain a clean Keycloak environment and reduces security risks. This operation permanently removes the client and all associated configurations.

## Basic Client Deletion

``` csharp
public async Task<bool> DeleteClientAsync(string realm, string clientId)
{
    var provider = await GetAdminProviderAsync();
    
    // Delete client
    var success = await provider.Clients.DeleteClientAsync(realm, clientId);
    return success;
}
```

## Safe Client Deletion

``` csharp
public async Task<bool> DeleteClientSafelyAsync(string realm, string clientId)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        // First, get the client to check if it exists
        var client = await provider.Clients.GetClientAsync(realm, clientId);
        
        if (client == null)
        {
            _logger.LogWarning("Client {ClientId} not found in realm {Realm}", clientId, realm);
            return false;
        }
        
        // Check if client is enabled
        if (client.Enabled == true)
        {
            _logger.LogWarning("Attempting to delete enabled client {ClientId}", clientId);
        }
        
        // Delete the client
        var success = await provider.Clients.DeleteClientAsync(realm, clientId);
        
        if (success)
        {
            _logger.LogInformation("Successfully deleted client {ClientId} from realm {Realm}", clientId, realm);
        }
        
        return success;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to delete client {ClientId} from realm {Realm}", clientId, realm);
        throw;
    }
}
```

# Managing Client Secrets

Client secrets are crucial for secure client authentication. These methods allow you to generate new secrets and retrieve existing ones, which is essential for client credential flows and service account authentication.

## Generate New Client Secret

``` csharp
public async Task<string> GenerateNewClientSecretAsync(string realm, string clientId)
{
    var provider = await GetAdminProviderAsync();
    
    // Generate new client secret
    var credentials = await provider.Clients.GenerateClientSecretAsync(realm, clientId);
    return credentials.Value;
}
```

## Get Current Client Secret

``` csharp
public async Task<string> GetCurrentClientSecretAsync(string realm, string clientId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get current client secret
    var credentials = await provider.Clients.GetClientSecretAsync(realm, clientId);
    return credentials.Value;
}
```

## Secret Rotation Strategy

``` csharp
public async Task<string> RotateClientSecretAsync(string realm, string clientId)
{
    var provider = await GetAdminProviderAsync();
    
    try
    {
        // Generate new secret
        var newSecret = await provider.Clients.GenerateClientSecretAsync(realm, clientId);
        
        // Log the rotation (in production, you might want to store this temporarily)
        _logger.LogInformation("Rotated secret for client {ClientId} in realm {Realm}", clientId, realm);
        
        return newSecret.Value;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to rotate secret for client {ClientId}", clientId);
        throw;
    }
}
```

# Client Scope Management

Client scopes define the permissions and claims that a client can request. Managing these scopes allows you to control what information and access each application can have.

## Add Default Client Scope

``` csharp
public async Task<bool> AddDefaultClientScopeAsync(string realm, string clientId, string scopeId)
{
    var provider = await GetAdminProviderAsync();
    
    // Add default client scope
    var success = await provider.Clients.AddDefaultClientScopeAsync(realm, clientId, scopeId);
    return success;
}
```

## Remove Default Client Scope

``` csharp
public async Task<bool> RemoveDefaultClientScopeAsync(string realm, string clientId, string scopeId)
{
    var provider = await GetAdminProviderAsync();
    
    // Remove default client scope
    var success = await provider.Clients.RemoveDefaultClientScopeAsync(realm, clientId, scopeId);
    return success;
}
```

## Get Client Scopes

``` csharp
public async Task<IEnumerable<string>> GetDefaultClientScopesAsync(string realm, string clientId)
{
    var provider = await GetAdminProviderAsync();
    
    // Get default client scopes
    var scopes = await provider.Clients.GetDefaultClientScopesAsync(realm, clientId);
    return scopes;
}
```

# Complete Client Management Service

This comprehensive example demonstrates how to build a complete client management service that handles all aspects of client lifecycle management.

``` csharp
public class KeycloakClientManagementService
{
    private readonly IKeycloakAdminService _keycloakService;
    private readonly ILogger<KeycloakClientManagementService> _logger;

    public KeycloakClientManagementService(
        IKeycloakAdminService keycloakService,
        ILogger<KeycloakClientManagementService> logger)
    {
        _keycloakService = keycloakService;
        _logger = logger;
    }

    public async Task<string> CreateWebApplicationClientAsync(
        string realm, 
        string clientId, 
        string clientName, 
        string[] redirectUris)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var newClient = new Client
            {
                ClientId = clientId,
                Name = clientName,
                Enabled = true,
                Protocol = "openid-connect",
                PublicClient = false,
                StandardFlowEnabled = true,
                DirectAccessGrantsEnabled = true,
                ServiceAccountsEnabled = true,
                RedirectUris = redirectUris,
                WebOrigins = redirectUris.Select(uri => new Uri(uri).GetLeftPart(UriPartial.Authority)).ToArray()
            };

            var createdClientId = await provider.Clients.CreateAndRetrieveClientIdAsync(realm, newClient);
            
            if (string.IsNullOrEmpty(createdClientId))
            {
                throw new InvalidOperationException($"Failed to create client {clientId}");
            }

            _logger.LogInformation("Successfully created client {ClientId} in realm {Realm}", clientId, realm);
            return createdClientId;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create client {ClientId} in realm {Realm}", clientId, realm);
            throw;
        }
    }

    public async Task<bool> UpdateClientConfigurationAsync(
        string realm, 
        string clientId, 
        Action<Client> updateAction)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var client = await provider.Clients.GetClientAsync(realm, clientId);
            updateAction(client);
            
            var success = await provider.Clients.UpdateClientAsync(realm, clientId, client);
            
            if (success)
            {
                _logger.LogInformation("Successfully updated client {ClientId} in realm {Realm}", clientId, realm);
            }
            
            return success;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update client {ClientId} in realm {Realm}", clientId, realm);
            throw;
        }
    }

    public async Task<bool> DeactivateClientAsync(string realm, string clientId)
    {
        return await UpdateClientConfigurationAsync(realm, clientId, client =>
        {
            client.Enabled = false;
        });
    }

    public async Task<string> RegenerateClientSecretAsync(string realm, string clientId)
    {
        var provider = _keycloakService.GetAdminWithBasicAuth("admin", "admin-password");
        
        try
        {
            var newSecret = await provider.Clients.GenerateClientSecretAsync(realm, clientId);
            _logger.LogInformation("Regenerated secret for client {ClientId} in realm {Realm}", clientId, realm);
            return newSecret.Value;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to regenerate secret for client {ClientId}", clientId);
            throw;
        }
    }
}
```
