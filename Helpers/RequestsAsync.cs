using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Library.Helpers
{
    public class RequestsAsync
    {
        private static HttpClient _httpClient = new();

        public static async Task<(T Response, HttpStatusCode StatusCode)> PostAsync<T>(string url, object userdata, string auth, Dictionary<string, string> headers = null, bool shouldLogRequestData = true)
        {
            var request = CreateRequest(HttpMethod.Post, url, auth, headers);
            var payload = JsonConvert.SerializeObject(userdata, Formatting.Indented);
            if (shouldLogRequestData)
            {
                Logger.WriteLine($"Sending Request: {payload}");
            }
            request.Content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(request);
            var stringContent = await response.Content.ReadAsStringAsync();
            Logger.WriteLine($"HTTP POST: Respnse for url {url}:\r\n{stringContent}");
            try
            {
                var deserializeObject = JsonConvert.DeserializeObject<T>(stringContent);
                return (deserializeObject, response.StatusCode);
            }
            catch (Exception)
            {
                Logger.WriteLine($"HTTP POST: Unable to deserialize response. String Content:{stringContent}");
                return (default, response.StatusCode);
            }
        }

        public static async Task<(T Response, HttpStatusCode StatusCode)> GetAsync<T>(string url, string auth, Dictionary<string, string> headers = null, bool shouldLogRequestData = true)
        {
            var request = CreateRequest(HttpMethod.Get, url, auth, headers);

            var response = await _httpClient.SendAsync(request);

            var stringContent = await response.Content.ReadAsStringAsync();
            Logger.WriteLine($"HTTP GET: Response for url {url}:\r\n{stringContent}");

            try
            {
                var deserializeObject = JsonConvert.DeserializeObject<T>(stringContent);
                return (deserializeObject, response.StatusCode);
            }
            catch (Exception)
            {
                Logger.WriteLine($"HTTP GET: Unable to deserialize response. String Content:{stringContent}");
                return (default, response.StatusCode);
            }
        }


        private static HttpRequestMessage CreateRequest(HttpMethod httpMethod, string url, string auth, Dictionary<string, string> headers)
        {
            var request = new HttpRequestMessage(httpMethod, url);

            if (!string.IsNullOrEmpty(auth))
            {
                request.Headers.Add("Authorization", auth);
            }
            if (headers == null)
            {
                return request;
            }
            foreach (var (headername, headervalue) in headers)
            {
                request.Headers.Add(headername, headervalue);
            }

            return request;
        }

    }
}
