using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Junction
{

    /// <summary>
    /// Denna klass är skapad för att kunna skapa en junction table i databasen mellan Prescription och Drug.
    /// Detta eftersom vi har ett många till många förhållande mellan Prescription och Drug.
    /// PK i denna tabell är en kombination av prescriptionId och drugId.
    /// </summary>
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
