using Six.KeyCloak.Core.Models.Organizations;
using Six.KeycloakAdmin.Models.IdentityProviders;

namespace Six.KeycloakAdmin.Models.Organizations;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Organization
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("alias")]
	public string? Alias { get; set; }

	[JsonPropertyName("enabled")]
	public bool? Enabled { get; set; }

	[JsonPropertyName("description")]
	public string? Description { get; set; }

	[JsonPropertyName("redirectUrl")]
	public string? RedirectUrl { get; set; }

	[JsonPropertyName("attributes")]
	public IDictionary<string, IEnumerable<string>>? Attributes { get; set; }

	[JsonPropertyName("domains")]
	public IEnumerable<OrganizationDomain>? Domains { get; set; }

	[JsonPropertyName("members")]
	public IEnumerable<Member>? Members { get; set; }

	[JsonPropertyName("identityProviders")]
	public IEnumerable<IdentityProvider>? IdentityProviders { get; set; }
}
