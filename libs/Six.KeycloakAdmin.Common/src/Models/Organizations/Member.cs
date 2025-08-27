using Six.KeycloakAdmin.Models.Users;

namespace Six.KeycloakAdmin.Models.Organizations;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Member : User
{
    [JsonPropertyName("membershipType")]
    public MembershipType? MembershipType { get; set; }
}
