namespace Six.KeycloakAdmin.Models.Clients;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Resource
{
	[JsonPropertyName("rsid")]
	public string RsId { get; set; } = string.Empty;

	[JsonPropertyName("rsname")]
	public string RsName { get; set; } = string.Empty;

	[JsonPropertyName("scopes")]
	public IEnumerable<string> Scopes { get; set; } = [];
}
