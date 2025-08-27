using System.Runtime.Serialization;
using Six.KeyCloak.Common.Converters;

namespace Six.KeycloakAdmin.Models.Root;

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<Locale>))]
public enum Locale
{
	[EnumMember(Value = "en")]
	En,
	[EnumMember(Value = "ar")]
	Ar,
	[EnumMember(Value = "ca")]
	Ca,
	[EnumMember(Value = "cs")]
	Cs,
	[EnumMember(Value = "da")]
	Da,
	[EnumMember(Value = "de")]
	De,
	[EnumMember(Value = "el")]
	El,
	[EnumMember(Value = "es")]
	Es,
	[EnumMember(Value = "fa")]
	Fa,
	[EnumMember(Value = "fr")]
	Fr,
	[EnumMember(Value = "fi")]
	Fi,
	[EnumMember(Value = "hu")]
	Hu,
	[EnumMember(Value = "it")]
	It,
	[EnumMember(Value = "ja")]
	Ja,
	[EnumMember(Value = "ko")]
	Ko,  // Korean
	[EnumMember(Value = "lt")]
	Lt,
	[EnumMember(Value = "lv")]
	Lv,
	[EnumMember(Value = "nl")]
	Nl,
	[EnumMember(Value = "no")]
	No,
	[EnumMember(Value = "pl")]
	Pl,
	[EnumMember(Value = "pt")]
	Pt,
	[EnumMember(Value = "pt-BR")]
	PtBr,
	[EnumMember(Value = "ru")]
	Ru,
	[EnumMember(Value = "sk")]
	Sk,
	[EnumMember(Value = "sv")]
	Sv,
	[EnumMember(Value = "th")]
	Th,
	[EnumMember(Value = "tr")]
	Tr,
	[EnumMember(Value = "uk")]
	Uk,
	[EnumMember(Value = "zh-CN")]
	ZhCn,
	[EnumMember(Value = "zh-TW")]
	ZhTw,
	// Additional locales that might be present in newer Keycloak versions
	[EnumMember(Value = "id")]
	Id,  // Indonesian
	[EnumMember(Value = "hr")]
	Hr,  // Croatian
	[EnumMember(Value = "ro")]
	Ro,  // Romanian
	[EnumMember(Value = "et")]
	Et,  // Estonian
	[EnumMember(Value = "bg")]
	Bg,  // Bulgarian
	[EnumMember(Value = "he")]
	He,  // Hebrew
	[EnumMember(Value = "hi")]
	Hi,  // Hindi
	[EnumMember(Value = "vi")]
	Vi,  // Vietnamese
	[EnumMember(Value = "en-US")]
	EnUs  // English US variant
}
