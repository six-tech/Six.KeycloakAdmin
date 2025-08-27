namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ServerInfo
{
	[JsonPropertyName("systemInfo")]
	public SystemInfo SystemInfo { get; set; } = new();

	[JsonPropertyName("memoryInfo")]
	public MemoryInfo MemoryInfo { get; set; } = new();

	[JsonPropertyName("profileInfo")]
	public ProfileInfo ProfileInfo { get; set; } = new();

	[JsonPropertyName("themes")]
	public Themes Themes { get; set; } = new();

	[JsonPropertyName("socialProviders")]
	public List<Provider> SocialProviders { get; set; } = [];

	[JsonPropertyName("identityProviders")]
	public List<Provider> IdentityProviders { get; set; } = [];

	[JsonPropertyName("providers")]
	public ServerInfoProviders Providers { get; set; } = new();

	[JsonPropertyName("protocolMapperTypes")]
	public ProtocolMapperTypes ProtocolMapperTypes { get; set; } = new();

	[JsonPropertyName("builtinProtocolMappers")]
	public BuiltinProtocolMappers BuiltinProtocolMappers { get; set; } = new();

	[JsonPropertyName("clientInstallations")]
	public ClientInstallations ClientInstallations { get; set; } = new();

	[JsonPropertyName("componentTypes")]
	public ComponentTypes ComponentTypes { get; set; } = new();

	[JsonPropertyName("passwordPolicies")]
	public List<PasswordPolicy> PasswordPolicies { get; set; } = [];

	[JsonPropertyName("enums")]
	public Enums Enums { get; set; } = new();
}
