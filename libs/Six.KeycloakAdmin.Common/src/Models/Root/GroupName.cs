using System.Runtime.Serialization;
using Six.KeyCloak.Common.Converters;

namespace Six.KeycloakAdmin.Models.Root;

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<GroupName>))]
public enum GroupName
{
	Social,
	[EnumMember(Value = "User-defined")]
	UserDefined
}
