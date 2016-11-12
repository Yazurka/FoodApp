using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodAdmin.REST;

namespace FoodAdmin.ViewModels
{
    public class FoodAdminViewModel : ViewModelBase
    {
        private IRestClient m_restClient;
        public FoodAdminViewModel()
        {
            m_restClient = new RestClient();
            DishViewModel = new DishViewModel(m_restClient);
            IngredientViewModel = new IngredientViewModel();
            TagViewModel = new TagViewModel(m_restClient);
        }

        
        public DishViewModel DishViewModel { get; } 

        public IngredientViewModel IngredientViewModel { get; } 

        public TagViewModel TagViewModel { get; }
    }
}
