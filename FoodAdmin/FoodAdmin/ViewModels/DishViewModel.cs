using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FoodAdmin.Models;
using FoodAdmin.REST;

namespace FoodAdmin.ViewModels
{
    public class DishViewModel : ViewModelBase
    {
        private readonly IRestClient m_restClient;
        private List<DishLight> m_dishes; 
        public DishViewModel(IRestClient restClient)
        {
            m_restClient = restClient;
           
            //Dishes = GetData();
            YOLO();
        }

        private async void YOLO()
        {
            await GetData();

        }

        public List<DishLight> Dishes
        {
            get { return m_dishes; }
            set
            {
                m_dishes = value;
                OnPropertyChanged(nameof(Dishes));
            }
        }
        public async Task GetData()
        {
        //    var client = new HttpClient();
        //   var res = await  client.GetAsync("http://localhost:8080/api/Dish");
        //   var res2 = await res.Content.ReadAsStringAsync();
              var res = await m_restClient.Get<List<DishLight>>(0, "Dish");
            Dishes = res;
        }
    }
}
