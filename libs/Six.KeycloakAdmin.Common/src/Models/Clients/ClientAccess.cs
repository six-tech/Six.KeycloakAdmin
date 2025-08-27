namespace Six.KeycloakAdmin.Models.Clients;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ClientAccess
{
	[JsonPropertyName("view")]
	public bool? View { get; set; }
	[JsonPropertyName("configure")]
	public bool? Configure { get; set; }
	[JsonPropertyName("manage")]
	public bool? Manage { get; set; }
}
