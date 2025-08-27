namespace Six.KeycloakAdmin.Http;

/// <summary>
/// Extension methods for HttpResponseWrapper tasks to mimic Flurl's response handling
/// </summary>
[ExcludeFromCodeCoverage]
internal static class HttpResponseExtensions
{
  public static async Task<T> ReceiveJson<T>(this Task<HttpResponseWrapper> responseTask)
  {
    using var response = await responseTask;
    return await response.ReceiveJson<T>();
  }

  public static async Task<byte[]> ReceiveBytes(this Task<HttpResponseWrapper> responseTask)
  {
    using var response = await responseTask;
    return await response.ReceiveBytes();
  }
}
