using Six.KeycloakAdmin.Tests.AppHost;

/*
 * Keycloak Test AppHost Configuration
 *
 * This AppHost sets up a Keycloak instance for integration testing.
 *
 * AUTHORIZATION PERMISSIONS:
 * Some tests require Keycloak's fine-grained admin permissions feature, which is experimental.
 * These tests are currently skipped with the message "Requires Keycloak authorization services to be enabled":
 *
 * Skipped Tests:
 * - KeycloakAdminTests.Clients.GetClientAuthorizationPermissionsInitializedAsync
 * - KeycloakAdminTests.RealmsAdmin.GetRealmUsersManagementPermissionsAsync
 * - KeycloakAdminTests.Roles.GetRoleAuthorizationPermissionsInitializedForRealmAsync
 * - KeycloakAdminTests.RolesById.GetRoleByIdAuthorizationPermissionsInitializedAsync
 *
 * To enable these tests, uncomment the .WithEnvironment() line in the Keycloak configuration below.
 */

var builder = DistributedApplication.CreateBuilder(args);

// Define custom admin credentials for Keycloak
var adminUsername = builder.AddParameter("keycloak-admin-username", KeycloakAdminDefaults.AdminUsername);
var adminPassword = builder.AddParameter("keycloak-admin-password", KeycloakAdminDefaults.AdminPassword, secret: true);

builder
  .AddKeycloak(
    KeycloakAdminDefaults.AspireResourceName, 
    KeycloakAdminDefaults.Port, 
    adminUsername,
    adminPassword)
  .WithDataVolume()
  .WithRealmImport(KeycloakAdminDefaults.TestRealmFileName)
  // Uncomment the following line to enable fine-grained admin permissions (experimental feature)
  // This is required for the following tests that are currently skipped:
  // - GetClientAuthorizationPermissionsInitializedAsync
  // - GetRealmUsersManagementPermissionsAsync
  // - GetRoleAuthorizationPermissionsInitializedForRealmAsync
  // - GetRoleByIdAuthorizationPermissionsInitializedAsync
  // Note: This feature may still be experimental/preview in your Keycloak version
  // .WithEnvironment("KC_FEATURES", "admin-fine-grained-authz,admin2")
  .WithLifetime(ContainerLifetime.Session);

builder.Build().Run();
