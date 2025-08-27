namespace Six.KeycloakAdmin.Tests.Functional;

/// <summary>
/// Defines a test collection for Keycloak integration tests.
/// All tests in this collection will run sequentially to avoid concurrency issues
/// with the shared Keycloak container instance.
/// </summary>
[CollectionDefinition(Name)]
public class KeycloakTestCollection : ICollectionFixture<KeycloakTestFixture>
{
  /// <summary>
  /// The name of the test collection used to group all Keycloak integration tests.
  /// </summary>
  public const string Name = "Keycloak Integration Tests";
}
