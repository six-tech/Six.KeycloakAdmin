namespace Six.KeycloakAdmin.Models.RealmsAdmin;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record IdentityProvider
{
	[JsonPropertyName("alias")]
	public string Alias { get; set; } = string.Empty;
	[JsonPropertyName("internalId")]
	public string InternalId { get; set; } = string.Empty;
	[JsonPropertyName("providerId")]
	public string ProviderId { get; set; } = string.Empty;
	[JsonPropertyName("enabled")]
	public bool? Enabled { get; set; }
	[JsonPropertyName("updateProfileFirstLoginMode")]
	public string UpdateProfileFirstLoginMode { get; set; } = string.Empty;
	[JsonPropertyName("trustEmail")]
	public bool? TrustEmail { get; set; }
	[JsonPropertyName("storeToken")]
	public bool? StoreToken { get; set; }
	[JsonPropertyName("addReadTokenRoleOnCreate")]
	public bool? AddReadTokenRoleOnCreate { get; set; }
	[JsonPropertyName("authenticateByDefault")]
	public bool? AuthenticateByDefault { get; set; }
	[JsonPropertyName("linkOnly")]
	public bool? LinkOnly { get; set; }
	[JsonPropertyName("firstBrokerLoginFlowAlias")]
	public string FirstBrokerLoginFlowAlias { get; set; } = string.Empty;
	[JsonPropertyName("config")]
	public Config Config { get; set; } = new();
}
