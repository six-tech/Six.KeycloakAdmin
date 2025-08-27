using Six.KeycloakAdmin.Services;

namespace Six.KeycloakAdmin;

/// <summary>
/// Interface for Keycloak admin
/// </summary>
[PublicAPI]
public interface IKeycloakAdminProvider
{
    AttackDetection AttackDetection { get; }
    AuthenticationManagement AuthenticationManagement { get; }
    AuthZResource AuthorizationResource { get; }
    AuthZScope AuthorizationScope { get; }
    ClientAuthorization ClientAuthorization { get; }
    ClientAttributeCertificate ClientAttributeCertificate { get; }
    ClientInitialAccess ClientInitialAccess { get; }
    ClientRegistrationPolicy ClientRegistrationPolicy { get; }
    Clients Clients { get; }
    ClientScopes ClientScopes { get; }
    ProtocolMappers ProtocolMappers { get; }
    ScopeMappings ScopeMappings { get; }
    Components Components { get; }
    ClientRoleMappings ClientRoleMappings { get; }
    Groups Groups { get; }
    GroupsRoleMapper GroupsRoleMapper { get; }
    IdentityProviders IdentityProviders { get; }
    Keys Keys { get; }
    OpenIDConfiguration OpenIdConfiguration { get; }
    Organizations Organizations { get; }
    Realms Realms { get; }
    Roles Roles { get; }
    RolesById RolesById { get; }
    ServerInfo ServerInfo { get; }
    UserStorageProvider UserStorageProvider { get; }
    Users Users { get; }
    
    /// <summary>
    /// Sets a custom JSON serializer for the client
    /// </summary>
    void SetSerializer(IKeycloakJsonSerializer keycloakJsonSerializer);
}
