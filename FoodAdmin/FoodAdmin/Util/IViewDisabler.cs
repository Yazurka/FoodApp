using System.Threading.Tasks;

namespace FoodAdmin.Util
{
    public interface IViewDisabler
    {
        void Disable(string message, Task task);

        string Message { get; }
    }
}