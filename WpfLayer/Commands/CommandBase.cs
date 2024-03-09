using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfLayer.Commands
{
    /// <summary>
    /// Denna klass är en abstrakt klass som implementerar ICommand interfacet och används för att möjliggöra RelayCommand-klassen.
    /// Som vi skriver i sammanfattningen för relaycommand-klassen så behöver vi i viewmodel endast skapa en metod som ska köras när commanden körs och en metod som avgör om commanden kan köras.
    /// </summary>
    public abstract class CommandBase : ICommand
    {

        public abstract bool CanExecute(object parameter);


        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }


    }
}
