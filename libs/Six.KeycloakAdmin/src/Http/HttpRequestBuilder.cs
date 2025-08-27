using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;

namespace Six.KeycloakAdmin.Http;

/// <summary>
/// HttpClient-based fluent API that mimics Flurl's IFlurlRequest interface
/// </summary>
[ExcludeFromCodeCoverage]
internal sealed class HttpRequestBuilder
{
  readonly HttpClient _httpClient;
  readonly StringBuilder _urlBuilder;
  readonly Dictionary<string, object?> _queryParams = new();
  readonly Dictionary<string, string> _headers = new();
  IKeycloakJsonSerializer? _serializer;

  public HttpRequestBuilder(HttpClient httpClient, string baseUrl)
  {
    _httpClient = httpClient;
    _urlBuilder = new StringBuilder(baseUrl);
  }

  public HttpRequestBuilder AppendPathSegment(string segment)
  {
    if (string.IsNullOrEmpty(segment))
      return this;

    // Ensure proper path separator
    if (_urlBuilder.Length > 0 && !_urlBuilder.ToString().EndsWith("/") && !segment.StartsWith("/"))
      _urlBuilder.Append('/');
    
    if (segment.StartsWith("/") && _urlBuilder.ToString().EndsWith("/"))
      segment = segment[1..];

    _urlBuilder.Append(segment);
    return this;
  }

  public HttpRequestBuilder SetQueryParams(Dictionary<string, object?> queryParams)
  {
    foreach (var kvp in queryParams.Where(x => x.Value is not null))
    {
      _queryParams[kvp.Key] = kvp.Value;
    }
    return this;
  }

  public HttpRequestBuilder WithSettings(Action<ClientHttpSettings> configureSettings)
  {
    // For compatibility - capture serializer settings
    var settings = new ClientHttpSettings();
    configureSettings(settings);
    _serializer = settings.JsonSerializer;
    return this;
  }

  public HttpRequestBuilder WithOAuthBearerToken(string token)
  {
    _headers["Authorization"] = $"Bearer {token}";
    return this;
  }

  string BuildUrl()
  {
    var url = _urlBuilder.ToString();
    
    if (_queryParams.Count == 0)
      return url;

    var queryString = string.Join("&", _queryParams.Select(kvp => 
      $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value?.ToString() ?? string.Empty)}"));
    
    return url.Contains('?') ? $"{url}&{queryString}" : $"{url}?{queryString}";
  }

  HttpRequestMessage CreateRequest(HttpMethod method, HttpContent? content = null)
  {
    var request = new HttpRequestMessage(method, BuildUrl());
    
    if (content is not null)
      request.Content = content;

    foreach (var header in _headers)
    {
      if (header.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase))
        request.Headers.Authorization = AuthenticationHeaderValue.Parse(header.Value);
      else
        request.Headers.Add(header.Key, header.Value);
    }

    return request;
  }

  async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
  {
    var content = await response.Content.ReadAsStringAsync();
    
    if (_serializer is not null)
    {
      return _serializer.Deserialize<T>(content);
    }
    
    // Fallback to System.Text.Json
    var options = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      PropertyNameCaseInsensitive = true
    };
    
    return JsonSerializer.Deserialize<T>(content, options) ?? throw new InvalidOperationException("Failed to deserialize response");
  }

  public async Task<T> GetJsonAsync<T>(CancellationToken cancellationToken = default)
  {
    using var request = CreateRequest(HttpMethod.Get);
    using var response = await _httpClient.SendAsync(request, cancellationToken);
    response.EnsureSuccessStatusCode();
    return await DeserializeResponse<T>(response);
  }

  public async Task<string> GetStringAsync(CancellationToken cancellationToken = default)
  {
    using var request = CreateRequest(HttpMethod.Get);
    using var response = await _httpClient.SendAsync(request, cancellationToken);
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadAsStringAsync();
  }

  public async Task<HttpResponseWrapper> PostJsonAsync<T>(T data, CancellationToken cancellationToken = default)
  {
    var json = _serializer?.Serialize(data) ?? JsonSerializer.Serialize(data, new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });
    
    using var content = new StringContent(json, Encoding.UTF8, "application/json");
    using var request = CreateRequest(HttpMethod.Post, content);
    var response = await _httpClient.SendAsync(request, cancellationToken);
    return new HttpResponseWrapper(response, _serializer);
  }

  public async Task<TResult> PostJsonAsync<T, TResult>(T data, CancellationToken cancellationToken = default)
  {
    using var wrapper = await PostJsonAsync(data, cancellationToken);
    return await wrapper.ReceiveJson<TResult>();
  }

  public async Task<HttpResponseWrapper> PostAsync(HttpContent content, CancellationToken cancellationToken = default)
  {
    using var request = CreateRequest(HttpMethod.Post, content);
    var response = await _httpClient.SendAsync(request, cancellationToken);
    return new HttpResponseWrapper(response, _serializer);
  }

  public async Task<HttpResponseWrapper> PutJsonAsync<T>(T data, CancellationToken cancellationToken = default)
  {
    var json = _serializer?.Serialize(data) ?? JsonSerializer.Serialize(data, new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });
    
    using var content = new StringContent(json, Encoding.UTF8, "application/json");
    using var request = CreateRequest(HttpMethod.Put, content);
    var response = await _httpClient.SendAsync(request, cancellationToken);
    return new HttpResponseWrapper(response, _serializer);
  }

  public async Task<HttpResponseWrapper> PutAsync(HttpContent content, CancellationToken cancellationToken = default)
  {
    using var request = CreateRequest(HttpMethod.Put, content);
    var response = await _httpClient.SendAsync(request, cancellationToken);
    return new HttpResponseWrapper(response, _serializer);
  }

  public async Task<HttpResponseWrapper> DeleteAsync(CancellationToken cancellationToken = default)
  {
    using var request = CreateRequest(HttpMethod.Delete);
    var response = await _httpClient.SendAsync(request, cancellationToken);
    return new HttpResponseWrapper(response, _serializer);
  }

  public async Task<HttpResponseWrapper> SendJsonAsync<T>(HttpMethod method, T data, CancellationToken cancellationToken = default)
  {
    var json = _serializer?.Serialize(data) ?? JsonSerializer.Serialize(data, new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });
    
    using var content = new StringContent(json, Encoding.UTF8, "application/json");
    using var request = CreateRequest(method, content);
    var response = await _httpClient.SendAsync(request, cancellationToken);
    return new HttpResponseWrapper(response, _serializer);
  }

  public async Task<HttpResponseWrapper> PostUrlEncodedAsync(IEnumerable<KeyValuePair<string, string>> data, CancellationToken cancellationToken = default)
  {
    using var content = new FormUrlEncodedContent(data);
    using var request = CreateRequest(HttpMethod.Post, content);
    var response = await _httpClient.SendAsync(request, cancellationToken);
    return new HttpResponseWrapper(response, _serializer);
  }

  public async Task<HttpResponseWrapper> PostUrlEncodedAsync(Dictionary<string, string> data, CancellationToken cancellationToken = default)
  {
    using var content = new FormUrlEncodedContent(data);
    using var request = CreateRequest(HttpMethod.Post, content);
    var response = await _httpClient.SendAsync(request, cancellationToken);
    return new HttpResponseWrapper(response, _serializer);
  }

  public async Task<byte[]> ReceiveBytes()
  {
    using var request = CreateRequest(HttpMethod.Get);
    using var response = await _httpClient.SendAsync(request);
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadAsByteArrayAsync();
  }

  public async Task<T> ReceiveJson<T>()
  {
    using var request = CreateRequest(HttpMethod.Get);
    using var response = await _httpClient.SendAsync(request);
    response.EnsureSuccessStatusCode();
    return await DeserializeResponse<T>(response);
  }

  public async Task<HttpResponseWrapper> PostMultipartAsync(Action<MultipartFormDataContent> buildContent, CancellationToken cancellationToken = default)
  {
    using var content = new MultipartFormDataContent();
    buildContent(content);
    using var request = CreateRequest(HttpMethod.Post, content);
    var response = await _httpClient.SendAsync(request, cancellationToken);
    return new HttpResponseWrapper(response, _serializer);
  }

  public HttpRequestBuilder SetQueryParam(string key, object? value)
  {
    if (value is not null)
      _queryParams[key] = value;
    return this;
  }

  public async Task<HttpResponseWrapper> GetAsync(CancellationToken cancellationToken = default)
  {
    using var request = CreateRequest(HttpMethod.Get);
    var response = await _httpClient.SendAsync(request, cancellationToken);
    return new HttpResponseWrapper(response, _serializer);
  }

  public async Task<HttpResponseWrapper> OptionsAsync(CancellationToken cancellationToken = default)
  {
    using var request = CreateRequest(HttpMethod.Options);
    var response = await _httpClient.SendAsync(request, cancellationToken);
    return new HttpResponseWrapper(response, _serializer);
  }
}

/// <summary>
/// Wrapper for HttpResponseMessage to mimic Flurl's response handling
/// </summary>
internal sealed class HttpResponseWrapper : IDisposable
{
  readonly HttpResponseMessage _response;
  readonly IKeycloakJsonSerializer? _serializer;

  public HttpResponseWrapper(HttpResponseMessage response, IKeycloakJsonSerializer? serializer = null)
  {
    _response = response;
    _serializer = serializer;
  }

  public HttpResponseMessage ResponseMessage => _response;

  public async Task<T> ReceiveJson<T>()
  {
    var content = await _response.Content.ReadAsStringAsync();
    
    if (_serializer is not null)
    {
      return _serializer.Deserialize<T>(content);
    }
    
    var options = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      PropertyNameCaseInsensitive = true
    };
    
    return JsonSerializer.Deserialize<T>(content, options) ?? throw new InvalidOperationException("Failed to deserialize response");
  }

  public async Task<byte[]> ReceiveBytes()
  {
    return await _response.Content.ReadAsByteArrayAsync();
  }

  public async Task<T> GetJsonAsync<T>()
  {
    return await ReceiveJson<T>();
  }

  public void Dispose()
  {
    _response?.Dispose();
  }
}
