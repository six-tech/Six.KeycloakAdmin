namespace Six.KeycloakAdmin.Models.AttackDetection;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record UserNameStatus
{
	[JsonPropertyName("numFailures")]
	public int? NumFailures { get; set; }
 
	[JsonPropertyName("disabled")]
	public bool? Disabled { get; set; }
 
	[JsonPropertyName("lastIPFailure")]
	public string LastIpFailure { get; set; } = string.Empty;
 
	[JsonPropertyName("lastFailure")]
	public int? LastFailure { get; set; }
}
