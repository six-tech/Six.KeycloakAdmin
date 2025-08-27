namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record MemoryInfo
{
	[JsonPropertyName("total")]
	public long Total { get; set; }

	[JsonPropertyName("totalFormated")]
	public string TotalFormatted { get; set; } = string.Empty;

	[JsonPropertyName("used")]
	public long Used { get; set; }

	[JsonPropertyName("usedFormated")]
	public string UsedFormatted { get; set; } = string.Empty;

	[JsonPropertyName("free")]
	public long Free { get; set; }

	[JsonPropertyName("freePercentage")]
	public long FreePercentage { get; set; }

	[JsonPropertyName("freeFormated")]
	public string FreeFormatted { get; set; } = string.Empty;
}
