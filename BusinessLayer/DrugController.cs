using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataLayer;
using Newtonsoft.Json.Linq;

namespace BusinessLayer
{
    public class DrugController
    {
        #region UnitOfWork
        // Skapar en instans av UnitOfWork för att kunna använda sig av metoder från UnitOfWork.
        private UnitOfWork unitOfWork = new UnitOfWork();
        #endregion UnitOfWork

        #region CRUD Operations
        
        // Hämtar alla läkemedel från databasen och returnerar en lista.
        public List<Drug> GetAllDrugs()
        {
            return unitOfWork.DrugRepository.Find(d => true).ToList();
        }
        
        // Här används ett junction table som hämtar alla Drugs inom ett PrescriptionId och returnerar en lista med Drugs.
        public List<Drug> GetDrugsByPrescriptionId(int prescriptionId)
        {
            return unitOfWork.PrescriptionDrugRepository.Find(p => p.prescriptionId == prescriptionId).Select(p => p.Drug).ToList();
        }
        
        // Hämtar ett läkemedel baserat på DrugId från databasen.
        public Drug GetDrugsByDrugId(int drugId)
        {
            return unitOfWork.DrugRepository.FirstOrDefault(d => d.DrugId == drugId);
        }
        #endregion CRUD Operations

        #region Extra Functionality (API drugnames)
        /// <summary>
        /// Hämtar data från en API och returnerar en lista med namn på läkemedel (Out of Scope).
        /// </summary>
        /// <returns>En lista med namn på läkemedel.</returns>
        public List<string> ApiDrugDataExtract()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://dailymed.nlm.nih.gov/dailymed/services/v2/drugnames.json?pagesize=100&page=2"),
            };

            using (var response = client.SendAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync().Result;

                var jsonObject = JObject.Parse(body);
                var dataArray = jsonObject["data"];

                List<string> drugNames = new List<string>();

                foreach (var dataItem in dataArray)
                {
                    var drugName = dataItem["drug_name"];
                    if (drugName != null)
                    {
                        drugNames.Add(drugName.ToString());
                    }
                }

                return drugNames;
            }
        }

        /// <summary>
        /// Fyller databasen med läkemedelsdata från en API.
        /// </summary>
        public void FillDrugsFromApi()
        {
            List<string> DrugNames = ApiDrugDataExtract();
            List<Drug> drugs = new List<Drug>();

            foreach (var drugName in DrugNames)
            {
                Drug drug = new Drug(drugName);
                drugs.Add(drug);
                unitOfWork.DrugRepository.Add(drug);
            }
        }
        #endregion 
    }

}
