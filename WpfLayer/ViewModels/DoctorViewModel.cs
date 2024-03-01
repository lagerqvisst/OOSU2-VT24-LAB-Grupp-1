using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfLayer.Models;
using WpfLayer.Views;

namespace WpfLayer.ViewModels
{
    public class DoctorViewModel : ObservableObject
    {
        private readonly AppointmentController appointmentController = new AppointmentController();

        public ObservableCollection<Appointment> Appointments { get; set; } = new ObservableCollection<Appointment>();

        public ICommand OpenAppMgmtCmd { get; private set; }

        public DoctorViewModel(Doctor doctor)
        {
            Appointments = new ObservableCollection<Appointment>(appointmentController.GetDoctorSpecificAppointments(doctor));
            OpenAppMgmtCmd = new RelayCommand(OpenAppointmentManagement, CanOpenAppointmentManagement);
        }

        private Appointment selectedAppointment;
        public Appointment SelectedAppointment
        {
            get { return selectedAppointment; }
            set { selectedAppointment = value; OnPropertyChanged(); }
        }

        

        private bool CanOpenAppointmentManagement()
        {
            return SelectedAppointment != null;
        }

        private void OpenAppointmentManagement()
        {
            if (SelectedAppointment != null)
            {
                AppMgmtView appMgmtView = new AppMgmtView(SelectedAppointment);
                appMgmtView.ShowDialog();

               
            }
        }
    }
    }

