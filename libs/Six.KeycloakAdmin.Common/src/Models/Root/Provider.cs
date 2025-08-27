namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Provider
{
	[JsonPropertyName("groupName")]
	public GroupName GroupName { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
}
