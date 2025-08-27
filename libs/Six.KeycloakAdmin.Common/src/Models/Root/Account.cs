using Six.KeyCloak.Common.Converters;

namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Account
{
	[JsonPropertyName("name")]
	[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<Name>))]
	public Name Name { get; set; }

	[JsonPropertyName("locales")]
	public List<Locale> Locales { get; set; } = [];
}
