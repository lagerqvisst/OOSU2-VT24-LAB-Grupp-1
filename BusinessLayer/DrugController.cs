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
        private UnitOfWork unitOfWork = new UnitOfWork();
        #endregion UnitOfWork

        #region CRUD Operations
        /// <summary>
        /// Hämtar alla läkemedel från databasen.
        /// </summary>
        public List<Drug> GetAllDrugs()
        {
            return unitOfWork.DrugRepository.Find(d => true).ToList();
        }

        /// <summary>
        /// Hämtar läkemedel baserat på recept-ID från databasen.
        /// </summary>
        public List<Drug> GetDrugsByPrescriptionId(int prescriptionId)
        {
            return unitOfWork.PrescriptionDrugRepository.Find(p => p.prescriptionId == prescriptionId).Select(p => p.Drug).ToList();
        }

        /// <summary>
        /// Hämtar ett läkemedel baserat på läkemedels-ID från databasen.
        /// </summary>
        public Drug GetDrugsByDrugId(int drugId)
        {
            return unitOfWork.DrugRepository.FirstOrDefault(d => d.DrugId == drugId);
        }
        #endregion CRUD Operations

        #region Extra Functionality (API drugnames)
        /// <summary>
        /// Hämtar data från en API och returnerar en lista med namn på läkemedel.
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
