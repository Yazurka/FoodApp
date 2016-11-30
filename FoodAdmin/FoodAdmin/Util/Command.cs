using System;
using System.Windows.Input;

namespace FoodAdmin.Util
{
    public class Command : ICommand
    {
        private readonly Func<bool> _canExecute;
        private readonly Action<object> _execute;

        public Command(Action<object> execute)
            : this(execute, null)
        { }

        public Command(Action<object> execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}