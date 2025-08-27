namespace Six.KeycloakAdmin.Models.RealmsAdmin;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record BrowserSecurityHeaders
{
	[JsonPropertyName("contentSecurityPolicyReportOnly")]
	public string ContentSecurityPolicyReportOnly { get; set; } = string.Empty;
	[JsonPropertyName("xContentTypeOptions")]
	public string XContentTypeOptions { get; set; } = string.Empty;
	[JsonPropertyName("xRobotsTag")]
	public string XRobotsTag { get; set; } = string.Empty;
	[JsonPropertyName("xFrameOptions")]
	public string XFrameOptions { get; set; } = string.Empty;
	[JsonPropertyName("xXSSProtection")]
	public string XXssProtection { get; set; } = string.Empty;
	[JsonPropertyName("contentSecurityPolicy")]
	public string ContentSecurityPolicy { get; set; } = string.Empty;
	[JsonPropertyName("strictTransportSecurity")]
	public string StrictTransportSecurity { get; set; } = string.Empty;
}
