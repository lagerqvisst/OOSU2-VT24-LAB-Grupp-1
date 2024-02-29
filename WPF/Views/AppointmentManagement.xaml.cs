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
using WPF.ViewModels;

namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for AppointmentManagement.xaml
    /// </summary>
    public partial class AppointmentManagement : Window
    {
        Appointment selectedAppointment;

        AppointmentMgmtViewModel appointmentMgmtViewModel { get; set; }

        public AppointmentManagement(Appointment selectedAppointment)
        {
            this.selectedAppointment = selectedAppointment;
            appointmentMgmtViewModel = new AppointmentMgmtViewModel(selectedAppointment);
            DataContext = appointmentMgmtViewModel;
            InitializeComponent();

            
        }
    }
}
