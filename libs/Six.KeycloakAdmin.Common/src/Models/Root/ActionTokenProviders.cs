namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ActionTokenProviders
{
	[JsonPropertyName("infinispan")]
	public HasOrder Infinispan { get; set; } = new();
}
