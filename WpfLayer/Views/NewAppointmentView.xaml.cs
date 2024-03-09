using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        //Märk att vi skickar med en callback till denna vy, denna callback är en metod som uppdaterar listan med tidigare bokade tider.
        //Det betyder att den tar en metod som input-parameter, se NewAppointmentViewModel-konstruktorn samt själva metoden i AppointmentManagementViewModel.
        public NewAppointmentView(Doctor doctor, Patient patient, Action<ObservableCollection<Appointment>> updateAppointmentHistoryCallback)
        {
            this.doctor = doctor;
            this.patient = patient;
            newAppointmentViewModel = new NewAppointmentViewModel(doctor, patient, updateAppointmentHistoryCallback);
            DataContext = newAppointmentViewModel;
            InitializeComponent();

            this.Title = "New Appointment";
        }
    }
}
