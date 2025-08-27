using Microsoft.Extensions.Caching.Memory;
using Six.KeycloakAdmin.TokenProvider;

namespace Six.KeycloakAdmin.TokenCache;

/// <summary>
/// Implementation of token cache using in-memory caching with TokenCacheRecord storage
/// </summary>
[PublicAPI]
public sealed class TokenCache : ITokenCache, IDisposable
{
  readonly IMemoryCache _memoryCache;
  readonly SemaphoreSlim _semaphore = new(1, 1);
  bool _disposed;

  public TokenCache(IMemoryCache memoryCache)
  {
    _memoryCache = memoryCache;
  }

  public async Task<TokenCacheEntry?> GetAsync(string key, CancellationToken cancellationToken = default)
  {
    if(_disposed)
      throw new ObjectDisposedException(nameof(TokenCache));

    if(string.IsNullOrEmpty(key))
      throw new ArgumentException("Cache key cannot be null or empty", nameof(key));

    await _semaphore.WaitAsync(cancellationToken);
    try
    {
      if(_memoryCache.TryGetValue<TokenCacheEntry>(key, out var cachedRecord))
      {
        if(cachedRecord is not null)
        {
          // Return valid tokens immediately
          if(cachedRecord.IsValid)
            return cachedRecord;
          
          // If access token is expired but has a valid refresh token, 
          // return the record so the refresh token can be used
          if(cachedRecord.IsExpired && cachedRecord.HasRefreshToken)
            return cachedRecord;
          
          // Token is invalid and has no refresh token, remove it
          _memoryCache.Remove(key);
          cachedRecord.Dispose();
        }
      }

      return null;
    }
    finally
    {
      _semaphore.Release();
    }
  }

  public async Task SetAsync(
    string key, 
    TokenCacheEntry tokenEntry,
    CancellationToken cancellationToken = default)
  {
    if(_disposed)
      throw new ObjectDisposedException(nameof(TokenCache));

    if(string.IsNullOrEmpty(key))
      throw new ArgumentException("Cache key cannot be null or empty", nameof(key));

    if(tokenEntry is null)
      throw new ArgumentException("Token record cannot be null", nameof(tokenEntry));

    await _semaphore.WaitAsync(cancellationToken);
    try
    {
      // Remove any existing token for this key
      if(_memoryCache.TryGetValue<TokenCacheEntry>(key, out var existingRecord))
      {
        existingRecord?.Dispose();
        _memoryCache.Remove(key);
      }

      // Calculate cache expiration with a small buffer before actual token expiry
      var cacheExpiration = tokenEntry.ExpiryTime.Subtract(TimeSpan.FromSeconds(30));
      if(cacheExpiration <= DateTimeOffset.UtcNow)
      {
        // Token is already expired or will expire too soon, don't cache it
        // Note: We don't dispose here - the caller is responsible for disposal
        return;
      }

      // Set up cache entry options with expiration
      // Note: We don't dispose on eviction because the record might still be needed
      // for refresh token operations after cache expiry
      var cacheEntryOptions = new MemoryCacheEntryOptions
      {
        AbsoluteExpiration = cacheExpiration
      };

      _memoryCache.Set(key, tokenEntry, cacheEntryOptions);
    }
    finally
    {
      _semaphore.Release();
    }
  }

  public void Remove(string key)
  {
    if(_disposed)
      return;

    if(string.IsNullOrEmpty(key))
      return;

    _semaphore.Wait();
    try
    {
      if(_memoryCache.TryGetValue<TokenCacheEntry>(key, out var record))
      {
        record?.Dispose();
      }

      _memoryCache.Remove(key);
    }
    finally
    {
      _semaphore.Release();
    }
  }

  public void Clear()
  {
    if(_disposed)
      return;

    // Note: IMemoryCache doesn't have a Clear method in the standard interface
    // This would need to be handled by the specific implementation or by tracking keys separately
  }

  public void Dispose()
  {
    if(_disposed)
      return;

    _semaphore?.Dispose();
    _disposed = true;
  }
}