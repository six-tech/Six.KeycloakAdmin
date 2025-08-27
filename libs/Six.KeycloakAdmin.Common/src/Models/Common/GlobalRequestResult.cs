namespace Six.KeycloakAdmin.Models.Common;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record GlobalRequestResult
{
	[JsonPropertyName("failedRequests")]
	public IEnumerable<string> FailedRequests { get; set; } = [];
	[JsonPropertyName("successRequests")]
	public IEnumerable<string> SuccessRequests { get; set; } = [];
}
