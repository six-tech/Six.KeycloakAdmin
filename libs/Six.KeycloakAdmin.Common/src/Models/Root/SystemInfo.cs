namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record SystemInfo
{
	[JsonPropertyName("version")]
	public string Version { get; set; } = string.Empty;

	[JsonPropertyName("serverTime")]
	public string ServerTime { get; set; } = string.Empty;

	[JsonPropertyName("uptime")]
	public string Uptime { get; set; } = string.Empty;

	[JsonPropertyName("uptimeMillis")]
	public long UptimeMillis { get; set; }

	[JsonPropertyName("javaVersion")]
	public string JavaVersion { get; set; } = string.Empty;

	[JsonPropertyName("javaVendor")]
	public string JavaVendor { get; set; } = string.Empty;

	[JsonPropertyName("javaVm")]
	public string JavaVm { get; set; } = string.Empty;

	[JsonPropertyName("javaVmVersion")]
	public string JavaVmVersion { get; set; } = string.Empty;

	[JsonPropertyName("javaRuntime")]
	public string JavaRuntime { get; set; } = string.Empty;

	[JsonPropertyName("javaHome")]
	public string JavaHome { get; set; } = string.Empty;

	[JsonPropertyName("osName")]
	public string OsName { get; set; } = string.Empty;

	[JsonPropertyName("osArchitecture")]
	public string OsArchitecture { get; set; } = string.Empty;

	[JsonPropertyName("osVersion")]
	public string OsVersion { get; set; } = string.Empty;

	[JsonPropertyName("fileEncoding")]
	public string FileEncoding { get; set; } = string.Empty;

	[JsonPropertyName("userName")]
	public string UserName { get; set; } = string.Empty;

	[JsonPropertyName("userDir")]
	public string UserDir { get; set; } = string.Empty;

	[JsonPropertyName("userTimezone")]
	public string UserTimezone { get; set; } = string.Empty;

	[JsonPropertyName("userLocale")]
	public string UserLocale { get; set; } = string.Empty;
}
