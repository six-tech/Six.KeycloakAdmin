using Six.KeycloakAdmin.TokenProvider;

namespace Six.KeycloakAdmin.TokenCache;

/// <summary>
/// Cache record containing access token, refresh token, and expiry information
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public sealed record TokenCacheEntry : IDisposable
{
  public SecureToken AccessToken { get; private set; }
  public SecureToken? RefreshToken { get; private set; }
  public DateTimeOffset ExpiryTime { get; private set; }

  bool _disposed;

  public bool IsExpired => DateTime.UtcNow >= ExpiryTime;
  public bool IsValid => !_disposed && AccessToken.IsValid && !IsExpired;
  public bool HasRefreshToken => RefreshToken is not null && RefreshToken.IsValid;

  public TokenCacheEntry(
    string accessToken,
    DateTimeOffset expiryTime,
    string? refreshToken = null)
  {
    if(string.IsNullOrEmpty(accessToken))
      throw new ArgumentException("Access token cannot be null or empty", nameof(accessToken));

    AccessToken = new SecureToken(accessToken, expiryTime);
    ExpiryTime = expiryTime;

    if(!string.IsNullOrEmpty(refreshToken))
    {
      RefreshToken = new SecureToken(refreshToken, expiryTime.AddDays(30)); // Refresh tokens typically last longer
    }
  }

  /// <summary>
  /// Gets the access token value
  /// </summary>
  public string GetAccessToken()
  {
    ObjectDisposedException.ThrowIf(_disposed, this);
    return AccessToken.GetToken();
  }

  /// <summary>
  /// Gets the refresh token value if available
  /// </summary>
  public string? GetRefreshToken()
  {
    ObjectDisposedException.ThrowIf(_disposed, this);
    return RefreshToken?.GetToken();
  }

  /// <summary>
  /// Updates the record with new token information
  /// </summary>
  public void UpdateTokens(string newAccessToken, DateTimeOffset newExpiryTime, string? newRefreshToken = null)
  {
    ObjectDisposedException.ThrowIf(_disposed, this);

    if(string.IsNullOrEmpty(newAccessToken))
      throw new ArgumentException("Access token cannot be null or empty", nameof(newAccessToken));

    // Update access token
    AccessToken.UpdateToken(newAccessToken, newExpiryTime);
    ExpiryTime = newExpiryTime;

    // Update refresh token if provided
    if(!string.IsNullOrEmpty(newRefreshToken))
    {
      RefreshToken?.Dispose();
      RefreshToken = new SecureToken(newRefreshToken, newExpiryTime.AddDays(30));
    }
  }

  public void Dispose()
  {
    if(_disposed) return;

    AccessToken?.Dispose();
    RefreshToken?.Dispose();
    _disposed = true;
  }
}