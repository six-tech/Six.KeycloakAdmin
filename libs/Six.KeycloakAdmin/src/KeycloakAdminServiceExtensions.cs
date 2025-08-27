using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Six.KeycloakAdmin.TokenProvider;

namespace Six.KeycloakAdmin.Extensions;

/// <summary>
/// Extension methods for registering Keycloak services with dependency injection
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static class KeycloakAdminServiceExtensions
{
  /// <summary>
  /// Adds Keycloak services to the service collection with custom options
  /// </summary>
  /// <param name="services">The service collection</param>
  /// <param name="configureOptions">Action to configure Keycloak options</param>
  /// <param name="configurationSection">Configuration section name to be bound with KeycloakOptions</param>
  /// <returns>The service collection for chaining</returns>
  public static IServiceCollection AddKeycloakAdmin(
    this IServiceCollection services,
    Action<KeycloakAdminOptions>? configureOptions,
    string configurationSection = "Keycloak")
  {
    return AddKeycloakAdminInternal(services, configureOptions, configurationSection, keycloakServiceName: null);
  }
  

  /// <summary>
  /// Adds Keycloak services to the service collection with Aspire service discovery integration
  /// </summary>
  /// <param name="services">The service collection</param>
  /// <param name="keycloakServiceName">The name of the Keycloak service for Aspire service discovery</param>
  /// <param name="configureOptions">Action to configure Keycloak options</param>
  /// <param name="configurationSection">Configuration section name to be bound with KeycloakOptions</param>
  /// <returns>The service collection for chaining</returns>
  public static IServiceCollection AddKeycloakAdmin(
    this IServiceCollection services,
    string keycloakServiceName,
    Action<KeycloakAdminOptions>? configureOptions,
    string configurationSection = "Keycloak")
  {
    return AddKeycloakAdminInternal(services, configureOptions, configurationSection, keycloakServiceName);
  }

  
  
  static IServiceCollection AddKeycloakAdminInternal(
    IServiceCollection services,
    Action<KeycloakAdminOptions>? configureOptions,
    string configurationSection,
    string? keycloakServiceName)
  {
    services
      .AddOptions<KeycloakAdminOptions>()
      .BindConfiguration(configurationSection);

    if(configureOptions is not null)
      services.Configure(configureOptions);

    // Configure Aspire service discovery BaseUrl if keycloakServiceName is provided
    // This must be done last to ensure it overrides any other BaseUrl configuration
    if (!string.IsNullOrEmpty(keycloakServiceName))
    {
      services.Configure<KeycloakAdminOptions>(options =>
      {
        options.BaseUrl = $"http+https://{keycloakServiceName}";
      });
    }

    // Build the temporary service provider to get the configured HttpClient name
    using var tempServiceProvider = services.BuildServiceProvider();
    var options = tempServiceProvider.GetRequiredService<IOptions<KeycloakAdminOptions>>().Value;
    var httpClientName = options.HttpClientName;

    services.AddHttpClient(httpClientName, (serviceProvider, client) =>
    {
      var keycloakOptions = serviceProvider.GetRequiredService<IOptions<KeycloakAdminOptions>>().Value;

      // Configure base address from options
      if(!string.IsNullOrEmpty(keycloakOptions.BaseUrl))
      {
        client.BaseAddress = new Uri(keycloakOptions.BaseUrl);
      }

      client.Timeout = keycloakOptions.HttpTimeout;
      client.DefaultRequestHeaders.Add("Accept", "application/json");
    });

    services.AddMemoryCache();
    services.AddSingleton<ITokenCache, TokenCache.TokenCache>();
    services.AddSingleton<BasicAuthTokenProvider>();
    services.AddSingleton<ClientSecretTokenProvider>();
    services.AddScoped<IKeycloakAdminService, KeycloakAdminService>();

    return services;
  }
}