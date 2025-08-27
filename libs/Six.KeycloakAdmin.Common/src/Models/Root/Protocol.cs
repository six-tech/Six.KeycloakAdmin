using System.Runtime.Serialization;
using Six.KeyCloak.Common.Converters;

namespace Six.KeycloakAdmin.Models.Root;

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<Protocol>))]
public enum Protocol
{
	[EnumMember(Value = "docker-v2")]
	DockerV2,
	[EnumMember(Value = "openid-connect")]
	OpenIdConnect,
	Saml
}
