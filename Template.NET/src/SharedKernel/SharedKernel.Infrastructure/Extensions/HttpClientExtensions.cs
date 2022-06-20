using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SharedKernel.Infrastructure.Extensions;

/// <summary>
/// Методы расширения для <see cref="HttpClient"/>
/// </summary>
public static class HttpClientExtensions
{
    /// <summary>
    /// Метод DELETE
    /// </summary>
    /// <param name="httpClient"><see cref="HttpClient"/></param>
    /// <param name="requestUri">Адрес запроса</param>
    /// <param name="data">Тело запроса</param>
    /// <typeparam name="T">Тип тела запроса</typeparam>
    /// <returns><see cref="HttpResponseMessage"/></returns>
    public static Task<HttpResponseMessage> DeleteAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T data)
        => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri) { Content = Serialize(data) });

    /// <summary>
    /// Метод DELETE
    /// </summary>
    /// <param name="httpClient"><see cref="HttpClient"/></param>
    /// <param name="requestUri">Адрес запроса</param>
    /// <param name="data">Тело запроса</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <typeparam name="T">Тип тела запроса</typeparam>
    /// <returns><see cref="HttpResponseMessage"/></returns>
    public static Task<HttpResponseMessage> DeleteAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T data, CancellationToken cancellationToken)
        => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri) { Content = Serialize(data) }, cancellationToken);

    /// <summary>
    /// Метод DELETE
    /// </summary>
    /// <param name="httpClient"><see cref="HttpClient"/></param>
    /// <param name="requestUri">Адрес запроса</param>
    /// <param name="data">Тело запроса</param>
    /// <typeparam name="T">Тип тела запроса</typeparam>
    /// <returns><see cref="HttpResponseMessage"/></returns>
    public static Task<HttpResponseMessage> DeleteAsJsonAsync<T>(this HttpClient httpClient, Uri requestUri, T data)
        => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri) { Content = Serialize(data) });

    /// <summary>
    /// Метод DELETE
    /// </summary>
    /// <param name="httpClient"><see cref="HttpClient"/></param>
    /// <param name="requestUri">Адрес запроса</param>
    /// <param name="data">Тело запроса</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <typeparam name="T">Тип тела запроса</typeparam>
    /// <returns><see cref="HttpResponseMessage"/></returns>
    public static Task<HttpResponseMessage> DeleteAsJsonAsync<T>(this HttpClient httpClient, Uri requestUri, T data, CancellationToken cancellationToken)
        => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri) { Content = Serialize(data) }, cancellationToken);

    private static HttpContent Serialize(object? data) => new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
}