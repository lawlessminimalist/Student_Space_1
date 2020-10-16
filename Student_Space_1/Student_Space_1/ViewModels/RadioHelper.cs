using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Student_Space_1.ViewModels
{
    /*
     * Class that Helps implement Radio Button Code (i.e. viewing, selecting, displaying on labels etc.)
     */
    class RadioHelper : ICommand
    {
        //Code Reference: https://social.msdn.microsoft.com/Forums/vstudio/en-US/5e5a6465-d010-47ef-ada3-8e4b380eb3f2/how-to-get-content-value-of-radiobutton-in-wpf-in-mvvm?forum=wpf

        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public RadioHelper(Action<object> execute)
          : this(execute, null)
        {
        }

        public RadioHelper(Action<object> execute,
                       Predicate<object> canExecute)
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

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
