---
title: Aspire Integration
description: Seamless integration of Keycloak Admin with .NET Aspire for service discovery and orchestration
---

# Introduction

The `Six.KeycloakAdmin` library provides seamless integration with **.NET Aspire**, Microsoft's cloud-ready stack for building observable, production-ready distributed applications. This integration enables automatic service discovery, simplified configuration, and enhanced observability for Keycloak administrative operations in containerized and cloud environments.

By leveraging Aspire's service discovery capabilities, **developers can eliminate hardcoded URLs and connection strings,** making applications more portable and environment-agnostic. 

# Basic Setup

## 1. AppHost Configuration

Create or update your Aspire AppHost project to include Keycloak resource and reference your project (in this 
example, `MyApi`:

``` csharp
// Program.cs in your AppHost project
var builder = DistributedApplication.CreateBuilder(args);

// Add Keycloak as a managed resource
var keycloak = builder.AddKeycloak("keycloak", 8080)
    .WithDataVolume()
    .WithRealmImport("realm-export.json"); // Optional: import realm configuration

// Add your API project that will use KeycloakAdmin
builder.AddProject<Projects.MyApi>("myapi")
    .WithReference(keycloak);

builder.Build().Run();
```

## 2. Service Registration with Aspire Integration

In your API or service project, just register the `KeycloakAdmin` and set the name of the Keycloak resource as you 
did define it in the `AppHost` project (in this example, `keycloak`):

``` csharp
// Program.cs in your API project
var builder = WebApplication.CreateBuilder(args);

// Register KeycloakAdmin with Aspire service discovery
builder.Services.AddKeycloakAdmin("keycloak", options =>
{
    options.AdminClientId = "admin-cli";
    options.HttpTimeout = TimeSpan.FromSeconds(30);
    // BaseUrl is automatically set to "http+https://keycloak" for service discovery
});

var app = builder.Build();
```

## 3. Using the Admin Client

Once configured, inject and use the Keycloak admin services as usual:

``` csharp
// In your controller or service
public class UserController : ControllerBase
{
    private readonly IKeycloakAdminService _keycloakAdminService;

    public UserController(IKeycloakAdminService keycloakAdminService)
    {
        _keycloakAdminService = keycloakAdminService;
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        // Get admin provider (automatically uses service discovery)
        // Note: For production, consider using secure secret services like Azure Key Vault instead of environment variables
        var adminProvider = _keycloakAdminService.GetAdminWithBasicAuth(
            Environment.GetEnvironmentVariable("KEYCLOAK_ADMIN_USERNAME") ?? "admin",
            Environment.GetEnvironmentVariable("KEYCLOAK_ADMIN_PASSWORD") ?? "admin");
        
        var users = await adminProvider.Users.GetUsersAsync("master");
        return Ok(users);
    }
}
```



