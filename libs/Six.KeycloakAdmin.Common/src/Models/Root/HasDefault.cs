namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record HasDefault
{
	[JsonPropertyName("default")]
	public HasOrder Default { get; set; } = new ();
}
