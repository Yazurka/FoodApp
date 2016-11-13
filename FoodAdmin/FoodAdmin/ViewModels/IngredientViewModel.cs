using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using FoodAdmin.Facade;
using FoodAdmin.Models;
using FoodAdmin.Util;

namespace FoodAdmin.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class IngredientViewModel : ViewModelBase
    {
        private readonly FoodFacade m_foodFacade;

        [ImportingConstructor]
        public IngredientViewModel(FoodFacade foodFacade)
        {
            m_foodFacade = foodFacade;
        }

        public ObservableCollection<Ingredient> Ingredients { get; private set; }
        public DelegateCommand DeleteIngredientCommand => new DelegateCommand(DeleteIngredient);
        public DelegateCommand CreateNewIngredientCommand => new DelegateCommand(CreateNewIngredient);
        public DelegateCommand SaveEditedIngredientCommand => new DelegateCommand(SaveEditedIngredient);

        public  Task Initialize()
        {
            return RefreshIngredient();
        }

        public string IngredientName { get; set; }
        public string IngredientDescription { get; set; }


        public Ingredient SelectedIngredient { get; set; }

        private async void CreateNewIngredient()
        {
            if (IngredientName != null)
            {
                Ingredients.Add(await m_foodFacade.AddIngredient(new Ingredient { Name = IngredientName, Description = IngredientDescription }));
                IngredientName = "";
                IngredientDescription = "";
                OnPropertyChanged(string.Empty);
                await RefreshIngredient();
            }
        }

        private async void DeleteIngredient()
        {
            if (SelectedIngredient != null)
            {
                await m_foodFacade.DeleteIngredient(SelectedIngredient);
                await RefreshIngredient();
            }
        }

        private async void SaveEditedIngredient()
        {
            if (SelectedIngredient != null)
            {
                await m_foodFacade.UpdateIngredient(SelectedIngredient);
                await RefreshIngredient();
            }
        }


        private async Task RefreshIngredient()
        {
            var ingredients = await m_foodFacade.GetAllIngredients();
            ingredients.Sort((Ingredient, Ingredient1) => Ingredient.Name.CompareTo(Ingredient1.Name));
            Ingredients = new ObservableCollection<Ingredient>(ingredients);
            OnPropertyChanged(nameof(ingredients));
        }
    }
}
