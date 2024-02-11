using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Receptionist : IUser
    {
        public int receptionistId { get; set; } 
        public string name { get; set; }

        public string password { get; set; }    
        public List<Appointment> receptionistAppointments { get; set; }

        public Receptionist(string name, string password)
        {
            this.name = name;
            this.password = password;
            receptionistAppointments = new List<Appointment>();
        }

    }
}
