using System;
using System.ComponentModel.Composition;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FoodAdmin.Util
{
    [Export(typeof(IRestClient))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class RestClient : IRestClient
    {
        private readonly HttpClient client;
        private readonly string baseUrl = "http://localhost:8080/api/";
        public RestClient()
        {
            client = new HttpClient();
            AuthorizeHttpClient(client);
            client.BaseAddress = new Uri(baseUrl);
        }

        private static void AuthorizeHttpClient(HttpClient  httpClient)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJBbGwiOiJHb29kIiwiSW4iOiJUaGUiLCJGdWNraW5nIjoiSG9vZCJ9");
        }
        public async Task<T> Get<T>(int id, string urlEnd)
        {
            HttpResponseMessage response;
            if (id == 0)
            {
                response = await client.GetAsync(urlEnd);
            }
            else
            {
                response = await client.GetAsync(urlEnd+id);
            }
            
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);
            return result;
        }

        public async Task<T> Post<T>(object data, string urlEnd)
        {

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(urlEnd, content);
            var readedContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(readedContent);
        }

        public async Task<T> Put<T>(object data, string urlEnd) where T : class
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(urlEnd, content);
                var readedContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(readedContent);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> Delete(string urlEnd)
        {
            var response = await client.DeleteAsync(urlEnd);
            var httpStatusCode = ((int) response.StatusCode);
            return httpStatusCode;
        }
    }
}
