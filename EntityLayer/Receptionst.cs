using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer

    // Här defineras en receptionist. Receptionisten har en unik identifierare i receptionistId,
    // ett namn, ett lösenord och en lista för att hålla reda på möten kopplade till en specifik receptionist.

{
    //Ärver av IUser för att kunna logga in som Receptionist
    public class Receptionist : IUser

        #region Receptionist properties 
    {
        public int receptionistId { get; set; } //Primärnyckel för receptionisten.
        public string name { get; set; } //Användarnamnet för receptionisten.
        public string password { get; set; } //Lösenord för receptionisten.
        public List<Appointment> receptionistAppointments { get; set; } //Lista för att hålla reda på de Appointments receptionisten har bokat.

        #endregion Receptionist properties 

        // Konstruktorn för Receptionisten tar två parametrar (namn och lösenord) och
        // används för att instansiera objektet. Vid instansiering sätts namn och lösenord,
        // och en tom lista för möten skapas och kopplas till receptionisten.

        #region Constructor
        public Receptionist(string name, string password)
        {
            this.name = name;
            this.password = password;
            receptionistAppointments = new List<Appointment>(); //Lägger till listan för varje instans för att det inte ska vara null.
        }
        #endregion Constructor
    }
}
