using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using BusinessLayer;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPF.Models;
using System.Windows;
using System.Windows.Input;
using WPF.Commands;


namespace WPF.ViewModels
{
    
    public class DoctorViewModel : ObservableObject
    {
        public AppointmentController appointmentController = new AppointmentController();
        public ObservableCollection<Appointment> appointments { get; set; } = new ObservableCollection<Appointment>();

        


        public DoctorViewModel(Doctor doctor)
        {
            appointments = new ObservableCollection<Appointment>(appointmentController.GetDoctorSpecificAppointments(doctor));
            
        }

        private Appointment selectedAppointment;
        public Appointment SelectedAppointment
        {
            get { return selectedAppointment; }
            set { selectedAppointment = value; OnPropertyChanged(); }
        }

        private ICommand _openAppMgmtCmd = null;

        public ICommand OpenAppMgmtCmd
        {
            get { return (_openAppMgmtCmd == null) ? _openAppMgmtCmd = new ChooseAppointmentCommand() : _openAppMgmtCmd; }
        }



    }
}
