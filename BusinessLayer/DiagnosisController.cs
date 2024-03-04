﻿using System;
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
        UnitOfWork unitOfWork = new UnitOfWork();

        public Diagnosis AddDiagnosis(int patientId, string diagnosisDescription, DateTime dateOfDiagnosis, string treatmentSuggestion)
        {
            Diagnosis diagnosis = new Diagnosis(patientId, diagnosisDescription, dateOfDiagnosis, treatmentSuggestion);
            unitOfWork.CreateDiagnosis(diagnosis);
            return diagnosis;
        }

        public List<Diagnosis> PatientDiagnosis(Patient patient)
        {
            return unitOfWork.DiagnosisRepository.Find(d => d.patientId == patient.patientId).ToList(); 
        }


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
        }

    }


}
