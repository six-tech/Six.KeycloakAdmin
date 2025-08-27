namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ServerInfoProviders
{
	[JsonPropertyName("account")]
	public EmailTemplateClass Account { get; set; } = new();

	[JsonPropertyName("actionToken")]
	public ActionToken ActionToken { get; set; } = new();

	[JsonPropertyName("actionTokenHandler")]
	public ActionTokenHandler ActionTokenHandler { get; set; } = new();

	[JsonPropertyName("authenticationSessions")]
	public ActionToken AuthenticationSessions { get; set; } = new();

	[JsonPropertyName("authenticator")]
	public Authenticator Authenticator { get; set; } = new();

	[JsonPropertyName("authorization")]
	public Authorization Authorization { get; set; } = new();

	[JsonPropertyName("authorizationCache")]
	public AuthorizationCache AuthorizationCache { get; set; } = new();

	[JsonPropertyName("authorizationPersister")]
	public AuthorizationPersister AuthorizationPersister { get; set; } = new();

	[JsonPropertyName("bruteForceProtector")]
	public BruteForceProtector BruteForceProtector { get; set; } = new();

	[JsonPropertyName("client-authenticator")]
	public ClientAuthenticator ClientAuthenticator { get; set; } = new();

	[JsonPropertyName("client-description-converter")]
	public ClientDescriptionConverter ClientDescriptionConverter { get; set; } = new();

	[JsonPropertyName("client-installation")]
	public Authenticator ClientInstallation { get; set; } = new();

	[JsonPropertyName("client-registration")]
	public ClientRegistration ClientRegistration { get; set; } = new();

	[JsonPropertyName("client-registration-policy")]
	public ClientRegistrationPolicy ClientRegistrationPolicy { get; set; } = new();

	[JsonPropertyName("client-storage")]
	public ClientStorage ClientStorage { get; set; } = new();

	[JsonPropertyName("clientSignature")]
	public Authenticator ClientSignature { get; set; } = new();

	[JsonPropertyName("cluster")]
	public ActionToken Cluster { get; set; } = new();

	[JsonPropertyName("codeToTokenStore")]
	public ActionToken CodeToTokenStore { get; set; } = new();

	[JsonPropertyName("connectionsHttpClient")]
	public AuthorizationCache ConnectionsHttpClient { get; set; } = new();

	[JsonPropertyName("connectionsInfinispan")]
	public AuthorizationCache ConnectionsInfinispan { get; set; } = new();

	[JsonPropertyName("connectionsJpa")]
	public ConnectionsJpa ConnectionsJpa { get; set; } = new();

	[JsonPropertyName("connectionsJpaUpdater")]
	public ConnectionsJpaUpdater ConnectionsJpaUpdater { get; set; } = new();

	[JsonPropertyName("connectionsLiquibase")]
	public AuthorizationCache ConnectionsLiquibase { get; set; } = new();

	[JsonPropertyName("credential")]
	public Credential Credential { get; set; } = new();

	[JsonPropertyName("dblock")]
	public AuthorizationPersister Dblock { get; set; } = new();

	[JsonPropertyName("emailSender")]
	public AuthorizationCache EmailSender { get; set; } = new();

	[JsonPropertyName("emailTemplate")]
	public EmailTemplateClass EmailTemplate { get; set; } = new();

	[JsonPropertyName("eventsListener")]
	public EventsListener EventsListener { get; set; } = new();

	[JsonPropertyName("eventsStore")]
	public AuthorizationPersister EventsStore { get; set; } = new();

	[JsonPropertyName("exception-converter")]
	public AuthorizationPersister ExceptionConverter { get; set; } = new();

	[JsonPropertyName("executors")]
	public AuthorizationCache Executors { get; set; } = new();

	[JsonPropertyName("export")]
	public Port Export { get; set; } = new();

	[JsonPropertyName("form-action")]
	public FormAction FormAction { get; set; } = new();

	[JsonPropertyName("form-authenticator")]
	public FormAuthenticator FormAuthenticator { get; set; } = new();

	[JsonPropertyName("hash")]
	public Hash Hash { get; set; } = new();

	[JsonPropertyName("hostname")]
	public Hostname Hostname { get; set; } = new();

	[JsonPropertyName("identity-provider-mapper")]
	public Authenticator IdentityProviderMapper { get; set; } = new();

	[JsonPropertyName("identity_provider")]
	public IdentityProvider IdentityProvider { get; set; } = new();

	[JsonPropertyName("import")]
	public Port Import { get; set; } = new();

	[JsonPropertyName("jpa-entity-provider")]
	public ClientStorage JpaEntityProvider { get; set; } = new();

	[JsonPropertyName("jta-lookup")]
	public JtaLookup JtaLookup { get; set; } = new();

	[JsonPropertyName("keys")]
	public Keys Keys { get; set; } = new();

	[JsonPropertyName("ldap-mapper")]
	public LdapMapper LdapMapper { get; set; } = new();

	[JsonPropertyName("localeSelector")]
	public AuthorizationCache LocaleSelector { get; set; } = new();

	[JsonPropertyName("login")]
	public EmailTemplateClass Login { get; set; } = new();

	[JsonPropertyName("login-protocol")]
	public LoginProtocol LoginProtocol { get; set; } = new();

	[JsonPropertyName("migration")]
	public AuthorizationCache Migration { get; set; } = new();

	[JsonPropertyName("oauth2-token-introspection")]
	public Oauth2TokenIntrospection Oauth2TokenIntrospection { get; set; } = new();

	[JsonPropertyName("openid-connect-ext")]
	public ClientStorage OpenIdConnectExt { get; set; } = new();

	[JsonPropertyName("password-hashing")]
	public Authenticator PasswordHashing { get; set; } = new();

	[JsonPropertyName("password-policy")]
	public Authenticator PasswordPolicy { get; set; } = new();

	[JsonPropertyName("password-policy-manager")]
	public AuthorizationCache PasswordPolicyManager { get; set; } = new();

	[JsonPropertyName("policy")]
	public Policy Policy { get; set; } = new();

	[JsonPropertyName("protocol-mapper")]
	public Authenticator ProtocolMapper { get; set; } = new();

	[JsonPropertyName("publicKeyStorage")]
	public ActionToken PublicKeyStorage { get; set; } = new();

	[JsonPropertyName("realm")]
	public AuthorizationPersister Realm { get; set; } = new();

	[JsonPropertyName("realm-restapi-extension")]
	public ClientStorage RealmRestapiExtension { get; set; } = new();

	[JsonPropertyName("realmCache")]
	public AuthorizationCache RealmCache { get; set; } = new();

	[JsonPropertyName("required-action")]
	public RequiredAction RequiredAction { get; set; } = new();

	[JsonPropertyName("scripting")]
	public Scripting Scripting { get; set; } = new();

	[JsonPropertyName("signature")]
	public Authenticator Signature { get; set; } = new();

	[JsonPropertyName("singleUseTokenStore")]
	public ActionToken SingleUseTokenStore { get; set; } = new();

	[JsonPropertyName("social")]
	public Authenticator Social { get; set; } = new();

	[JsonPropertyName("stickySessionEncoder")]
	public ActionToken StickySessionEncoder { get; set; } = new();

	[JsonPropertyName("storage")]
	public Storage Storage { get; set; } = new();

	[JsonPropertyName("theme")]
	public Theme Theme { get; set; } = new();

	[JsonPropertyName("themeResource")]
	public ClientStorage ThemeResource { get; set; } = new();

	[JsonPropertyName("themeSelector")]
	public AuthorizationCache ThemeSelector { get; set; } = new();

	[JsonPropertyName("timer")]
	public Timer Timer { get; set; } = new();

	[JsonPropertyName("truststore")]
	public Truststore Truststore { get; set; } = new();

	[JsonPropertyName("user")]
	public AuthorizationPersister User { get; set; } = new();

	[JsonPropertyName("userCache")]
	public AuthorizationCache UserCache { get; set; } = new();

	[JsonPropertyName("userFederatedStorage")]
	public AuthorizationPersister UserFederatedStorage { get; set; } = new();

	[JsonPropertyName("userSessionPersister")]
	public AuthorizationPersister UserSessionPersister { get; set; } = new();

	[JsonPropertyName("userSessions")]
	public ActionToken UserSessions { get; set; } = new();

	[JsonPropertyName("well-known")]
	public WellKnown WellKnown { get; set; } = new();

	[JsonPropertyName("x509cert-lookup")]
	public AuthorizationCache X509CertLookup { get; set; } = new();
}
