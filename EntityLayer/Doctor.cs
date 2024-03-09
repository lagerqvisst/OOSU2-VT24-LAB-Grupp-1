using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Doctor: IUser
    {
        public int doctorID { get; set; }   //PK
        public string specialization { get; set; }

        public string name { get; set; }

        public string password { get; set; }
        public List<Appointment> Appointments { get; set; } // Navigationsegenskap

        public Doctor(string name, string password, string specialization)
        {
            this.specialization = specialization;
            this.name = name;
            this.password = password;
            Appointments = new List<Appointment>();
        }
    }

}

