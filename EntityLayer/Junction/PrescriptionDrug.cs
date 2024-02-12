using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Junction
{
    public class PrescriptionDrug
    {
        public int prescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public int drugId { get; set; }
        public Drug Drug { get; set; }

        public PrescriptionDrug(int prescriptionId, int drugId)
        {
            this.prescriptionId = prescriptionId;
            this.drugId = drugId;
        }
    }
}
