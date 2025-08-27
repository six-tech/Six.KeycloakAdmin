namespace Six.KeycloakAdmin.Models.Clients;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AccessToken
{
  [JsonPropertyName("acr")] public string Acr { get; set; } = string.Empty;
  [JsonPropertyName("address")] public AddressClaimSet Address { get; set; } = new();
  [JsonPropertyName("allowed-origins")] public IEnumerable<string> AllowedOrigins { get; set; } = [];
  [JsonPropertyName("at_hash")] public string AtHash { get; set; } = string.Empty;
  [JsonPropertyName("auth_time")] public int? AuthTime { get; set; }
  [JsonPropertyName("authorization")] public AccessTokenAuthorization Authorization { get; set; } = new();
  [JsonPropertyName("azp")] public string Azp { get; set; } = string.Empty;
  [JsonPropertyName("birthdate")] public string Birthdate { get; set; } = string.Empty;
  [JsonPropertyName("c_hash")] public string CHash { get; set; } = string.Empty;

  [JsonPropertyName("category")]
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public AccessTokenCategories Category { get; set; }

  [JsonPropertyName("claims_locales")] public string ClaimsLocales { get; set; } = string.Empty;
  [JsonPropertyName("cnf")] public AccessTokenCertConf Cnf { get; set; } = new();
  [JsonPropertyName("email")] public string Email { get; set; } = string.Empty;
  [JsonPropertyName("email_verified")] public bool? EmailVerified { get; set; }
  [JsonPropertyName("exp")] public int? Exp { get; set; }
  [JsonPropertyName("family_name")] public string FamilyName { get; set; } = string.Empty;
  [JsonPropertyName("gender")] public string Gender { get; set; } = string.Empty;
  [JsonPropertyName("given_name")] public string GivenName { get; set; } = string.Empty;
  [JsonPropertyName("iat")] public int? Iat { get; set; }
  [JsonPropertyName("iss")] public string Iss { get; set; } = string.Empty;
  [JsonPropertyName("jti")] public string Jti { get; set; } = string.Empty;
  [JsonPropertyName("locale")] public string Locale { get; set; } = string.Empty;
  [JsonPropertyName("middle_name")] public string MiddleName { get; set; } = string.Empty;
  [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
  [JsonPropertyName("nickname")] public string Nickname { get; set; } = string.Empty;
  [JsonPropertyName("nonce")] public string Nonce { get; set; } = string.Empty;

  [JsonPropertyName("otherClaims")]
  public IDictionary<string, object> OtherClaims { get; set; } = new Dictionary<string, object>();

  [JsonPropertyName("phone_number")] public string PhoneNumber { get; set; } = string.Empty;

  [JsonPropertyName("phone_number_verified")]
  public bool? PhoneNumberVerified { get; set; }

  [JsonPropertyName("picture")] public string Picture { get; set; } = string.Empty;

  [JsonPropertyName("preferred_username")]
  public string PreferredUsername { get; set; } = string.Empty;

  [JsonPropertyName("profile")] public string Profile { get; set; } = string.Empty;
  [JsonPropertyName("realm_access")] public AccessTokenAccess RealmAccess { get; set; } = new();
  [JsonPropertyName("s_hash")] public string Hash { get; set; } = string.Empty;
  [JsonPropertyName("scope")] public string Scope { get; set; } = string.Empty;
  [JsonPropertyName("session_state")] public string SessionState { get; set; } = string.Empty;
  [JsonPropertyName("sub")] public string Sub { get; set; } = string.Empty;
  [JsonPropertyName("trusted-certs")] public IEnumerable<string> TrustedCerts { get; set; } = [];
  [JsonPropertyName("typ")] public string Typ { get; set; } = string.Empty;
  [JsonPropertyName("updated_at")] public long UpdatedAt { get; set; }
  [JsonPropertyName("website")] public string Website { get; set; } = string.Empty;
  [JsonPropertyName("zoneinfo")] public string Zoneinfo { get; set; } = string.Empty;
}
