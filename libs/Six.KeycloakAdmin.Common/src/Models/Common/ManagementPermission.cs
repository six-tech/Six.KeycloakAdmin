namespace Six.KeycloakAdmin.Models.Common;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ManagementPermission
{
	[JsonPropertyName("enabled")]
	public bool? Enabled { get; set; }
}
