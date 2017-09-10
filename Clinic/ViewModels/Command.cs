using System;
using System.Windows.Input;

namespace Clinic.ViewModels.Base
{
    public class Command : ICommand
    {
        private Predicate<object> _canExecute;
        private Action<object> _execute;

        public Command(Action<object> execute)
            : this(execute, DefaultCanExecute)
        {
        }

        public Command(Action execute)
            : this(execute, DefaultCanExecute)
        {
        }

        public Command(Action execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            if (canExecute == null)
                throw new ArgumentNullException("canExecute");

            _execute = obj => execute.Invoke();
            _canExecute = canExecute;
        }

        public Command(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            if (canExecute == null)
                throw new ArgumentNullException("canExecute");

            _execute = execute;
            _canExecute = canExecute;
        }


        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                CanExecuteChangedInternal += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                CanExecuteChangedInternal -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return (_canExecute != null) && _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }

        public static ICommand New(Action execute)
        {
            return new Command(execute);
        }

        public static ICommand New(Action<object> execute)
        {
            return new Command(execute);
        }

        private event EventHandler CanExecuteChangedInternal;

        public void OnCanExecuteChanged()
        {
            var handler = CanExecuteChangedInternal;
            //DispatcherHelper.BeginInvokeOnUIThread(() => handler.Invoke(this, EventArgs.Empty));
            handler?.Invoke(this, EventArgs.Empty);
        }

        public void Destroy()
        {
            _canExecute = _ => false;
            _execute = _ => { };
        }

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }
    }
}