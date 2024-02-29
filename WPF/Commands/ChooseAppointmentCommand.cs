using EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using WPF.Views;

namespace WPF.Commands
{
    public class ChooseAppointmentCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return parameter != null && parameter is Appointment;
        }

        public override void Execute(object parameter)
        {
            //IS DIS BEST PRACTISE YES OR NO?
            if (parameter is Appointment selectedAppointment)
            {
                AppointmentManagement appointmentManagement = new AppointmentManagement(selectedAppointment);
                appointmentManagement.Show();
                appointmentManagement.txtBoxDoctorNote.Focus(); 
                
            }
        }
    }
}
