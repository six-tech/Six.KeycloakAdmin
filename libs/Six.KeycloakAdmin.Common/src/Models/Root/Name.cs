using System.Runtime.Serialization;

namespace Six.KeycloakAdmin.Models.Root;

public enum Name
{
	Base,
	Keycloak,
	[EnumMember(Value = "keycloak.v2")]
	KeycloakV2,
	[EnumMember(Value = "keycloak.v3")]
	KeycloakV3,
	RhSso
}
