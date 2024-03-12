using EntityLayer;
using DataLayer;

namespace BusinessLayer
{
    public class LoginController
    {
        #region UnitOfWork
        private UnitOfWork unitOfWork = new UnitOfWork();
        #endregion UnitOfWork

        #region Authentication Methods
        /// <summary>
        /// Loggar in en receptionist med angivet användarnamn och lösenord.
        /// </summary>
        public Receptionist Login(string username, string password)
        {
            Receptionist receptionist = unitOfWork.ReceptionistRepository.FirstOrDefault(r => r.name == username && r.password == password);
            return receptionist;
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
        /// Kontrollerar inloggningen för en användare (receptionist eller läkare) baserat på angivet användarnamn och lösenord.
        /// Returnerar användaren om den hittades, annars returneras null.
        /// </summary>
        public IUser CheckUserLogin(string username, string password)
        {
            Receptionist receptionist = unitOfWork.ReceptionistRepository.FirstOrDefault(r => r.name == username && r.password == password);
            if (receptionist != null)
            {
                return receptionist;
            }

            Doctor doctor = unitOfWork.DoctorRepository.FirstOrDefault(d => d.name == username && d.password == password);
            if (doctor != null)
            {
                return doctor;
            }

            return null;
        }
        #endregion Authentication Methods

<<<<<<< Updated upstream
=======
        #region Random User Retrieval
        /// <summary>
        /// Hämtar en slumpmässigt vald läkare.
        /// </summary>
        public Doctor GetRandomDoctor()
        {
            var random = new Random();
            var doctors = unitOfWork.DoctorRepository.Find(d => true).ToList();

            if (doctors.Any())
            {
                var randomIndex = random.Next(0, doctors.Count);
                return doctors[randomIndex];
            }
            else
            {
                return null;
            }
        }

>>>>>>> Stashed changes
        /// <summary>
        /// Hämtar en slumpmässigt vald receptionist.
        /// </summary>
        public Receptionist GetRandomReceptionist()
        {
            var random = new Random();
            var receptionists = unitOfWork.ReceptionistRepository.Find(d => true).ToList();

            if (receptionists.Any())
            {
                var randomIndex = random.Next(0, receptionists.Count);
                return receptionists[randomIndex];
            }
            else
            {
                return null;
            }
        }
        #endregion Random User Retrieval

        #region Random Fact Retrieval
        /// <summary>
        /// Hämtar ett slumpmässigt fakta från Numbers API baserat på dagens datum.
        /// </summary>
        public static async Task<string> GetTodaysFact()
        {
            DateTime today = DateTime.Today;
            string date = $"{today.Month}/{today.Day}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"http://numbersapi.com/{date}/date";
                    HttpResponseMessage response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    string fact = await response.Content.ReadAsStringAsync();
                    return fact;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return null;
                }
            }
        }
        #endregion Random Fact Retrieval
    }

}
