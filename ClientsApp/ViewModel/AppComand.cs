using System;
using System.Windows.Input;

namespace ClientsApp.ViewModel
{
    public sealed class AppComand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action<object?> _action;
        private Func<object?, bool> _func;

        public AppComand(Action<object?> action, Func<object?, bool> func = null) 
        { 
            _action = action;
            _func = func;
        }

        public bool CanExecute(object? parameter)
        { 
            return _func == null || _func.Invoke(parameter); 
        }

        public void Execute(object? parameter)
        { 
            _action.Invoke(parameter);
        }
    }
}
