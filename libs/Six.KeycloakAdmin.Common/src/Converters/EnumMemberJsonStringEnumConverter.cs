using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Six.KeyCloak.Common.Converters;

/// <summary>
/// Provides an AOT-compatible extension for <see cref="JsonStringEnumConverter"/> that adds support for <see cref="EnumMemberAttribute"/>.
/// This converter also handles unknown enum values gracefully by returning the default value.
/// </summary>
/// <typeparam name="TEnum">The type of the <see cref="TEnum"/>.</typeparam>
[PublicAPI]
[ExcludeFromCodeCoverage]
public sealed class EnumMemberJsonStringEnumConverter<
  [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] TEnum> : JsonConverter<TEnum>
  where TEnum : struct, Enum
{
  readonly Dictionary<string, TEnum> _stringToEnum;
  readonly Dictionary<TEnum, string> _enumToString;

  public EnumMemberJsonStringEnumConverter()
  {
    var type = typeof(TEnum);
    _stringToEnum = new Dictionary<string, TEnum>(StringComparer.OrdinalIgnoreCase);
    _enumToString = new Dictionary<TEnum, string>();

    foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static))
    {
      var enumValue = (TEnum)field.GetValue(null)!;
      var enumMemberAttribute = field.GetCustomAttribute<EnumMemberAttribute>();
      var stringValue = enumMemberAttribute?.Value ?? field.Name.ToLowerInvariant();
      
      _stringToEnum[stringValue] = enumValue;
      _enumToString[enumValue] = stringValue;
    }
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="reader"></param>
  /// <param name="typeToConvert"></param>
  /// <param name="options"></param>
  /// <returns></returns>
  /// <exception cref="JsonException"></exception>
  public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType != JsonTokenType.String)
    {
      throw new JsonException($"Expected string value for enum {typeof(TEnum).Name}");
    }

    var stringValue = reader.GetString();
    if (stringValue != null && _stringToEnum.TryGetValue(stringValue, out var enumValue))
    {
      return enumValue;
    }

    // For unknown values, return the default enum value (usually the first one)
    // This allows forward compatibility with newer Keycloak versions that may have additional locales
    return default(TEnum);
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="writer"></param>
  /// <param name="value"></param>
  /// <param name="options"></param>
  public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
  {
    if (_enumToString.TryGetValue(value, out var stringValue))
    {
      writer.WriteStringValue(stringValue);
    }
    else
    {
      writer.WriteStringValue(value.ToString().ToLowerInvariant());
    }
  }
}