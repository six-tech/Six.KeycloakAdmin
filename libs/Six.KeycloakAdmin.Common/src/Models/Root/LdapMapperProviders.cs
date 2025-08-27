namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record LdapMapperProviders
{
  [JsonPropertyName("msad-lds-user-account-control-mapper")]
  public HasOrder MsadLdsUserAccountControlMapper { get; set; } = new();

  [JsonPropertyName("msad-user-account-control-mapper")]
  public HasOrder MsadUserAccountControlMapper { get; set; } = new();

  [JsonPropertyName("group-ldap-mapper")]
  public HasOrder GroupLdapMapper { get; set; } = new();

  [JsonPropertyName("user-attribute-ldap-mapper")]
  public HasOrder UserAttributeLdapMapper { get; set; } = new();

  [JsonPropertyName("role-ldap-mapper")] public HasOrder RoleLdapMapper { get; set; } = new();

  [JsonPropertyName("hardcoded-ldap-role-mapper")]
  public HasOrder HardcodedLdapRoleMapper { get; set; } = new();

  [JsonPropertyName("full-name-ldap-mapper")]
  public HasOrder FullNameLdapMapper { get; set; } = new();

  [JsonPropertyName("hardcoded-ldap-attribute-mapper")]
  public HasOrder HardcodedLdapAttributeMapper { get; set; } = new();

  [JsonPropertyName("hardcoded-ldap-group-mapper")]
  public HasOrder HardcodedLdapGroupMapper { get; set; } = new();
}
