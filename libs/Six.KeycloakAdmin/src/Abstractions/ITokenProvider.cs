namespace Six.KeycloakAdmin;

/// <summary>
/// Interface for token providers that obtain authentication tokens from Keycloak
/// </summary>
public interface ITokenProvider
{
    /// <summary>
    /// Gets an authentication token for the specified realm and credentials
    /// </summary>
    /// <param name="realm">The Keycloak realm</param>
    /// <param name="credentials">Authentication credentials (username/password or client credentials)</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The authentication token or null if authentication fails</returns>
    Task<string?> GetTokenAsync(string realm, object credentials, CancellationToken cancellationToken = default);
}