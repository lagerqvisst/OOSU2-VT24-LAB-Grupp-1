using EntityLayer.Junction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Drug
    {
        public int DrugId { get; set; }
        public string DrugName { get; set; }

        public List<PrescriptionDrug> PrescriptionDrugs { get; set; }


        public Drug(string drugName)
        {
            this.DrugName = drugName;
        }
    }
}
