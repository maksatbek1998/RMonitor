using System;
using System.Windows.Input;

namespace Monitor.ViewModel.BaseViews
{
    class CommandView : ICommand
    {
        private Action<object> _action;

        public CommandView(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                _action(parameter);
            }
            else
            {
                _action("-1");
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
