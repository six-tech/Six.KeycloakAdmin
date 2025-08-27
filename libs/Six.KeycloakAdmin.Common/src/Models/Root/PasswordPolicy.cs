namespace Six.KeycloakAdmin.Models.Root;

[PublicAPI]
[ExcludeFromCodeCoverage]
public record PasswordPolicy
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	[JsonPropertyName("displayName")]
	public string DisplayName { get; set; } = string.Empty;

	[JsonPropertyName("configType")]
	public ConfigType? ConfigType { get; set; }

	[JsonPropertyName("defaultValue")]
	public string DefaultValue { get; set; } = string.Empty;

	[JsonPropertyName("multipleSupported")]
	public bool? MultipleSupported { get; set; }
}
