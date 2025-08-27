namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record EmailTemplateClass
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

 [JsonPropertyName("providers")] public AccountProviders Providers { get; set; } = new();
}
