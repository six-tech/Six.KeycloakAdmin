using Six.KeyCloak.Common.Converters;

namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Common
{
	[JsonPropertyName("name")]
	[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<Name>))]
	public Name Name { get; set; }
}
