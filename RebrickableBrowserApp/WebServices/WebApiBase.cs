using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebrickableBrowserApp.WebServices;

public abstract class WebApiBase
{
    // Insert variables below here
    protected static HttpClient _client;
    // Insert static constructor below here
    static WebApiBase()
    {
        _client = new HttpClient();
    }
    // Insert CreateRequestMessage method below here
    private HttpRequestMessage CreateRequestMessage(HttpMethod method, string url, Dictionary<string, string> headers = null)
    {
        var httpRequestMessage = new HttpRequestMessage(method, url);
        if (headers != null && headers.Any())
        {
            foreach (var header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }
        }
        return httpRequestMessage;
    }

    // Insert GetAsync method below here
    protected async Task<string> GetAsync(string url, Dictionary<string, string> headers = null)
    {
        using (var request = CreateRequestMessage(HttpMethod.Get, url, headers))
        using (var response = await _client.SendAsync(request))
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
    }

    // Insert DeleteAsync method below here
    protected async Task<string> DeleteAsync(string url, Dictionary<string, string> headers = null)
    {
        using (var request = CreateRequestMessage(HttpMethod.Delete, url, headers))
        using (var response = await _client.SendAsync(request))
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
    }

    // Insert PostAsync method below here
    protected async Task<string> PostAsync(string url, string payload, Dictionary<string, string> headers = null)
    {
        using (var request = CreateRequestMessage(HttpMethod.Post, url, headers))
        {
            request.Content = new StringContent(payload, Encoding.UTF8, "application/json");
            using (var response = await _client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return null;
            }
        }
    }
    // Insert PutAsync method below here
    protected async Task<string> PutAsync(string url, string payload, Dictionary<string, string> headers = null)
    {
        using (var request = CreateRequestMessage(HttpMethod.Put, url, headers))
        {
            request.Content = new StringContent(payload, Encoding.UTF8, "application/json");
            using (var response = await _client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return null;
            }
        }
    }
}

