namespace Six.KeycloakAdmin.Models.Clients;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record AddressClaimSet
{
	[JsonPropertyName("country")]
	public string Country { get; set; } = string.Empty;
	[JsonPropertyName("formatted")]
	public string Formatted { get; set; } = string.Empty;
	[JsonPropertyName("locality")]
	public string Locality { get; set; } = string.Empty;
	[JsonPropertyName("postal_code")]
	public string PostalCode { get; set; } = string.Empty;
	[JsonPropertyName("region")]
	public string Region { get; set; } = string.Empty;
	[JsonPropertyName("street_address")]
	public string StreetAddress { get; set; } = string.Empty;
}
