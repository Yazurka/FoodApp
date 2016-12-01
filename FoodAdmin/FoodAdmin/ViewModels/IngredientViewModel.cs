using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
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
        private readonly IViewDisabler m_viewDisabler;
        private readonly PopupDialog m_popupDialog;

        [ImportingConstructor]
        public IngredientViewModel(FoodFacade foodFacade, IViewDisabler viewDisabler, PopupDialog popupDialog)
        {
            m_foodFacade = foodFacade;
            m_viewDisabler = viewDisabler;
            m_popupDialog = popupDialog;
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
                var numberOfEqualIngredients = Ingredients.Select(x => x).Where(t => t.Name.ToUpper().Equals(IngredientName.ToUpper())).ToArray().Count();
                if (numberOfEqualIngredients > 0)
                {
                    await m_popupDialog.Dialog.ShowMessageAsync(this, $"Kan ikke legge til {IngredientName}", $"{IngredientName} kan ikke legges til fordi det eksisterer allerede en ingrediens med samme navn");
                    return;
                }

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
               
                var status = await m_foodFacade.DeleteIngredient(SelectedIngredient);
                if (status == 500)
                {
                    await m_popupDialog.Dialog.ShowMessageAsync(this, $"Kan ikke slette {SelectedIngredient.Name}",$"{SelectedIngredient.Name} kan ikke slettes fordi den blir brukt i en eller flere av rettene. Slett retten(e) eller slett ingrediensen ''{SelectedIngredient.Name}'' fra retten(e) ");
                    return;
                }
                m_viewDisabler.Disable("Laster...", RefreshIngredient());
            }
        }

        private async void SaveEditedIngredient()
        {
            if (SelectedIngredient != null)
            {
                var numberOfEqualIngredients = IngredientCopy.Select(x => x).Where(t => t.Name.ToUpper().Equals(SelectedIngredient.Name.ToUpper())).ToArray().Count();
                if (numberOfEqualIngredients > 0)
                {
                    await m_popupDialog.Dialog.ShowMessageAsync(this, "Kan ikke endre navn på ingrediens", $"Det eksisterer allerede en ingrediens som heter {SelectedIngredient.Name}, velg et annet navn eller bruk den du allerede har");
                    m_viewDisabler.Disable("Laster...", RefreshIngredient());
                    return;
                }

                await m_foodFacade.UpdateIngredient(SelectedIngredient);
                m_viewDisabler.Disable("Laster...", RefreshIngredient());
            }
        }

        private List<Ingredient> IngredientCopy { get; set; } 

        private async Task RefreshIngredient()
        {
            IngredientCopy = new List<Ingredient>();
            var ingredients = await m_foodFacade.GetAllIngredients();
            foreach (var ingredient in ingredients)
            {
                IngredientCopy.Add(new Ingredient {Id = ingredient.Id, Name = ingredient.Name, Description = ingredient.Description});
            }
            ingredients.Sort((Ingredient, Ingredient1) => Ingredient.Name.CompareTo(Ingredient1.Name));
            Ingredients = new ObservableCollection<Ingredient>(ingredients);
            OnPropertyChanged(nameof(ingredients));
        }
    }
}
