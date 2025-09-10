using Aspire.Hosting;
using Projects;

namespace Six.KeycloakAdmin.Tests.Functional;

/// <summary>
/// Shared test fixture for Keycloak integration tests.
/// This fixture is created once for all tests in the collection and disposed after all the tests complete.
/// It manages the lifecycle of the Keycloak container and provides the admin client.
/// </summary>
[PublicAPI]
public class KeycloakTestFixture : IAsyncLifetime
{
  static readonly TimeSpan _defaultTimeout = TimeSpan.FromSeconds(120);
  DistributedApplication _app = null!;

  /// <summary>
  /// Gets the Keycloak admin client for use in tests.
  /// </summary>
  internal IKeycloakAdminProvider AdminProvider { get; private set; } = null!;

  /// <summary>
  /// Initializes the test fixture by starting the Keycloak container and configuring the admin client.
  /// This method is called once before any tests in the collection run.
  /// </summary>
  /// <remarks>
  /// I didn't find a way to dynamically set the Keycloak base URL using Aspire discoverability,
  /// so we use a fixed port for the Keycloak admin client.
  /// So, the port is fixed with: <c>"DcpPublisher:RandomizePorts=false"</c>
  /// </remarks>
  public async Task InitializeAsync()
  {
    // Arrange
    var cancellationToken = new CancellationTokenSource(_defaultTimeout).Token;
    var appHost =
      await DistributedApplicationTestingBuilder.CreateAsync<Six_KeycloakAdmin_Tests_AppHost>(
        args: ["DcpPublisher:RandomizePorts=false"], // We disable port randomization for tests
        cancellationToken: cancellationToken);

    appHost.Services.AddLogging(logging =>
    {
      logging.SetMinimumLevel(LogLevel.Debug);
      logging.AddFilter(appHost.Environment.ApplicationName, LogLevel.Debug);
      logging.AddFilter("Aspire.", LogLevel.Debug);
    });

    appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
    {
      clientBuilder.AddStandardResilienceHandler();
    });

    appHost.Services.AddKeycloakAdmin(options =>
    {
      // With port randomization disabled, we can use the fixed port
      options.BaseUrl = $"http://localhost:{KeycloakAdminDefaults.Port}";
    });

    // Build and start the application
    _app = await appHost.BuildAsync(cancellationToken).WaitAsync(_defaultTimeout, cancellationToken);
    await _app.StartAsync(cancellationToken).WaitAsync(_defaultTimeout, cancellationToken);

    await _app.ResourceNotifications
      .WaitForResourceHealthyAsync(KeycloakAdminDefaults.AspireResourceName, cancellationToken)
      .WaitAsync(_defaultTimeout, cancellationToken);

    // Get the Keycloak admin service and create the KeycloakAdmin client (basic auth)
    using var scope = _app.Services.CreateScope();
    var keycloakAdminService = scope.ServiceProvider.GetRequiredService<IKeycloakAdminService>();

    AdminProvider = keycloakAdminService.GetAdminWithBasicAuth(
      KeycloakAdminDefaults.AdminUsername,
      KeycloakAdminDefaults.AdminPassword);
  }

  /// <summary>
  /// Cleans up the test fixture by disposing the Aspire application and Keycloak container.
  /// This method is called once after all tests in the collection complete.
  /// </summary>
  public async Task DisposeAsync()
  {
    await _app.DisposeAsync();
  }
}