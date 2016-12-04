using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Util
{
    public interface IRestClient
    {
        Task<T> Get<T>(string urlEnd);
    }
}
