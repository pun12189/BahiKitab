using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BahiKitab.Command
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly Action<object> _action;

        private bool _canExecute;

        public DelegateCommand(Action<object> action, bool canExecute = true)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute;
        }

        public void Execute(object? parameter)
        {
            _action.Invoke(parameter);
        }
    }
}
