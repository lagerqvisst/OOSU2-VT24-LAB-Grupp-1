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
using System.Windows.Input;
using WpfLayer.Models;
using WpfLayer.Views;

namespace WpfLayer.ViewModels
{
    public class DoctorViewModel : ObservableObject
    {
        //Kontroller som används för att komma åt metoder
        private readonly AppointmentController appointmentController = new AppointmentController();

        // Properties som är bundna i XAML
        private string doctorName;
        private Appointment selectedAppointment;
        public ObservableCollection<Appointment> Appointments { get; set; }


        // Alla Commands som används i vyn
        #region Commands
        public ICommand OpenAppMgmtCmd { get; private set; }
        public ICommand SignOutCmd { get; private set; }
        public ICommand DataGridShowDetailsCmd { get; private set; }
        #endregion

        public DoctorViewModel(Doctor doctor)
        {
            
            //Sätter doktorns namn till doctorName propertyn som är bunden i XAML
            doctorName = $"Signed in as Doctor: {doctor.name}";
            
            
            //Hämtar alla doktorns kommande och nuvarande bokade tider
            Appointments = new ObservableCollection<Appointment>(appointmentController.GetDoctorSpecificAppointmentsTodayAndFuture(doctor));

            //Initierar alla commands med metoder som ska köras
            #region Commands initialization
            OpenAppMgmtCmd = new RelayCommand(OpenAppointmentManagement, CanOpenAppointmentManagement);
            SignOutCmd = new RelayCommand(SignOut);
            DataGridShowDetailsCmd = new RelayCommand(ShowDetails, CanShowDetails);
            #endregion
        }

        // Properties som är bundna i XAML
        #region Properties bound in XAML
        public Appointment SelectedAppointment
        {
            get { return selectedAppointment; }
            set { selectedAppointment = value; OnPropertyChanged(); }
        }

        public string DoctorName
        {
            get { return doctorName; }
            set { doctorName = value; OnPropertyChanged(); }
        }
        #endregion


        // Alla metoder som är bundna till commands
        #region Methods bound to commands
        //Kollar så att det finns en vald appointment
        private bool CanOpenAppointmentManagement()
        {
            return SelectedAppointment != null;
        }
        //Öppnar en ny vy om vald appointment inte är null med den valda appointmenten
        private void OpenAppointmentManagement()
        {
            if (SelectedAppointment != null)
            {
                AppMgmtView appMgmtView = new AppMgmtView(SelectedAppointment);
                appMgmtView.ShowDialog();
            }
        }

        //Kollar så att det finns en vald appointment
        private bool CanShowDetails()
        {
            return SelectedAppointment != null;
        }

        //Visar doctorsnote och appointmentReason om vald appointment
        public void ShowDetails()
        {
            if (SelectedAppointment != null)
            {
                MessageBox.Show($"Doctors note: {SelectedAppointment.doctorsNote}\n\nReason for appointment: {SelectedAppointment.appointmentReason}");
            }
        }

        //Metod för att logga ut
        private void SignOut()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to sign out?", "Sign out", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                currentWindow?.Close();
            }
        }
        #endregion

    }
}

