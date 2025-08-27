namespace Six.KeycloakAdmin.Models.Clients;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Permission : Resource
{
	[JsonPropertyName("claims")]
	public IDictionary<string, object> Claims { get; set; } = new Dictionary<string, object>();
}
