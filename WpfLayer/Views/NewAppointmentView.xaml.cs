using BusinessLayer;
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
    /// Interaction logic for NewAppointmentView.xaml
    /// </summary>
    public partial class NewAppointmentView : Window
    {
        Doctor doctor;
        Patient patient;


        NewAppointmentViewModel newAppointmentViewModel;
        public NewAppointmentView(Doctor doctor, Patient patient)
        {
            this.doctor = doctor;
            this.patient = patient;
            newAppointmentViewModel = new NewAppointmentViewModel(doctor, patient);
            DataContext = newAppointmentViewModel;
            InitializeComponent();
        }
    }
}
