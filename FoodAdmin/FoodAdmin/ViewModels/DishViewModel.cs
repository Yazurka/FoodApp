using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using FoodAdmin.Facade;
using FoodAdmin.Models;
using FoodAdmin.Util;

namespace FoodAdmin.ViewModels
{
    [Export]
    public class DishViewModel : ViewModelBase
    {
        private readonly FoodFacade m_foodFacade;
        private DishLight m_selectedDish;
        private readonly IViewDisabler m_viewDisabler;
        private ObservableCollection<Step> m_steps;
        [ImportingConstructor]
        public DishViewModel(FoodFacade foodFacade, IViewDisabler viewDisabler, IngredientViewModel ingredientViewModel)
        {
            m_foodFacade = foodFacade;
            m_viewDisabler = viewDisabler;
            IngredientViewModel = ingredientViewModel;
        }
        public IngredientViewModel IngredientViewModel { get; }
        public DelegateCommand CreateNewDishCommand => new DelegateCommand(CreateNewDish);
        public DelegateCommand NewStepCommand => new DelegateCommand(CreateNewStep);

       

        public DelegateCommand CancelCommad => new DelegateCommand(Cancel);
        public DelegateCommand SaveCommand => new DelegateCommand(SaveDish);
        public ObservableCollection<DishLight> Dishes { get; set; }

        public DishLight SelectedDish
        {
            get { return m_selectedDish; }
            set
            {
                m_selectedDish = value;
                SelectionChanged();
            }
        }

       

        public Dish TheDish { get; set; }

        public async Task Initialize()
        {
            var dishes = await m_foodFacade.GetAllDishes(10000,0);
            dishes.Sort((light, dishLight) => light.Name.CompareTo(dishLight.Name));
            Dishes = new ObservableCollection<DishLight>(dishes);
           
            OnPropertyChanged(nameof(Dishes));
        }
        private void CreateNewStep()
        {
            TheDish.Steps.Add(new Step());  
        }

        private async void SelectionChanged()
        {
            if (SelectedDish == null)
            {
                OnPropertyChanged(string.Empty);
                return;
            }
            TheDish = await m_foodFacade.GetDish(SelectedDish.Id);
            OnPropertyChanged(nameof(TheDish));
        }

        private void Cancel()
        {
            TheDish = null;
            SelectedDish = null;
            OnPropertyChanged(nameof(TheDish));
        }

        private void CreateNewDish()
        {
            TheDish = new Dish {Tags = new List<Tag>(), Ingredients = new List<DishIngredientResult>()};
            OnPropertyChanged(nameof(TheDish));
        }

        private async void SaveDish()
        {
            await m_foodFacade.SaveDish(TheDish);
            Cancel();
        }
    }
}
