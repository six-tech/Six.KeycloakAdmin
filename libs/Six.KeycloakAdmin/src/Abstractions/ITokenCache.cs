using Six.KeycloakAdmin.TokenCache;

namespace Six.KeycloakAdmin;

/// <summary>
/// Interface for caching authentication tokens securely
/// </summary>
public interface ITokenCache
{
    /// <summary>
    /// Gets a cached token record if it exists and is valid
    /// </summary>
    /// <param name="key">The cache key for the token</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A valid TokenCacheRecord or null if not found/expired</returns>
    Task<TokenCacheEntry?> GetAsync(string key, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Stores a token record in the cache
    /// </summary>
    /// <param name="key">The cache key for the token</param>
    /// <param name="tokenEntry">The token record to cache</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task SetAsync(string key, TokenCacheEntry tokenEntry, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Removes a token from the cache
    /// </summary>
    /// <param name="key">The cache key for the token</param>
    void Remove(string key);
    
    /// <summary>
    /// Clears all tokens from the cache
    /// </summary>
    void Clear();
}
