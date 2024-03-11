using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer

    // Här defineras en receptionist. Receptionisten har en unik identifierare i receptionistId,
    // ett namn, ett lösenord och en lista för att hålla reda på möten kopplade till en specifik receptionist.

{
    public class Receptionist : IUser
    {
        public int receptionistId { get; set; } //PK
        public string name { get; set; }

        public string password { get; set; }    
        public List<Appointment> receptionistAppointments { get; set; }

        // Konstruktorn för Receptionisten tar två parametrar (namn och lösenord) och
        // används för att instansiera objektet. Vid instansiering sätts namn och lösenord,
        // och en tom lista för möten skapas och kopplas till receptionisten.

        public Receptionist(string name, string password)
        {
            this.name = name;
            this.password = password;
            receptionistAppointments = new List<Appointment>();
        }

    }
}
