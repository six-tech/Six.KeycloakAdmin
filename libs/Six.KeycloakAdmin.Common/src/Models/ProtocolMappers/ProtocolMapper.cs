namespace Six.KeycloakAdmin.Models.ProtocolMappers;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ProtocolMapper
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
	[JsonPropertyName("protocol")]
	public string Protocol { get; set; } = string.Empty;
	[JsonPropertyName("protocolMapper")]
	// ReSharper disable once InconsistentNaming
	public string _ProtocolMapper { get; set; } = string.Empty;
	[JsonPropertyName("consentRequired")]
	public bool? ConsentRequired { get; set; }
	[JsonPropertyName("config")]
	public Dictionary<string, string> Config { get; set; } = [];
}
