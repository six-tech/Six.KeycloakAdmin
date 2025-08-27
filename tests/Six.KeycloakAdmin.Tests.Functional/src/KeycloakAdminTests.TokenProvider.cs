using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Six.KeycloakAdmin.TokenProvider;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Six.KeycloakAdmin.Tests.Functional;

/// <summary>
/// Integration tests for token provider caching functionality to ensure tokens 
/// are properly cached and not constantly requested from Keycloak.
/// </summary>
[Trait("Category", "TokenProvider")]
public partial class KeycloakAdminTests
{
  [Fact]
  public async Task ClientSecretTokenProvider_GetTokenAsync_CachesTokenOnFirstRequest()
  {
    // Arrange
    var services = new ServiceCollection();
    services.AddLogging();
    services.AddHttpClient();
    services.AddMemoryCache();
    services.AddSingleton<ITokenCache, Six.KeycloakAdmin.TokenCache.TokenCache>();
    services.Configure<KeycloakAdminOptions>(options =>
    {
      options.BaseUrl = "https://keycloak.example.com";
      options.AdminClientId = "admin-cli";
    });

    var serviceProvider = services.BuildServiceProvider();
    var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
    var tokenCache = serviceProvider.GetRequiredService<ITokenCache>();
    var options = serviceProvider.GetRequiredService<IOptions<KeycloakAdminOptions>>();

    var tokenProvider = new TestableClientSecretTokenProvider(
      httpClientFactory,
      tokenCache,
      options);

    var realm = "test-realm";
    var clientSecret = "test-secret";

    // Act - First request should hit the server
    var token1 = await tokenProvider.GetTokenAsync(realm, clientSecret);
    var requestCount1 = tokenProvider.RequestCount;

    // Act - Second request should use cache
    var token2 = await tokenProvider.GetTokenAsync(realm, clientSecret);
    var requestCount2 = tokenProvider.RequestCount;

    // Assert
    Assert.NotNull(token1);
    Assert.NotNull(token2);
    Assert.Equal(token1, token2); // Should be the same token
    Assert.Equal(1, requestCount1); // First request hits server
    Assert.Equal(1, requestCount2); // Second request uses cache (no additional request)
  }

  [Fact]
  public async Task ClientSecretTokenProvider_GetTokenAsync_WithMultipleConcurrentRequests_OnlyMakesOneServerRequest()
  {
    // Arrange
    var services = new ServiceCollection();
    services.AddLogging();
    services.AddHttpClient();
    services.AddMemoryCache();
    services.AddSingleton<ITokenCache, Six.KeycloakAdmin.TokenCache.TokenCache>();
    services.Configure<KeycloakAdminOptions>(options =>
    {
      options.BaseUrl = "https://keycloak.example.com";
      options.AdminClientId = "admin-cli";
    });

    var serviceProvider = services.BuildServiceProvider();
    var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
    var tokenCache = serviceProvider.GetRequiredService<ITokenCache>();
    var options = serviceProvider.GetRequiredService<IOptions<KeycloakAdminOptions>>();

    var tokenProvider = new TestableClientSecretTokenProvider(
      httpClientFactory,
      tokenCache,
      options);

    var realm = "test-realm";
    var clientSecret = "test-secret";
    var tokens = new ConcurrentBag<string?>();

    // Act - Multiple concurrent requests
    var tasks = new List<Task>();
    for(int i = 0; i < 10; i++)
    {
      tasks.Add(Task.Run(async () =>
      {
        var token = await tokenProvider.GetTokenAsync(realm, clientSecret);
        tokens.Add(token);
      }));
    }

    await Task.WhenAll(tasks);

    // Assert
    Assert.Equal(10, tokens.Count);
    Assert.All(tokens, token => Assert.NotNull(token));
    Assert.Single(tokens.Distinct()); // All tokens should be the same
    Assert.Equal(1, tokenProvider.RequestCount); // Only one server request despite concurrent calls
  }

  [Fact]
  public async Task BasicAuthTokenProvider_GetTokenAsync_CachesTokenOnFirstRequest()
  {
    // Arrange
    var services = new ServiceCollection();
    services.AddLogging();
    services.AddHttpClient();
    services.AddMemoryCache();
    services.AddSingleton<ITokenCache, Six.KeycloakAdmin.TokenCache.TokenCache>();
    services.Configure<KeycloakAdminOptions>(options =>
    {
      options.BaseUrl = "https://keycloak.example.com";
      options.AdminClientId = "admin-cli";
    });

    var serviceProvider = services.BuildServiceProvider();
    var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
    var tokenCache = serviceProvider.GetRequiredService<ITokenCache>();
    var options = serviceProvider.GetRequiredService<IOptions<KeycloakAdminOptions>>();

    var tokenProvider = new TestableBasicAuthTokenProvider(
      httpClientFactory,
      tokenCache,
      options);

    var realm = "test-realm";
    var username = "admin";
    var password = "admin-password";

    // Act - First request should hit the server
    var token1 = await tokenProvider.GetTokenAsync(realm, username, password);
    var requestCount1 = tokenProvider.RequestCount;

    // Act - Second request should use cache
    var token2 = await tokenProvider.GetTokenAsync(realm, username, password);
    var requestCount2 = tokenProvider.RequestCount;

    // Assert
    Assert.NotNull(token1);
    Assert.NotNull(token2);
    Assert.Equal(token1, token2); // Should be the same token
    Assert.Equal(1, requestCount1); // First request hits server
    Assert.Equal(1, requestCount2); // Second request uses cache (no additional request)
  }

  [Fact]
  public async Task TokenProvider_GetTokenAsync_WithDifferentRealms_CachesSeparately()
  {
    // Arrange
    var services = new ServiceCollection();
    services.AddLogging();
    services.AddHttpClient();
    services.AddMemoryCache();
    services.AddSingleton<ITokenCache, Six.KeycloakAdmin.TokenCache.TokenCache>();
    services.Configure<KeycloakAdminOptions>(options =>
    {
      options.BaseUrl = "https://keycloak.example.com";
      options.AdminClientId = "admin-cli";
    });

    var serviceProvider = services.BuildServiceProvider();
    var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
    var tokenCache = serviceProvider.GetRequiredService<ITokenCache>();
    var options = serviceProvider.GetRequiredService<IOptions<KeycloakAdminOptions>>();

    var tokenProvider = new TestableClientSecretTokenProvider(
      httpClientFactory,
      tokenCache,
      options);

    var realm1 = "realm1";
    var realm2 = "realm2";
    var clientSecret = "test-secret";

    // Act - Request token for realm1
    var token1 = await tokenProvider.GetTokenAsync(realm1, clientSecret);
    var requestCount1 = tokenProvider.RequestCount;

    // Act - Request token for realm2
    var token2 = await tokenProvider.GetTokenAsync(realm2, clientSecret);
    var requestCount2 = tokenProvider.RequestCount;

    // Act - Request token for realm1 again (should use cache)
    var token1Again = await tokenProvider.GetTokenAsync(realm1, clientSecret);
    var requestCount3 = tokenProvider.RequestCount;

    // Assert
    Assert.NotNull(token1);
    Assert.NotNull(token2);
    Assert.NotNull(token1Again);
    Assert.NotEqual(token1, token2); // Different realms should have different tokens
    Assert.Equal(token1, token1Again); // Same realm should return cached token
    Assert.Equal(1, requestCount1); // First realm1 request
    Assert.Equal(2, requestCount2); // First realm2 request
    Assert.Equal(2, requestCount3); // realm1 cached, no new request
  }

  [Fact]
  public async Task TokenProvider_GetTokenAsync_WhenTokenExpires_RequestsNewToken()
  {
    // Arrange
    var services = new ServiceCollection();
    services.AddLogging();
    services.AddHttpClient();
    services.AddMemoryCache();
    services.AddSingleton<ITokenCache, Six.KeycloakAdmin.TokenCache.TokenCache>();
    services.Configure<KeycloakAdminOptions>(options =>
    {
      options.BaseUrl = "https://keycloak.example.com";
      options.AdminClientId = "admin-cli";
    });

    var serviceProvider = services.BuildServiceProvider();
    var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
    var tokenCache = serviceProvider.GetRequiredService<ITokenCache>();
    var options = serviceProvider.GetRequiredService<IOptions<KeycloakAdminOptions>>();

    var tokenProvider = new TestableClientSecretTokenProvider(
      httpClientFactory,
      tokenCache,
      options);

    // Set short token expiry for testing (35 seconds to account for 30 second buffer)
    tokenProvider.TokenExpirySeconds = 35;

    var realm = "test-realm";
    var clientSecret = "test-secret";

    // Act - First request
    var token1 = await tokenProvider.GetTokenAsync(realm, clientSecret);
    var requestCount1 = tokenProvider.RequestCount;

    // Wait for cache to expire (token expires at 35s, cache expires at 5s due to 30s buffer)
    await Task.Delay(TimeSpan.FromSeconds(6));

    // Act - Request after expiry should get new token
    var token2 = await tokenProvider.GetTokenAsync(realm, clientSecret);
    var requestCount2 = tokenProvider.RequestCount;

    // Assert
    Assert.NotNull(token1);
    Assert.NotNull(token2);
    Assert.NotEqual(token1, token2); // Should be different tokens
    Assert.Equal(1, requestCount1); // First request
    Assert.Equal(2, requestCount2); // Second request after expiry
  }

  [Fact]
  public async Task TokenProvider_PerformanceTest_CachingReducesLatency()
  {
    // Arrange
    var services = new ServiceCollection();
    services.AddLogging();
    services.AddHttpClient();
    services.AddMemoryCache();
    services.AddSingleton<ITokenCache, Six.KeycloakAdmin.TokenCache.TokenCache>();
    services.Configure<KeycloakAdminOptions>(options =>
    {
      options.BaseUrl = "https://keycloak.example.com";
      options.AdminClientId = "admin-cli";
    });

    var serviceProvider = services.BuildServiceProvider();
    var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
    var tokenCache = serviceProvider.GetRequiredService<ITokenCache>();
    var options = serviceProvider.GetRequiredService<IOptions<KeycloakAdminOptions>>();

    var tokenProvider = new TestableClientSecretTokenProvider(
      httpClientFactory,
      tokenCache,
      options);

    // Add simulated network latency
    tokenProvider.SimulatedLatencyMs = 100;

    var realm = "test-realm";
    var clientSecret = "test-secret";

    // Act - Measure first request time (includes network latency)
    var sw1 = Stopwatch.StartNew();
    var token1 = await tokenProvider.GetTokenAsync(realm, clientSecret);
    sw1.Stop();
    var firstRequestTime = sw1.ElapsedMilliseconds;

    // Act - Measure cached request time (no network latency)
    var sw2 = Stopwatch.StartNew();
    var token2 = await tokenProvider.GetTokenAsync(realm, clientSecret);
    sw2.Stop();
    var cachedRequestTime = sw2.ElapsedMilliseconds;

    // Assert
    Assert.NotNull(token1);
    Assert.NotNull(token2);
    Assert.Equal(token1, token2);
    Assert.True(firstRequestTime > cachedRequestTime,
      $"First request ({firstRequestTime}ms) should take longer than cached request ({cachedRequestTime}ms)");
    Assert.True(cachedRequestTime < 50,
      $"Cached request should be very fast, but took {cachedRequestTime}ms");
  }

  /// <summary>
  /// Test-specific token response class for testing purposes
  /// </summary>
  sealed record TestTokenResponse
  {
    [JsonPropertyName("access_token")] public string AccessToken { get; init; } = string.Empty;
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; init; }
    [JsonPropertyName("token_type")] public string TokenType { get; init; } = "Bearer";
    [JsonPropertyName("refresh_token")] public string? RefreshToken { get; init; }

    [JsonPropertyName("refresh_expires_in")]
    public int RefreshExpiresIn { get; init; }
  }

  /// <summary>
  /// Testable version of ClientSecretTokenProvider that tracks request counts and allows control over token responses
  /// </summary>
  class TestableClientSecretTokenProvider : ClientSecretTokenProvider
  {
    int _requestCount = 0;
    int _tokenCounter = 0;

    public int RequestCount => _requestCount;
    public int TokenExpirySeconds { get; set; } = 300;
    public int SimulatedLatencyMs { get; set; } = 0;

    public TestableClientSecretTokenProvider(
      IHttpClientFactory httpClientFactory,
      ITokenCache tokenCache,
      IOptions<KeycloakAdminOptions> options)
      : base(httpClientFactory, tokenCache, options)
    {
    }

    protected override async Task<Six.KeycloakAdmin.TokenCache.TokenCacheEntry?> RefreshTokenAsync(
      string realm,
      Six.KeycloakAdmin.TokenCache.TokenCacheEntry cachedEntry,
      CancellationToken cancellationToken = default)
    {
      // Simulate network latency
      if(SimulatedLatencyMs > 0)
        await Task.Delay(SimulatedLatencyMs, cancellationToken);

      Interlocked.Increment(ref _requestCount);

      // Generate a test token with controlled expiry
      var tokenValue = $"test-access-token-{Interlocked.Increment(ref _tokenCounter)}";
      var refreshValue = $"test-refresh-token-{_tokenCounter}";
      var expiryTime = DateTimeOffset.UtcNow.AddSeconds(TokenExpirySeconds);

      return new Six.KeycloakAdmin.TokenCache.TokenCacheEntry(tokenValue, expiryTime, refreshValue);
    }

    async Task<Six.KeycloakAdmin.TokenCache.TokenCacheEntry?> RequestTokenResponseAsync(
      string realm,
      string clientSecret,
      CancellationToken cancellationToken)
    {
      // Simulate network latency
      if(SimulatedLatencyMs > 0)
        await Task.Delay(SimulatedLatencyMs, cancellationToken);

      Interlocked.Increment(ref _requestCount);

      // Generate a test token response
      var tokenValue = $"test-access-token-{Interlocked.Increment(ref _tokenCounter)}";
      var refreshValue = $"test-refresh-token-{_tokenCounter}";
      var expiryTime = DateTimeOffset.UtcNow.AddSeconds(TokenExpirySeconds);

      return new Six.KeycloakAdmin.TokenCache.TokenCacheEntry(tokenValue, expiryTime, refreshValue);
    }

    public new async Task<string?> GetTokenAsync(
      string realm,
      string clientSecret,
      CancellationToken cancellationToken = default)
    {
      if(string.IsNullOrEmpty(realm))
        throw new ArgumentException("Realm cannot be null or empty", nameof(realm));

      if(string.IsNullOrEmpty(clientSecret))
        throw new ArgumentException("Client secret cannot be null or empty", nameof(clientSecret));

      var cacheKey = $"keycloak:client:{realm}:{AdminOptions.AdminClientId}";

      return await GetTokenAsync(realm, cacheKey, async () =>
      {
        var tokenRecord = await RequestTokenResponseAsync(realm, clientSecret, cancellationToken);
        return tokenRecord;
      }, cancellationToken);
    }
  }

  /// <summary>
  /// Testable version of BasicAuthTokenProvider that tracks request counts and allows control over token responses
  /// </summary>
  class TestableBasicAuthTokenProvider : BasicAuthTokenProvider
  {
    int _requestCount = 0;
    int _tokenCounter = 0;

    public int RequestCount => _requestCount;
    public int TokenExpirySeconds { get; set; } = 300;
    public int SimulatedLatencyMs { get; set; } = 0;

    public TestableBasicAuthTokenProvider(
      IHttpClientFactory httpClientFactory,
      ITokenCache tokenCache,
      IOptions<KeycloakAdminOptions> options)
      : base(httpClientFactory, tokenCache, options)
    {
    }

    protected override async Task<Six.KeycloakAdmin.TokenCache.TokenCacheEntry?> RefreshTokenAsync(
      string realm,
      Six.KeycloakAdmin.TokenCache.TokenCacheEntry cachedEntry,
      CancellationToken cancellationToken = default)
    {
      // Simulate network latency
      if(SimulatedLatencyMs > 0)
        await Task.Delay(SimulatedLatencyMs, cancellationToken);

      Interlocked.Increment(ref _requestCount);

      // Generate a test token with controlled expiry
      var tokenValue = $"test-access-token-{Interlocked.Increment(ref _tokenCounter)}";
      var refreshValue = $"test-refresh-token-{_tokenCounter}";
      var expiryTime = DateTimeOffset.UtcNow.AddSeconds(TokenExpirySeconds);

      return new Six.KeycloakAdmin.TokenCache.TokenCacheEntry(tokenValue, expiryTime, refreshValue);
    }

    async Task<Six.KeycloakAdmin.TokenCache.TokenCacheEntry?> RequestTokenResponseAsync(
      string realm,
      string username,
      string password,
      CancellationToken cancellationToken)
    {
      // Simulate network latency
      if(SimulatedLatencyMs > 0)
        await Task.Delay(SimulatedLatencyMs, cancellationToken);

      Interlocked.Increment(ref _requestCount);

      // Generate a test token response
      var tokenValue = $"test-access-token-{Interlocked.Increment(ref _tokenCounter)}";
      var refreshValue = $"test-refresh-token-{_tokenCounter}";
      var expiryTime = DateTimeOffset.UtcNow.AddSeconds(TokenExpirySeconds);

      return new Six.KeycloakAdmin.TokenCache.TokenCacheEntry(tokenValue, expiryTime, refreshValue);
    }

    public new async Task<string?> GetTokenAsync(
      string realm,
      string username,
      string password,
      CancellationToken cancellationToken = default)
    {
      if(string.IsNullOrEmpty(realm))
        throw new ArgumentException("Realm cannot be null or empty", nameof(realm));

      if(string.IsNullOrEmpty(username))
        throw new ArgumentException("Username cannot be null or empty", nameof(username));

      if(string.IsNullOrEmpty(password))
        throw new ArgumentException("Password cannot be null or empty", nameof(password));

      var cacheKey = $"keycloak:user:{realm}:{username}";

      return await GetTokenAsync(realm, cacheKey, async () =>
      {
        var tokenRecord = await RequestTokenResponseAsync(realm, username, password, cancellationToken);
        return tokenRecord;
      }, cancellationToken);
    }
  }
}