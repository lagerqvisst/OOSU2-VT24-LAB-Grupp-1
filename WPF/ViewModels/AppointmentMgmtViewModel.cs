using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using BusinessLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.Commands;
using System.Windows;
using WPF.Models;

namespace WPF.ViewModels
{
    public class AppointmentMgmtViewModel : ObservableObject
    {
        //CONTROLLER KLASSER 
        public AppointmentController appointmentController = new AppointmentController();
        public DrugController drugController = new DrugController();
        public PrescriptionController prescriptionController = new PrescriptionController();
        public DoctorController doctorController = new DoctorController();
        public PatientController patientController = new PatientController();

        //LISTOR SOM KOMMER VISAS I DATAGRIDS 
        public ObservableCollection<Prescription> prescriptions { get; set; } = new ObservableCollection<Prescription>();
        public ObservableCollection<Drug> drugs { get; set; } = new ObservableCollection<Drug>();
        public ObservableCollection<Appointment> appointments { get; set; } = new ObservableCollection<Appointment>();

        public Appointment appointment; 

        public AppointmentMgmtViewModel(Appointment appointment)
        {
            prescriptions = new ObservableCollection<Prescription>(prescriptionController.GetAllPrescriptions()); //PLACEHOLDER METOD - GÖR NY FÖR ATT VISA ENBART FÖR PATIENT
            drugs = new ObservableCollection<Drug>(drugController.GetAllDrugs()); //PLACEHOLDER METOD - GÖR NY FÖR ATT VISA ENBART FÖR PATIENT
            appointments = new ObservableCollection<Appointment>(appointmentController.GetAllAppointments()); //PLACEHOLDER METOD - GÖR NY FÖR ATT VISA ENBART FÖR PATIENT

            this.appointment = appointment;
        }

        private string _doctorsNote;
        public string DoctorsNote
        {
            get { return _doctorsNote; }
            set
            {
                _doctorsNote = value;
                OnPropertyChanged(); // Förutsatt att du har implementerat INotifyPropertyChanged
            }
        }

        public void UpdateDoctorsNote(string note)
        {
            if (appointment != null)
            {
                
                appointmentController.UpdateAppointmentDoctorsNote(appointment, note);
                MessageBox.Show("Doktorsnoteringen har uppdaterats");
            }
        }

        private ICommand _addDoctorsNoteCommand;
        public ICommand AddDoctorsNoteCommand
        {
            get
            {
                if (_addDoctorsNoteCommand == null)
                {
                    _addDoctorsNoteCommand = new AddDoctorsNoteCommand(this);
                }
                return _addDoctorsNoteCommand;
            }
        }

    }
}
