 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace WpfLayer.Models
{
    /// <summary>
    /// Denna klass möjliggör för att samtliga viewmodels att ärva från en gemensam klass som implementerar INotifyPropertyChanged
    /// Det innebär att samtliga viewmodels kan använda OnPropertyChanged() för att meddela att en property har ändrats
    /// Varje view model har properties som är bindade till XAML och dessa properties behöver meddela att de har ändrats för att uppdatera gränssnittet
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
