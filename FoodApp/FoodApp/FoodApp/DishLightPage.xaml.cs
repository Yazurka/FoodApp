using FoodApp.Facade;
using FoodApp.Util;
using FoodApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FoodApp
{
    public partial class DishLightPage : ContentPage
    {
        public DishLightPage()
        {
            InitializeComponent();
            BindingContext = new DishLightViewModel(new FoodFacade(new RestClient()));
        }
    }
}
