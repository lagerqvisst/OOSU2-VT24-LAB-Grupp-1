using EntityLayer;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EntityLayer;
using System.Collections.ObjectModel;
using WPF.Windows;
using WPF.ViewModels;


namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Doctor doctor;
        DoctorViewModel doctorViewModel { get; set; }

        public MainWindow(Doctor doctor)
        {
            this.doctor = doctor;
            doctorViewModel = new DoctorViewModel(doctor);
            DataContext = doctorViewModel;
            InitializeComponent();
            

        }

    }
}