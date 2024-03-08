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


        public IUser CheckUserLogin(string username, string password)
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

        public static async Task<string> GetTodaysFact()
        {
            // Hämta dagens datum
            DateTime today = DateTime.Today;
            string date = $"{today.Month}/{today.Day}";

            // Skapa en HttpClient-instans för att göra HTTP-anrop
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Gör HTTP-anrop till Numbers API
                    string url = $"http://numbersapi.com/{date}/date";
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Kontrollera att anropet var framgångsrikt
                    response.EnsureSuccessStatusCode();

                    // Hämta fakta från svarskroppen
                    string fact = await response.Content.ReadAsStringAsync();
                    return fact;
                }
                catch (HttpRequestException e)
                {
                    // Vid eventuella fel vid anropet, skriv ut felmeddelandet
                    Console.WriteLine($"Error: {e.Message}");
                    return null;
                }
            }
        }
    }
}
