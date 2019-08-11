using System;
using System.Windows.Input;

namespace PolarBearGUI_WPF.Utilities
{
    public class RelayCommand<T> : ICommand
    {

        private readonly Action<T> execute = null;
        private readonly Func<T, bool> canExecute = null;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute ?? (_ => true);
        }

        public bool CanExecute(object parameter) => canExecute((T)parameter);

        public void Execute(object parameter) => execute((T)parameter);
    }

    public class RelayCommand : RelayCommand<object>
    {
        public RelayCommand(Action execute)
            : base(_ => execute()) { }

        public RelayCommand(Action execute, Func<bool> canExecute)
            : base(_ => execute(), _ => canExecute()) { }
    }
}
