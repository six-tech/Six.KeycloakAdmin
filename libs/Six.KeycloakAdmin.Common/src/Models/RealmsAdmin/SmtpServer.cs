namespace Six.KeycloakAdmin.Models.RealmsAdmin;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record SmtpServer
{
	[JsonPropertyName("host")]
	public string Host { get; set; } = string.Empty;
	[JsonPropertyName("port")]
	public string Port { get; set; } = string.Empty;
	[JsonPropertyName("ssl")]
	public string Ssl { get; set; } = string.Empty;
	[JsonPropertyName("starttls")]
	public string StartTls { get; set; } = string.Empty;
	[JsonPropertyName("user")]
	public string User { get; set; } = string.Empty;
	[JsonPropertyName("password")]
	public string Password { get; set; } = string.Empty;
	[JsonPropertyName("auth")]
	public string Auth { get; set; } = string.Empty;
	[JsonPropertyName("from")]
	public string From { get; set; } = string.Empty;
	[JsonPropertyName("fromDisplayName")]
	public string FromDisplayName { get; set; } = string.Empty;
	[JsonPropertyName("replyTo")]
	public string ReplyTo { get; set; } = string.Empty;
	[JsonPropertyName("replyToDisplayName")]
	public string ReplyToDisplayName { get; set; } = string.Empty;
	[JsonPropertyName("envelopeFrom")]
	public string EnvelopeFrom { get; set; } = string.Empty;
}
