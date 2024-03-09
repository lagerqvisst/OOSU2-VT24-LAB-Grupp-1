using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLayer.Commands;

namespace WpfLayer.Models
{
    /// <summary>
    /// Denna klass möjliggör för att på ett mer effektivt sätt skapa commands som kan användas i XAML.
    /// Det innebär att vi endast behöver skapa en metod som ska köras när commanden körs och en metod som avgör om commanden kan köras.
    /// Den tillåter overload så vi kan skapa ett command endast med Execute-metoden eller med både Execute- och CanExecute-metoderna.
    /// </summary>
    public class RelayCommand : CommandBase
    {
        private readonly Action _execute = null!;
        private readonly Func<bool> _canExecute = null!;

        public RelayCommand() { }

        public RelayCommand(Action execute) : this(execute, null!) { }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public override void Execute(object parameter) { _execute(); }

        public override bool CanExecute(object parameter) => _canExecute == null || _canExecute();
    }

    public class RelayCommand<T> : RelayCommand
    {
        private readonly Action<T> _execute = null!;
        private readonly Func<T, bool> _canExecute = null!;

        public RelayCommand(Action<T> execute) : this(execute, null!) { }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        public override void Execute(object parameter) { _execute((T)parameter); }
        public override bool CanExecute(object parameter) => _canExecute == null || _canExecute((T)parameter);
    }
}