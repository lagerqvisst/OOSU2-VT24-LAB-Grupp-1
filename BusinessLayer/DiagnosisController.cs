using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;
using Newtonsoft.Json.Linq;

namespace BusinessLayer
{
    public class DiagnosisController
    {

        #region UnitOfWork
        // Skapar en instans av UnitOfWork för att kunna använda sig av metoder från UnitOfWork.
        UnitOfWork unitOfWork = new UnitOfWork();
        #endregion

        #region CRUD Operations

        //Skapa / Lägg till diagnos för specifik patient
        public Diagnosis AddDiagnosis(int patientId, string diagnosisDescription, DateTime dateOfDiagnosis, string treatmentSuggestion)
        {
            Diagnosis diagnosis = new Diagnosis(patientId, diagnosisDescription, dateOfDiagnosis, treatmentSuggestion);
            unitOfWork.CreateDiagnosis(diagnosis);
            return diagnosis;
        }

        //Hämta en lista av diagnoser för specifik patient
        public List<Diagnosis> PatientDiagnosis(Patient patient)
        {
            return unitOfWork.DiagnosisRepository.Find(d => d.patientId == patient.patientId).ToList(); 
        }
        #endregion CRUD Operations


        /// <summary>
        /// Metoderna nedan är inte kopplat till labbkraven utan extra funktionalitet för att öva på att hämta data från en API.
        /// </summary>

        // Metoden används i WPF för att fylla en combobox med diagnoser från en API vilket är en del av workflowet för en läkare att 
        // först skapa en huvudklassificering av diagnos och sedan en underklassificering som är i fritext.


        #region Extract conditions API

        //API (Out of Scope)
        public List<string> ExtractMedicalConditionsFromApi()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://clinicaltables.nlm.nih.gov/api/conditions/v3/search?terms=&maxList=500&count=500"),
            };

            try
            {
                using (var response = client.SendAsync(request).Result)
                {
                    response.EnsureSuccessStatusCode();
                    var body = response.Content.ReadAsStringAsync().Result;

                    var jsonArray = JArray.Parse(body);
                    var conditionsArray = jsonArray[3]; // Element 4 in the outer array

                    var medicalConditions = new List<string>();
                    foreach (var condition in conditionsArray)
                    {
                        var conditionName = condition[0].ToString(); // Extracting the first element of each inner array
                        medicalConditions.Add(conditionName);
                    }
                    
                    medicalConditions.Sort();
                    return medicalConditions;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        #endregion Extract conditions API
        //Denna metod används i DhViewModel vilket är en extravy som fungerar som ett hjälpmedel för en läkare som kan söka efter conditions.
        //Sökinputen från användaren skickas med som parameter och max antal resultat som ska visas.

        #region QueryApi for Medical Conditions
        //API (Out of Scope)
        public List<string> QueryApiForMedicalConditions(string searchTerm, int maxResults)
        {
            var client = new HttpClient();
            var requestUri = $"https://clinicaltables.nlm.nih.gov/api/conditions/v3/search?terms={searchTerm}&maxList={maxResults}&count={maxResults}";

            try
            {
                var response = client.GetAsync(requestUri).Result;
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync().Result;

                var jsonArray = JArray.Parse(body);
                var conditionsArray = jsonArray[3]; // Element 4 in the outer array

                var medicalConditions = new List<string>();
                foreach (var condition in conditionsArray)
                {
                    var conditionName = condition[0].ToString(); // Extracting the first element of each inner array
                    medicalConditions.Add(conditionName);
                }

                medicalConditions.Sort();
                return medicalConditions;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            #endregion QueryApi for Medical Conditions
        }
    }
}
