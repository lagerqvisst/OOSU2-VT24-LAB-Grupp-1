﻿using BusinessLayer;
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
        //Controller class to return appointment object based on doctor object in the view
        private readonly AppointmentController appointmentController = new AppointmentController();

        // Properties that are binded in XAML
        private string doctorName;
        private Appointment selectedAppointment;
        public ObservableCollection<Appointment> Appointments { get; set; }


        // Commands
        #region Commands
        public ICommand OpenAppMgmtCmd { get; private set; }
        public ICommand SignOutCmd { get; private set; }
        public ICommand DataGridShowDetailsCmd { get; private set; }
        #endregion

        public DoctorViewModel(Doctor doctor)
        {
            //Setting the doctor's name to the doctorName property that is binded in XAML
            doctorName = $"Signed in as Doctor: {doctor.name}";
            
            //Assigning the doctor's appointments to the ObservableCollection
            Appointments = new ObservableCollection<Appointment>(appointmentController.GetDoctorSpecificAppointmentsTodayAndFuture(doctor));

            //Initialize commands
            #region Commands initialization
            OpenAppMgmtCmd = new RelayCommand(OpenAppointmentManagement, CanOpenAppointmentManagement);
            SignOutCmd = new RelayCommand(SignOut);
            DataGridShowDetailsCmd = new RelayCommand(ShowDetails, CanShowDetails);
            #endregion
        }

        // Properties that are binded in XAM
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


        // Methos that are binded to the commands
        #region Methods bound to commands
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

        private bool CanShowDetails()
        {
            return SelectedAppointment != null;
        }

        public void ShowDetails()
        {
            if (SelectedAppointment != null)
            {
                MessageBox.Show($"Doctors note: {SelectedAppointment.doctorsNote}\n\nReason for appointment: {SelectedAppointment.appointmentReason}");
            }
        }

        //Other Methods for navigation
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

