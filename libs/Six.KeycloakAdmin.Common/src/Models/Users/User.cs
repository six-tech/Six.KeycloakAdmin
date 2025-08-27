namespace Six.KeycloakAdmin.Models.Users;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record User
{
  [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
  [JsonPropertyName("createdTimestamp")] public long CreatedTimestamp { get; set; }
  [JsonPropertyName("username")] public string UserName { get; set; } = string.Empty;
  [JsonPropertyName("enabled")] public bool? Enabled { get; set; }
  [JsonPropertyName("totp")] public bool? Totp { get; set; }
  [JsonPropertyName("emailVerified")] public bool? EmailVerified { get; set; }
  [JsonPropertyName("firstName")] public string FirstName { get; set; } = string.Empty;
  [JsonPropertyName("lastName")] public string LastName { get; set; } = string.Empty;
  [JsonPropertyName("email")] public string Email { get; set; } = string.Empty;

  [JsonPropertyName("disableableCredentialTypes")]
  public IReadOnlyCollection<string> DisableableCredentialTypes { get; set; } = [];

  [JsonPropertyName("requiredActions")] public IReadOnlyCollection<string> RequiredActions { get; set; } = [];
  [JsonPropertyName("notBefore")] public int? NotBefore { get; set; }
  [JsonPropertyName("access")] public UserAccess? Access { get; set; }

  [JsonPropertyName("attributes")] public Dictionary<string, IEnumerable<string>> Attributes { get; set; } = [];
  [JsonPropertyName("clientConsents")] public IEnumerable<UserConsent> ClientConsents { get; set; } = [];

  [JsonPropertyName("clientRoles")]
  public IDictionary<string, object> ClientRoles { get; set; } = new Dictionary<string, object>();

  [JsonPropertyName("credentials")] public IEnumerable<Credentials> Credentials { get; set; } = [];

  [JsonPropertyName("federatedIdentities")]
  public IEnumerable<FederatedIdentity> FederatedIdentities { get; set; } = [];

  [JsonPropertyName("federationLink")] public string FederationLink { get; set; } = string.Empty;
  [JsonPropertyName("groups")] public IEnumerable<string> Groups { get; set; } = [];
  [JsonPropertyName("origin")] public string Origin { get; set; } = string.Empty;
  [JsonPropertyName("realmRoles")] public IEnumerable<string> RealmRoles { get; set; } = [];
  [JsonPropertyName("self")] public string Self { get; set; } = string.Empty;

  [JsonPropertyName("serviceAccountClientId")]
  public string ServiceAccountClientId { get; set; } = string.Empty;
}
