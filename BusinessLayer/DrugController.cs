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
        UnitOfWork unitOfWork = new UnitOfWork();


        public List<Drug> GetAllDrugs()
        {
            return unitOfWork.DrugRepository.Find(d => true).ToList();
        }

        public List<Drug> GetDrugsByPrescriptionId(int prescriptionId)
        {
            return unitOfWork.PrescriptionDrugRepository.Find(p => p.prescriptionId == prescriptionId).Select(p => p.Drug).ToList();
        }
        public Drug GetDrugsByDrugId(int drugId)
        {
            return unitOfWork.DrugRepository.FirstOrDefault(d => d.DrugId == drugId);
        }


        /// <summary>
        /// Nedanstående metoder är inte kopplade till labbkraven utan extra funktionalitet för att öva på att hämta data från en API.
        /// </summary>


        //Metoden returnerar en lista med namn på läkemedel från en API som en stränglista
        //Ni kan se användningsområdet i prescription vyn där läkaren kan välja läkemedel som ska skrivas ut på receptet.
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
        //För att öva på ett flow av att kunna ta information från ett API och lagra i en databas skapar vi en metod som hämtar data från API och lagrar i databasen.
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


    }
}
