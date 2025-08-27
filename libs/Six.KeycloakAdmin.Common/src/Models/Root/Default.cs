namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Default
{
	[JsonPropertyName("order")]
	public long Order { get; set; }

	[JsonPropertyName("operationalInfo")]
	public OperationalInfo OperationalInfo { get; set; } = new ();
}
