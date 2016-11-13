using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace FoodAdmin.Util
{
    [Export(typeof(IViewDisabler))]
    public class ViewDisabler : ViewModelBase ,IViewDisabler
    {
        public async void Disable(string message, Task task)
        {
            Message = message;
            OnPropertyChanged(nameof(Message));
            await task;
            Message = null;
            OnPropertyChanged(nameof(Message));
        }

        public string Message { get; private set; }
    }
}