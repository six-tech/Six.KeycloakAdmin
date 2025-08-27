using System.Runtime.InteropServices;
using System.Security;

namespace Six.KeycloakAdmin.TokenProvider;

/// <summary>
/// Secure wrapper for JWT tokens that provides memory protection
/// </summary>
[PublicAPI]
public sealed class SecureToken : IDisposable
{
  private SecureString? _secureToken;
  private bool _disposed;

  public DateTimeOffset ExpiryTime { get; private set; }
  public bool IsExpired => DateTime.UtcNow >= ExpiryTime;
  public bool IsValid => !_disposed && _secureToken is not null && !IsExpired;

  public SecureToken(string token, DateTimeOffset expiryTime)
  {
    if(string.IsNullOrEmpty(token))
      throw new ArgumentException("Token cannot be null or empty", nameof(token));

    ExpiryTime = expiryTime;
    _secureToken = CreateSecureString(token);
  }

  public void Dispose()
  {
    if(_disposed) return;

    _secureToken?.Dispose();
    _secureToken = null;
    _disposed = true;
  }


  /// <summary>
  /// Safely retrieves the token value for use
  /// </summary>
  /// <returns>The decrypted token string</returns>
  public string GetToken()
  {
    ObjectDisposedException.ThrowIf(_disposed, this);

    if(_secureToken is null)
      throw new InvalidOperationException("Token is not available");

    return SecureStringToString(_secureToken);
  }

  /// <summary>
  /// Updates the token with a new value and expiry time
  /// </summary>
  public void UpdateToken(string newToken, DateTimeOffset newExpiryTime)
  {
    ObjectDisposedException.ThrowIf(_disposed, this);

    if(string.IsNullOrEmpty(newToken))
      throw new ArgumentException("Token cannot be null or empty", nameof(newToken));

    // Dispose old token
    _secureToken?.Dispose();

    // Create the new secure token
    _secureToken = CreateSecureString(newToken);
    ExpiryTime = newExpiryTime;
  }

  static SecureString CreateSecureString(string value)
  {
    var secureString = new SecureString();
    foreach(char c in value)
    {
      secureString.AppendChar(c);
    }

    secureString.MakeReadOnly();
    return secureString;
  }

  static string SecureStringToString(SecureString secureString)
  {
    IntPtr ptr = IntPtr.Zero;
    try
    {
      ptr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
      return Marshal.PtrToStringUni(ptr) ?? string.Empty;
    }
    finally
    {
      if(ptr != IntPtr.Zero)
      {
        Marshal.ZeroFreeGlobalAllocUnicode(ptr);
      }
    }
  }
}