using System.Text.Json;

namespace Six.KeycloakAdmin.Http;

/// <summary>
/// Default JSON serializer implementation using System.Text.Json
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public sealed class DefaultJsonKeycloakJsonSerializer : IKeycloakJsonSerializer
{
  readonly JsonSerializerOptions _options;

  public DefaultJsonKeycloakJsonSerializer(JsonSerializerOptions options)
  {
    _options = options;
  }

  public string Serialize<T>(T obj) => JsonSerializer.Serialize(obj, _options);

  public T Deserialize<T>(string json) =>
    JsonSerializer.Deserialize<T>(json, _options) ?? throw new InvalidOperationException("Failed to deserialize JSON");
}