using FoodApp.Facade;
using FoodApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FoodApp.ViewModels
{
    public class DishLightViewModel : ViewModelBase
    {
        private List<DishLight> m_dishLights;

        private readonly FoodFacade m_facade;
        public DishLightViewModel(FoodFacade foodFacade)
        {
            m_facade = foodFacade;
            Initialize();
        }
        public async void Initialize()
        {
            DishLights = await m_facade.GetDishesLight(200,0);
        }

        public List<DishLight> DishLights
        {
            get { return m_dishLights; }
            set { m_dishLights = value; OnPropertyChanged(nameof(DishLights)); }
        }
    }
}
