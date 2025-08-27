namespace Six.KeycloakAdmin.Models.RealmsAdmin;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record Attributes
{
	[JsonPropertyName("_browser_headerxXSSProtection")]
	public string BrowserHeaderxXssProtection { get; set; } = string.Empty;
	[JsonPropertyName("_browser_headerxFrameOptions")]
	public string BrowserHeaderxFrameOptions { get; set; } = string.Empty;
	[JsonPropertyName("_browser_headerstrictTransportSecurity")]
	public string BrowserHeaderstrictTransportSecurity { get; set; } = string.Empty;
	[JsonPropertyName("permanentLockout")]
	public string PermanentLockout { get; set; } = string.Empty;
	[JsonPropertyName("quickLoginCheckMilliSeconds")]
	public string QuickLoginCheckMilliSeconds { get; set; } = string.Empty;
	[JsonPropertyName("_browser_headerxRobotsTag")]
	public string BrowserHeaderxRobotsTag { get; set; } = string.Empty;
	[JsonPropertyName("maxFailureWaitSeconds")]
	public string MaxFailureWaitSeconds { get; set; } = string.Empty;
	[JsonPropertyName("minimumQuickLoginWaitSeconds")]
	public string MinimumQuickLoginWaitSeconds { get; set; } = string.Empty;
	[JsonPropertyName("failureFactor")]
	public string FailureFactor { get; set; } = string.Empty;
	[JsonPropertyName("actionTokenGeneratedByUserLifespan")]
	public string ActionTokenGeneratedByUserLifespan { get; set; } = string.Empty;
	[JsonPropertyName("maxDeltaTimeSeconds")]
	public string MaxDeltaTimeSeconds { get; set; } = string.Empty;
	[JsonPropertyName("_browser_headerxContentTypeOptions")]
	public string BrowserHeaderxContentTypeOptions { get; set; } = string.Empty;
	[JsonPropertyName("offlineSessionMaxLifespan")]
	public string OfflineSessionMaxLifespan { get; set; } = string.Empty;
	[JsonPropertyName("actionTokenGeneratedByAdminLifespan")]
	public string ActionTokenGeneratedByAdminLifespan { get; set; } = string.Empty;
	[JsonPropertyName("_browser_headercontentSecurityPolicyReportOnly")]
	public string BrowserHeadercontentSecurityPolicyReportOnly { get; set; } = string.Empty;
	[JsonPropertyName("bruteForceProtected")]
	public string BruteForceProtected { get; set; } = string.Empty;
	[JsonPropertyName("_browser_headercontentSecurityPolicy")]
	public string BrowserHeadercontentSecurityPolicy { get; set; } = string.Empty;
	[JsonPropertyName("waitIncrementSeconds")]
	public string WaitIncrementSeconds { get; set; } = string.Empty;
	[JsonPropertyName("offlineSessionMaxLifespanEnabled")]
	public string OfflineSessionMaxLifespanEnabled { get; set; } = string.Empty;
}
