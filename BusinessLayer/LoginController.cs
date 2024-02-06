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

    }
}
