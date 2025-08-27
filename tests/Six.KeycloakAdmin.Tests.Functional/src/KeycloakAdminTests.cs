namespace Six.KeycloakAdmin.Tests.Functional;

/// <summary>
/// Base test class for Keycloak Admin API integration tests.
/// All tests run sequentially within the same collection to avoid concurrency issues.
/// The Keycloak container is shared across all tests and managed by the KeycloakTestFixture.
/// </summary>
[Collection(KeycloakTestCollection.Name)]
public partial class KeycloakAdminTests
{
  readonly IKeycloakAdminProvider _adminProvider;

  /// <summary>
  /// Initializes a new instance of the test class with the shared Keycloak fixture.
  /// </summary>
  /// <param name="fixture">The shared Keycloak test fixture containing the admin client.</param>
  public KeycloakAdminTests(KeycloakTestFixture fixture)
  {
    _adminProvider = fixture.AdminProvider;
  }
}