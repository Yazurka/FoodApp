using System.ComponentModel.Composition;
using System.Threading.Tasks;
using FoodAdmin.Util;

namespace FoodAdmin.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class FoodAdminViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public FoodAdminViewModel(DishViewModel dishViewModel, IngredientViewModel ingredientViewModel, TagViewModel tagViewModel, IViewDisabler viewDisabler)
        {
            ViewDisabler = viewDisabler;
            DishViewModel = dishViewModel;
            IngredientViewModel = ingredientViewModel;
            TagViewModel = tagViewModel;
        }

        public async Task Initialize()
        {
            ViewDisabler.Disable("Laster..." , Task.WhenAll(DishViewModel.Initialize(), IngredientViewModel.Initialize(), TagViewModel.Initialize()));
        }

        public IViewDisabler ViewDisabler { get; }
        
        public DishViewModel DishViewModel { get; } 

        public IngredientViewModel IngredientViewModel { get; } 

        public TagViewModel TagViewModel { get; }
    }
}
