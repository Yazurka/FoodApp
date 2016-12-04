using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace FoodApp.Util
{
    public class RestClient : IRestClient
    {

        private readonly HttpClient client;
        private readonly string baseUrl = "http://localhost:8080/api/";

        public RestClient()
        {
            client = new HttpClient();
           
            client.BaseAddress = new Uri(baseUrl);
        }

        public async Task<T> Get<T>(string urlEnd)
        {
            HttpResponseMessage response = await client.GetAsync(urlEnd);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);
            return result;
        }
    }
}
