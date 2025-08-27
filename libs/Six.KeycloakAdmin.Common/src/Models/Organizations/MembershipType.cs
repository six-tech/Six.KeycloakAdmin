using System.Runtime.Serialization;
using Six.KeyCloak.Common.Converters;

namespace Six.KeycloakAdmin.Models.Organizations;

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<MembershipType>))]
public enum MembershipType
{
	
	[EnumMember(Value = "MANAGED")]
	Managed,
	[EnumMember(Value = "UNMANAGED")]
	Unmanaged,
}
