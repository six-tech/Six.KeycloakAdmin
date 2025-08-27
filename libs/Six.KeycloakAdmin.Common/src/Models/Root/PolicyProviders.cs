namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record PolicyProviders
{
	[JsonPropertyName("role")]
	public HasOrder Role { get; set; } = new ();

	[JsonPropertyName("resource")]
	public HasOrder Resource { get; set; } = new ();

	[JsonPropertyName("scope")]
	public HasOrder Scope { get; set; } = new ();

	[JsonPropertyName("uma")]
	public HasOrder Uma { get; set; } = new ();

	[JsonPropertyName("client")]
	public HasOrder Client { get; set; } = new ();

	[JsonPropertyName("js")]
	public HasOrder Js { get; set; } = new ();

	[JsonPropertyName("time")]
	public HasOrder Time { get; set; } = new ();

	[JsonPropertyName("user")]
	public HasOrder User { get; set; } = new ();

	[JsonPropertyName("aggregate")]
	public HasOrder Aggregate { get; set; } = new ();

	[JsonPropertyName("group")]
	public HasOrder Group { get; set; } = new ();
}
