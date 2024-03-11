using EntityLayer;
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
    /// Interaction logic for DoctorView.xaml
    /// </summary>
    public partial class DoctorView : Window
    {
        DoctorViewModel doctorViewModel;
        public DoctorView(Doctor doctor)
        {
           
            //Skickar doctor objektet från Log In view till DoctorViewModel
            doctorViewModel = new DoctorViewModel(doctor);
            DataContext = doctorViewModel;

            InitializeComponent();

            this.Title = "Doctor Appointments";

        }
    }
}
