![Six Keycloak Hero](assets/six-keycloak-admin-banner-wide-1980-01.png)

[![license](https://img.shields.io/github/license/six-tech/Six.KeycloakAdmin.svg?maxAge=2592000)](https://github.com/six-tech/Six.KeycloakAdmin/blob/master/LICENSE) [![NuGet](https://img.shields.io/nuget/v/Keycloak.Net.Core?maxAge=2592000)](https://www.nuget.org/packages/Keycloak.Net.Core/) [![downloads](https://img.shields.io/nuget/dt/Keycloak.Net.Core)](https://www.nuget.org/packages/Keycloak.Net.Core/)

# Introduction

**Keycloak Admin** is a .NET client library that provides comprehensive access to **Keycloak administration APIs.**
This library simplifies the integration with Keycloak servers, offering a clean and intuitive interface for managing
users, clients, roles, and more.

## From Where it Started?

We needed an easy way to integrate with Keycloak in .NET projects and tried existing Keycloak client libraries.
Unfortunately, they were missing several important things that we needed, so we forked the
original [Keycloak.NET from Silent Partner Software](https://github.com/silentpartnersoftware/Keycloak.Net), and started
to improve it.

Over time, we added many features and enhancements, leading to the **Keycloak Admin** as a library of its own.

# Improvements

- Added `KeycloakService` that serves to create needed `IKeycloakAdminClient` instances (with `basic auth`,
  `client secret`, `token`) and can be easily injected into your services using dependency injection.
- Each `IKeycloakAdminClient` instance **nicely separates subjects** (e.g. `IKeycloakAdminClient.Users`,
  `IKeycloakAdminClient.Clients`, etc.) to avoid confusion and make it easier to use.

  ⚡Available categories:
  - `AttackDetection` - Security and brute force detection
  - `AuthenticationManagement` - Authentication flows
  - `ClientAttributeCertificate` - Certificate management
  - `ClientInitialAccess` - Client registration
  - `ClientRegistrationPolicy` - Registration policies
  - `ClientRoleMappings` - Client role mappings
  - `Clients` - Client management
  - `ClientScopes` - Client scopes
  - `Components` - Component management
  - `Groups` - Group management
  - `IdentityProviders` - Identity providers
  - `Key` - Key management
  - `ProtocolMappers` - Protocol mappers
  - `RealmsAdmin` - Realm administration
  - `RoleMapper` - Role mappings
  - `Roles` - Role management
  - `RolesById` - Role operations by ID
  - `ScopeMappings` - Scope mappings
  - `ServerInfo` - Server information
  - `Users` - User management
  - `UserStorageProvider` - User storage providers
- **Token caching** (using `MemoryCache`) to avoid unnecessary calls to **Keycloak**.
- Removed `Flurl` dependency (uses `HttpClient` instead directly).
- All Keycloak models are now immutable (records) to ensure thread safety.
- Removed support for the older Keycloak API style (without `/auth` path).
- **.NET Aspire integration** for quick setup.
- **.NET Aspire for testing**. No need to set up anything to test! Run the tests, and they will use Aspire to mock the
  Keycloak API.
- Generates coverage report and full HTML coverage documentation.
- **Single file apps for running tests and Nuget packaging** (no more ugly scripts, everything is in C#). -- **Note:**
  needs **.NET 10** installed --

The full documentation [is available here](https://six-tech.github.io/Six.KeycloakAdmin).