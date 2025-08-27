namespace Six.KeycloakAdmin;

/// <summary>
/// Service for creating and managing Keycloak client instances
/// </summary>
public interface IKeycloakAdminService
{
    /// <summary>
    /// Creates a Keycloak client authenticated with username and password
    /// </summary>
    /// <param name="username">The username</param>
    /// <param name="password">The password</param>
    /// <returns>A configured KeycloakClient instance</returns>
    IKeycloakAdminProvider GetAdminWithBasicAuth(
        string username, 
        string password);
    
    /// <summary>
    /// Creates a Keycloak client authenticated with client credentials
    /// </summary>
    /// <param name="clientSecret">The client secret</param>
    /// <returns>A configured KeycloakClient instance</returns>
    IKeycloakAdminProvider GetAdminWithSecret(
        string clientSecret);
    
    /// <summary>
    /// Creates a Keycloak client with a pre-existing token
    /// </summary>
    /// <param name="token">The authentication token</param>
    /// <returns>A configured KeycloakClient instance</returns>
    IKeycloakAdminProvider GetAdminWithToken(string token);
}
