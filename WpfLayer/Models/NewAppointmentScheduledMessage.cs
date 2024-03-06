using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLayer.Models
{
    public class NewAppointmentScheduledMessage
    {
        public List<Appointment> UpdatedAppointmentHistory { get; private set; }

        public NewAppointmentScheduledMessage(List<Appointment> updatedAppointmentHistory)
        {
            UpdatedAppointmentHistory = updatedAppointmentHistory;
        }
    }

}
