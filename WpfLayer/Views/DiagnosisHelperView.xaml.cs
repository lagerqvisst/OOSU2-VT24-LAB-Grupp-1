using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfLayer.ViewModels;

namespace WpfLayer.Views
{
    /// <summary>
    /// Interaction logic for DiagnosisHelperView.xaml
    /// </summary>
    public partial class DiagnosisHelperView : Window
    {
        DhViewModel dhViewModel;
        public DiagnosisHelperView()
        {
            dhViewModel = new DhViewModel();
            DataContext = dhViewModel;
            InitializeComponent();

            this.Title = "Diagnosis Helper";
        }
    }
}
