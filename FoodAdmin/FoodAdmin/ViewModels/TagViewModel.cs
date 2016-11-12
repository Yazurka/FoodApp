using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FoodAdmin.Models;
using FoodAdmin.REST;

namespace FoodAdmin.ViewModels
{
    public class TagViewModel : ViewModelBase
    {
        private string m_tagName;
        private ICommand m_saveTagCommand;
        private readonly IRestClient m_restClient;
        public TagViewModel(IRestClient restClient)
        {
            m_restClient = restClient;
            Tags = new ObservableCollection<Tag>();
            YOLO();
        }

        private async void YOLO()
        {
            await GetData();
        }

        private async Task GetData()
        {
            var tags =await m_restClient.Get<List<Tag>>(0, "tag");
            tags.Sort((tag, tag1) => tag.Name.CompareTo(tag1.Name));
            foreach (var tag in tags)
            {
                Tags.Add(tag);
            }
        }

        private async void SaveTagExecute()
        {
            var newtag = await m_restClient.Post<Tag>(new Tag() { Name = TagName }, "tag");
            Tags.Add(newtag);
        }


        private async void SaveEditedTag()
        {
            //PUt
            await m_restClient.Put<Tag>(SelectedTag, "tag");

            Tags.Clear();
            SelectedTag = null;
            YOLO();
            
        }

        public ObservableCollection<Tag> Tags { get; } 

        public ICommand SaveTagCommand => new DelegateCommand(SaveTagExecute);
        public ICommand SaveEditedTagCommand => new DelegateCommand(SaveEditedTag);

        public string TagName
        {
            get { return m_tagName; }
            set
            {
                m_tagName = value;
                OnPropertyChanged(nameof(TagName));
            }
        }

        public Tag SelectedTag { get; set; }
    }
}
