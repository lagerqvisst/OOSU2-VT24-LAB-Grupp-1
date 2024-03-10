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

        public Doctor GetRandomDoctor()
        {
            var random = new Random();
            var doctors = unitOfWork.DoctorRepository.Find(d => true).ToList(); // Hämta alla läkare och konvertera till en lista

            if (doctors.Any())
            {
                var randomIndex = random.Next(0, doctors.Count); // Slumpa ett index inom intervallet av läkarens index
                return doctors[randomIndex]; // Returnera den slumpmässigt valda läkaren
            }
            else
            {
                // Om det inte finns några läkare i listan kan du hantera detta här
                // Till exempel, kasta ett undantag eller returnera null
                return null;
            }
        }

        public Receptionist GetRandomReceptionist()
        {
            var random = new Random();
            var receptionists = unitOfWork.ReceptionistRepository.Find(d => true).ToList(); // Hämta alla läkare och konvertera till en lista

            if (receptionists.Any())
            {
                var randomIndex = random.Next(0, receptionists.Count); // Slumpa ett index inom intervallet av läkarens index
                return receptionists[randomIndex]; // Returnera den slumpmässigt valda läkaren
            }
            else
            {
                // Om det inte finns några läkare i listan kan du hantera detta här
                // Till exempel, kasta ett undantag eller returnera null
                return null;
            }
        }

        /// <summary>
        /// Denna metod och funktionalitet är helt frivillig och frånkopplad från labbuppgiften. 
        /// Den används på login-vyn för att ge lite random trivia till vårdpersonalen när det loggar in om dagens datum.
        /// </summary>

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
