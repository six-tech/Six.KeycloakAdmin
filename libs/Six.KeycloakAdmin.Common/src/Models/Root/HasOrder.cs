namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record HasOrder
{
	[JsonPropertyName("order")]
	public long Order { get; set; }
}
