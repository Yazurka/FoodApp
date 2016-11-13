using System.Threading.Tasks;

namespace FoodAdmin.Util
{
    public interface IRestClient
    {
        Task<T> Get<T>(int id, string urlEnd);
        Task<T> Post<T>(object data, string urlEnd);
        Task<T> Put<T>(object data, string urlEnd) where T : class; 
        Task Delete(int id, string urlEnd);
    }
}
