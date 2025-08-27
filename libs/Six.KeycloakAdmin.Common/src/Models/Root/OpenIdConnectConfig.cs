namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record OpenIdConnectConfig
{
	[JsonPropertyName("userinfo.token.claim")]
	public string? UserInfoTokenClaim { get; set; }

	[JsonPropertyName("user.attribute")]
	public string UserAttribute { get; set; } = string.Empty;

	[JsonPropertyName("id.token.claim")]
	public string? IdTokenClaim { get; set; }

	[JsonPropertyName(("introspection.token.claim"))]
	public string? IntrospectionTokenClaim { get; set; }

	[JsonPropertyName("access.token.claim")]
	public string? AccessTokenClaim { get; set; }

	[JsonPropertyName("claim.name")]
	public string ClaimName { get; set; } = string.Empty;

	[JsonPropertyName("jsonType.label")]
	public JsonTypeLabel? JsonTypeLabel { get; set; }

	[JsonPropertyName("user.attribute.formatted")]
	public string UserAttributeFormatted { get; set; } = string.Empty;

	[JsonPropertyName("user.attribute.country")]
	public string UserAttributeCountry { get; set; } = string.Empty;

	[JsonPropertyName("user.attribute.postal_code")]
	public string UserAttributePostalCode { get; set; } = string.Empty;

	[JsonPropertyName("user.attribute.street")]
	public string UserAttributeStreet { get; set; } = string.Empty;

	[JsonPropertyName("user.attribute.region")]
	public string UserAttributeRegion { get; set; } = string.Empty;

	[JsonPropertyName("user.attribute.locality")]
	public string UserAttributeLocality { get; set; } = string.Empty;

	[JsonPropertyName("user.session.note")]
	public string UserSessionNote { get; set; } = string.Empty;

	[JsonPropertyName("multivalued")]
	public string? Multivalued { get; set; }
}
