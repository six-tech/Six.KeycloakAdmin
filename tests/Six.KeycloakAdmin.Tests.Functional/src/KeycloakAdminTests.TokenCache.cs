using Microsoft.Extensions.Caching.Memory;
using Six.KeycloakAdmin.TokenCache;
using Six.KeycloakAdmin.TokenProvider;

namespace Six.KeycloakAdmin.Tests.Functional;

/// <summary>
/// Integration tests for token caching functionality to ensure tokens are cached correctly
/// and not constantly requested from Keycloak.
/// </summary>
[Trait("Category", "TokenCache")]
public partial class KeycloakAdminTests
{
  [Fact]
  public async Task TokenCache_GetAsync_WhenTokenNotCached_ReturnsNull()
  {
    // Arrange
    var memoryCache = new MemoryCache(new MemoryCacheOptions());
    using var tokenCache = new TokenCache.TokenCache(memoryCache);
    var cacheKey = "test:token:key";

    // Act
    var result = await tokenCache.GetAsync(cacheKey);

    // Assert
    Assert.Null(result);
  }

  [Fact]
  public async Task TokenCache_SetAndGetAsync_WhenTokenCached_ReturnsToken()
  {
    // Arrange
    var memoryCache = new MemoryCache(new MemoryCacheOptions());
    using var tokenCache = new TokenCache.TokenCache(memoryCache);
    var cacheKey = "test:token:key";
    var accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.test";
    var expiryTime = DateTimeOffset.UtcNow.AddMinutes(5);
    var tokenRecord = new TokenCacheEntry(accessToken, expiryTime);

    // Act - Cache the token
    await tokenCache.SetAsync(cacheKey, tokenRecord);
    
    // Act - Retrieve the cached token
    var result = await tokenCache.GetAsync(cacheKey);

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsValid);
    Assert.Equal(accessToken, result.GetAccessToken());
  }

  [Fact]
  public async Task TokenCache_GetAsync_WhenTokenExpired_ReturnsNullAndRemovesFromCache()
  {
    // Arrange
    var memoryCache = new MemoryCache(new MemoryCacheOptions());
    using var tokenCache = new TokenCache.TokenCache(memoryCache);
    var cacheKey = "test:token:expired";
    var accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.expired";
    var expiryTime = DateTimeOffset.UtcNow.AddSeconds(-1); // Already expired
    var tokenRecord = new TokenCacheEntry(accessToken, expiryTime);

    // Act - Cache the expired token
    await tokenCache.SetAsync(cacheKey, tokenRecord);
    
    // Act - Try to retrieve the expired token
    var result = await tokenCache.GetAsync(cacheKey);

    // Assert - Should return null since token is expired
    Assert.Null(result);
    
    // Verify token was removed from cache
    var secondAttempt = await tokenCache.GetAsync(cacheKey);
    Assert.Null(secondAttempt);
  }

  [Fact]
  public async Task TokenCache_SetAsync_WhenTokenAboutToExpire_DoesNotCacheToken()
  {
    // Arrange
    var memoryCache = new MemoryCache(new MemoryCacheOptions());
    using var tokenCache = new TokenCache.TokenCache(memoryCache);
    var cacheKey = "test:token:about-to-expire";
    var accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.expiring";
    var expiryTime = DateTimeOffset.UtcNow.AddSeconds(10); // Less than 30 second buffer
    var tokenRecord = new TokenCacheEntry(accessToken, expiryTime);

    // Act - Try to cache token that's about to expire
    await tokenCache.SetAsync(cacheKey, tokenRecord);
    
    // Act - Try to retrieve the token
    var result = await tokenCache.GetAsync(cacheKey);

    // Assert - Should not be cached due to expiry buffer
    Assert.Null(result);
  }

  [Fact]
  public async Task TokenCache_SetAsync_WhenReplacingExistingToken_DisposesOldToken()
  {
    // Arrange
    var memoryCache = new MemoryCache(new MemoryCacheOptions());
    using var tokenCache = new TokenCache.TokenCache(memoryCache);
    var cacheKey = "test:token:replace";
    var oldAccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.old";
    var newAccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.new";
    var expiryTime = DateTimeOffset.UtcNow.AddMinutes(5);
    
    var oldTokenRecord = new TokenCacheEntry(oldAccessToken, expiryTime);
    var newTokenRecord = new TokenCacheEntry(newAccessToken, expiryTime);

    // Act - Cache the first token
    await tokenCache.SetAsync(cacheKey, oldTokenRecord);
    
    // Act - Replace with new token
    await tokenCache.SetAsync(cacheKey, newTokenRecord);
    
    // Act - Retrieve the token
    var result = await tokenCache.GetAsync(cacheKey);

    // Assert - Should get the new token
    Assert.NotNull(result);
    Assert.Equal(newAccessToken, result.GetAccessToken());
  }

  [Fact]
  public async Task TokenCache_Remove_WhenTokenCached_RemovesToken()
  {
    // Arrange
    var memoryCache = new MemoryCache(new MemoryCacheOptions());
    using var tokenCache = new TokenCache.TokenCache(memoryCache);
    var cacheKey = "test:token:remove";
    var accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.remove";
    var expiryTime = DateTimeOffset.UtcNow.AddMinutes(5);
    var tokenRecord = new TokenCacheEntry(accessToken, expiryTime);

    // Act - Cache the token
    await tokenCache.SetAsync(cacheKey, tokenRecord);
    
    // Verify token is cached
    var cachedResult = await tokenCache.GetAsync(cacheKey);
    Assert.NotNull(cachedResult);
    
    // Act - Remove the token
    tokenCache.Remove(cacheKey);
    
    // Act - Try to retrieve after removal
    var result = await tokenCache.GetAsync(cacheKey);

    // Assert - Token should be removed
    Assert.Null(result);
  }

  [Fact]
  public async Task TokenCache_ConcurrentAccess_HandlesThreadSafely()
  {
    // Arrange
    var memoryCache = new MemoryCache(new MemoryCacheOptions());
    using var tokenCache = new TokenCache.TokenCache(memoryCache);
    var cacheKey = "test:token:concurrent";
    var accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.concurrent";
    var expiryTime = DateTimeOffset.UtcNow.AddMinutes(5);
    var tokenRecord = new TokenCacheEntry(accessToken, expiryTime);

    // Act - Cache the token
    await tokenCache.SetAsync(cacheKey, tokenRecord);

    // Act - Concurrent reads
    var tasks = new List<Task<TokenCacheEntry?>>();
    for (int i = 0; i < 10; i++)
    {
      tasks.Add(Task.Run(async () => await tokenCache.GetAsync(cacheKey)));
    }

    var results = await Task.WhenAll(tasks);

    // Assert - All should get the same token
    Assert.All(results, result =>
    {
      Assert.NotNull(result);
      Assert.Equal(accessToken, result.GetAccessToken());
    });
  }

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  public async Task TokenCache_GetAsync_WithInvalidKey_ThrowsArgumentException(string? invalidKey)
  {
    // Arrange
    var memoryCache = new MemoryCache(new MemoryCacheOptions());
    using var tokenCache = new TokenCache.TokenCache(memoryCache);

    // Act & Assert
    await Assert.ThrowsAsync<ArgumentException>(async () =>
      await tokenCache.GetAsync(invalidKey!));
  }

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  public async Task TokenCache_SetAsync_WithInvalidKey_ThrowsArgumentException(string? invalidKey)
  {
    // Arrange
    var memoryCache = new MemoryCache(new MemoryCacheOptions());
    using var tokenCache = new TokenCache.TokenCache(memoryCache);
    var tokenRecord = new TokenCacheEntry("token", DateTimeOffset.UtcNow.AddMinutes(5));

    // Act & Assert
    await Assert.ThrowsAsync<ArgumentException>(async () =>
      await tokenCache.SetAsync(invalidKey!, tokenRecord));
  }

  [Fact]
  public async Task TokenCache_SetAsync_WithNullTokenRecord_ThrowsArgumentException()
  {
    // Arrange
    var memoryCache = new MemoryCache(new MemoryCacheOptions());
    using var tokenCache = new TokenCache.TokenCache(memoryCache);
    var cacheKey = "test:token:null";

    // Act & Assert
    await Assert.ThrowsAsync<ArgumentException>(async () =>
      await tokenCache.SetAsync(cacheKey, null!));
  }

  [Fact]
  public async Task TokenCache_OperationsAfterDispose_ThrowsObjectDisposedException()
  {
    // Arrange
    var memoryCache = new MemoryCache(new MemoryCacheOptions());
    var tokenCache = new TokenCache.TokenCache(memoryCache);
    var cacheKey = "test:token:disposed";
    tokenCache.Dispose();

    // Act & Assert - GetAsync after dispose
    await Assert.ThrowsAsync<ObjectDisposedException>(async () =>
      await tokenCache.GetAsync(cacheKey));

    // Act & Assert - SetAsync after dispose
    var tokenRecord = new TokenCacheEntry("token", DateTimeOffset.UtcNow.AddMinutes(5));
    await Assert.ThrowsAsync<ObjectDisposedException>(async () =>
      await tokenCache.SetAsync(cacheKey, tokenRecord));
  }

  [Fact]
  public void TokenCacheRecord_IsValid_WhenNotExpired_ReturnsTrue()
  {
    // Arrange
    var accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.valid";
    var expiryTime = DateTimeOffset.UtcNow.AddMinutes(5);
    var tokenRecord = new TokenCacheEntry(accessToken, expiryTime);

    // Act
    var isValid = tokenRecord.IsValid;

    // Assert
    Assert.True(isValid);
    Assert.False(tokenRecord.IsExpired);
  }

  [Fact]
  public void TokenCacheRecord_IsValid_WhenExpired_ReturnsFalse()
  {
    // Arrange
    var accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.expired";
    var expiryTime = DateTimeOffset.UtcNow.AddSeconds(-1);
    var tokenRecord = new TokenCacheEntry(accessToken, expiryTime);

    // Act
    var isValid = tokenRecord.IsValid;

    // Assert
    Assert.False(isValid);
    Assert.True(tokenRecord.IsExpired);
  }

  [Fact]
  public void TokenCacheRecord_WithRefreshToken_HasRefreshTokenReturnsTrue()
  {
    // Arrange
    var accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.access";
    var refreshToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.refresh";
    var expiryTime = DateTimeOffset.UtcNow.AddMinutes(5);
    var tokenRecord = new TokenCacheEntry(accessToken, expiryTime, refreshToken);

    // Act & Assert
    Assert.True(tokenRecord.HasRefreshToken);
    Assert.Equal(refreshToken, tokenRecord.GetRefreshToken());
  }

  [Fact]
  public void TokenCacheRecord_UpdateTokens_UpdatesCorrectly()
  {
    // Arrange
    var oldAccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.old";
    var newAccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.new";
    var newRefreshToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.refresh";
    var oldExpiryTime = DateTimeOffset.UtcNow.AddMinutes(5);
    var newExpiryTime = DateTimeOffset.UtcNow.AddMinutes(10);
    
    var tokenRecord = new TokenCacheEntry(oldAccessToken, oldExpiryTime);

    // Act
    tokenRecord.UpdateTokens(newAccessToken, newExpiryTime, newRefreshToken);

    // Assert
    Assert.Equal(newAccessToken, tokenRecord.GetAccessToken());
    Assert.Equal(newExpiryTime, tokenRecord.ExpiryTime);
    Assert.True(tokenRecord.HasRefreshToken);
    Assert.Equal(newRefreshToken, tokenRecord.GetRefreshToken());
  }

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  public void TokenCacheRecord_Constructor_WithInvalidAccessToken_ThrowsArgumentException(string? invalidToken)
  {
    // Arrange
    var expiryTime = DateTimeOffset.UtcNow.AddMinutes(5);

    // Act & Assert
    Assert.Throws<ArgumentException>(() =>
      new TokenCacheEntry(invalidToken!, expiryTime));
  }

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  public void TokenCacheRecord_UpdateTokens_WithInvalidAccessToken_ThrowsArgumentException(string? invalidToken)
  {
    // Arrange
    var tokenRecord = new TokenCacheEntry("valid", DateTimeOffset.UtcNow.AddMinutes(5));
    var newExpiryTime = DateTimeOffset.UtcNow.AddMinutes(10);

    // Act & Assert
    Assert.Throws<ArgumentException>(() =>
      tokenRecord.UpdateTokens(invalidToken!, newExpiryTime));
  }

  [Fact]
  public void TokenCacheRecord_AfterDispose_ThrowsObjectDisposedException()
  {
    // Arrange
    var tokenRecord = new TokenCacheEntry("token", DateTimeOffset.UtcNow.AddMinutes(5));
    tokenRecord.Dispose();

    // Act & Assert - GetAccessToken after dispose
    Assert.Throws<ObjectDisposedException>(() => tokenRecord.GetAccessToken());

    // Act & Assert - GetRefreshToken after dispose
    Assert.Throws<ObjectDisposedException>(() => tokenRecord.GetRefreshToken());

    // Act & Assert - UpdateTokens after dispose
    Assert.Throws<ObjectDisposedException>(() =>
      tokenRecord.UpdateTokens("new", DateTimeOffset.UtcNow.AddMinutes(10)));
  }

  [Fact]
  public void SecureToken_IsValid_WhenNotExpired_ReturnsTrue()
  {
    // Arrange
    var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.test";
    var expiryTime = DateTimeOffset.UtcNow.AddMinutes(5);
    using var secureToken = new SecureToken(token, expiryTime);

    // Act & Assert
    Assert.True(secureToken.IsValid);
    Assert.False(secureToken.IsExpired);
  }

  [Fact]
  public void SecureToken_IsValid_WhenExpired_ReturnsFalse()
  {
    // Arrange
    var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.test";
    var expiryTime = DateTimeOffset.UtcNow.AddSeconds(-1);
    using var secureToken = new SecureToken(token, expiryTime);

    // Act & Assert
    Assert.False(secureToken.IsValid);
    Assert.True(secureToken.IsExpired);
  }

  [Fact]
  public void SecureToken_GetToken_ReturnsCorrectValue()
  {
    // Arrange
    var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.test";
    var expiryTime = DateTimeOffset.UtcNow.AddMinutes(5);
    using var secureToken = new SecureToken(token, expiryTime);

    // Act
    var retrievedToken = secureToken.GetToken();

    // Assert
    Assert.Equal(token, retrievedToken);
  }

  [Fact]
  public void SecureToken_UpdateToken_UpdatesCorrectly()
  {
    // Arrange
    var oldToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.old";
    var newToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.new";
    var oldExpiryTime = DateTimeOffset.UtcNow.AddMinutes(5);
    var newExpiryTime = DateTimeOffset.UtcNow.AddMinutes(10);
    using var secureToken = new SecureToken(oldToken, oldExpiryTime);

    // Act
    secureToken.UpdateToken(newToken, newExpiryTime);

    // Assert
    Assert.Equal(newToken, secureToken.GetToken());
    Assert.Equal(newExpiryTime, secureToken.ExpiryTime);
  }

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  public void SecureToken_Constructor_WithInvalidToken_ThrowsArgumentException(string? invalidToken)
  {
    // Arrange
    var expiryTime = DateTimeOffset.UtcNow.AddMinutes(5);

    // Act & Assert
    Assert.Throws<ArgumentException>(() =>
      new SecureToken(invalidToken!, expiryTime));
  }

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  public void SecureToken_UpdateToken_WithInvalidToken_ThrowsArgumentException(string? invalidToken)
  {
    // Arrange
    using var secureToken = new SecureToken("valid", DateTimeOffset.UtcNow.AddMinutes(5));
    var newExpiryTime = DateTimeOffset.UtcNow.AddMinutes(10);

    // Act & Assert
    Assert.Throws<ArgumentException>(() =>
      secureToken.UpdateToken(invalidToken!, newExpiryTime));
  }

  [Fact]
  public void SecureToken_AfterDispose_ThrowsObjectDisposedException()
  {
    // Arrange
    var secureToken = new SecureToken("token", DateTimeOffset.UtcNow.AddMinutes(5));
    secureToken.Dispose();

    // Act & Assert - GetToken after dispose
    Assert.Throws<ObjectDisposedException>(() => secureToken.GetToken());

    // Act & Assert - UpdateToken after dispose
    Assert.Throws<ObjectDisposedException>(() =>
      secureToken.UpdateToken("new", DateTimeOffset.UtcNow.AddMinutes(10)));
  }
}
