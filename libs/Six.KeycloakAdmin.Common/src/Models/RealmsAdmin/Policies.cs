using System.Runtime.Serialization;
using Six.KeyCloak.Common.Converters;

namespace Six.KeycloakAdmin.Models.RealmsAdmin;

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<Policies>))]
public enum Policies
{
	[EnumMember(Value = "SKIP")]
	Skip,
	[EnumMember(Value = "OVERWRITE")]
	Overwrite,
	[EnumMember(Value = "FAIL")]
	Fail
}
