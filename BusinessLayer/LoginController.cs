using EntityLayer;
using DataLayer;

namespace BusinessLayer
{
    public class LoginController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public Receptionist Login(string Username, string Password)
        {
            Receptionist receptionist = unitOfWork.ReceptionistRepository.FirstOrDefault(r => r.name == Username && r.password == Password);
            return receptionist;

        }

      
        public dynamic LoginTest(string username, string password)
        {
            // Försök hitta en receptionist med användarnamn och lösenord
            Receptionist receptionist = unitOfWork.ReceptionistRepository.FirstOrDefault(r => r.name == username && r.password == password);
            if (receptionist != null)
            {
                return receptionist; // Returnera receptionisten om den hittades
            }

            // Försök hitta en läkare med användarnamn och lösenord
            Doctor doctor = unitOfWork.DoctorRepository.FirstOrDefault(d => d.name == username && d.password == password);
            if (doctor != null)
            {
                return doctor; // Returnera läkaren om den hittades
            }

            // Om varken en receptionist eller en läkare hittades, returnera null
            return null;
        }
        

    }
}
