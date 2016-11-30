using System;
using System.ComponentModel.Composition;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FoodAdmin.Util
{
    [Export(typeof(IRestClient))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class RestClient  : IRestClient
    {
        private readonly HttpClient client;
        private readonly string baseUrl = "http://localhost:8080/api/";
        public RestClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
        }
        public async Task<T> Get<T>(int id, string urlEnd)
        {
            HttpResponseMessage response;
            if (id == 0)
            {
                try
                {
                    response = await client.GetAsync(urlEnd);
                }
                catch (Exception)
                {
                    
                    throw;
                }
                 
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

        public async Task Delete(string urlEnd)
        {
            var response = await client.DeleteAsync(urlEnd);
        }
    }
}
