namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record BruteForceProtectorProviders
{
	[JsonPropertyName("default-brute-force-detector")]
	public HasOrder DefaultBruteForceDetector { get; set; } = new();
}
