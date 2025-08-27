namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record HostnameProviders
{
	[JsonPropertyName("request")]
	public HasOrder Request { get; set; } = new();
}
