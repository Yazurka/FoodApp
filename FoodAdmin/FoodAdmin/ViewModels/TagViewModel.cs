using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows.Input;
using FoodAdmin.Facade;
using FoodAdmin.Models;
using FoodAdmin.Util;

namespace FoodAdmin.ViewModels
{
    [Export]
    public class TagViewModel : ViewModelBase
    {
        private readonly FoodFacade m_foodFacade;

        [ImportingConstructor]
        public TagViewModel(FoodFacade foodFacade)
        {
            m_foodFacade = foodFacade;
            Tags = new ObservableCollection<Tag>();
        }

        public ObservableCollection<Tag> Tags { get; private set; }
        public ICommand CreateNewTagCommand => new DelegateCommand(CreateNewTag);
        public ICommand SaveEditedTagCommand => new DelegateCommand(SaveEditedTag);
        public ICommand DeleteTagCommand => new DelegateCommand(DeleteTag);

        public string TagName { get; set; }

        public Tag SelectedTag { get; set; }

        public Task Initialize()
        {
            return RefreshTag();
        }

        private async void CreateNewTag()
        {
            if (TagName != null)
            {
                Tags.Add( await m_foodFacade.AddTag(new Tag() {Name = TagName}));
                TagName = "";
                OnPropertyChanged(nameof(TagName));
                await RefreshTag();
            }
        }

        private async void DeleteTag()
        {
            if (SelectedTag != null)
            {
                await m_foodFacade.DeleteTag(SelectedTag);
                await RefreshTag();
            }
        }

        private async void SaveEditedTag()
        {
            if (SelectedTag != null)
            {
                await m_foodFacade.UpdateTag(SelectedTag);
                await RefreshTag();
            }
        }

            private async Task RefreshTag()
            {
                var tags = await m_foodFacade.GetAllTags();
                tags.Sort((tag, tag1) => tag.Name.CompareTo(tag1.Name));
                Tags = new ObservableCollection<Tag>(tags);
                OnPropertyChanged(nameof(Tags));
            }
    }
}
