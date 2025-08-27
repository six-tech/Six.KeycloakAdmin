using System.Text;

namespace Six.KeycloakAdmin.Http;

/// <summary>
/// Extension methods for MultipartFormDataContent to mimic Flurl's multipart handling
/// </summary>
[ExcludeFromCodeCoverage]
internal static class MultipartExtensions
{
  public static MultipartFormDataContent AddFile(this MultipartFormDataContent content, string fileName, string? filePath)
  {
    if (string.IsNullOrEmpty(filePath))
      return content;

    var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
    content.Add(fileContent, "file", fileName);
    return content;
  }

  public static MultipartFormDataContent AddString(this MultipartFormDataContent content, string name, string? value)
  {
    if (string.IsNullOrEmpty(value))
      return content;
      
    var stringContent = new StringContent(value, Encoding.UTF8);
    content.Add(stringContent, name);
    return content;
  }
}
