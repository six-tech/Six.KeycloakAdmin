using System;

namespace Six.KeyCloak.Core.Models.Organizations;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record OrganizationDomain
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("verified")]
    public bool? Verified { get; set; }
}
