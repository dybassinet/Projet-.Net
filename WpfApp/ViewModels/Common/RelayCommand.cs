using System;
using System.Windows.Input;

namespace WpfApp.ViewModels.Common
{
    public class RelayCommand : ICommand
    {
        #region Variables

        private readonly Action execute;
        private readonly Func<bool> canExecute;

        #endregion

        #region Constructeurs

        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion

        #region Handler / Execution

        public void Execute(object parameter)
        {
            this.execute();
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null ? true : this.canExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this.canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (this.canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        #endregion
    }
}
