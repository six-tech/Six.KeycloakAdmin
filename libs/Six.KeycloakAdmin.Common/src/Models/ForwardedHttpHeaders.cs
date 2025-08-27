namespace Six.KeyCloak;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record ForwardedHttpHeaders
{
 [JsonPropertyName("forwardedFor")]
	public string ForwardedFor { get; set; } = string.Empty;
 
 [JsonPropertyName("forwardedProto")]
	public string ForwardedProto { get; set; } = string.Empty;
 
 [JsonPropertyName("forwardedHost")]
	public string ForwardedHost { get; set; } = string.Empty;
}
