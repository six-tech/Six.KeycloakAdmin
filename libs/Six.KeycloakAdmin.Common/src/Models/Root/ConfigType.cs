namespace Six.KeycloakAdmin.Models.Root;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ConfigType
{
	Int,
	String
}
