using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    //Ärver av IUser för att kunna logga in som Doctor
    public class Doctor : IUser

        #region Doctor properties
    {
        public int doctorID { get; set; } // Primärnyckel för doktorn.
        public string specialization { get; set; } // Specialisering för doktorn.

        public string name { get; set; } // Namn på doktorn.

        public string password { get; set; } // Lösenord för doktorn.
        public List<Appointment> Appointments { get; set; } // Lista för att hålla reda på doktorns bokade tider.
        #endregion Doctor properties

        #region Constructor
        public Doctor(string name, string password, string specialization)
        {
            this.specialization = specialization;
            this.name = name;
            this.password = password;

            //Initialiserar listan för att hålla reda på doktorns bokade tider.
            Appointments = new List<Appointment>(); //Lägger till listan för varje instans för att det inte ska vara null.
        }
        #endregion Constructor
    }

}

