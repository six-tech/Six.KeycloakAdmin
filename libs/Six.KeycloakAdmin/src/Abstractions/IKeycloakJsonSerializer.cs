namespace Six.KeycloakAdmin;

/// <summary>
/// JSON serializer interface
/// </summary>
[PublicAPI]
public interface IKeycloakJsonSerializer
{
  /// <summary>
  /// Serialize an object to JSON string
  /// </summary>
  string Serialize<T>(T obj);
  
  /// <summary>
  /// Deserialize JSON string to object
  /// </summary>
  T Deserialize<T>(string json);
}
