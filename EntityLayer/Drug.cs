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
        #region Drug properties

        public int DrugId { get; set; } // PK. Unik identifierare för läkemedlet.
        public string DrugName { get; set; } // Namnet på läkemedlet.

        public List<PrescriptionDrug> PrescriptionDrugs { get; set; } // Lista som håller reda på sambandet mellan läkemedlet och recept (Junction table).

        #endregion Drug properties

        #region Constructor
        public Drug(string drugName)
        {
            this.DrugName = drugName; // Konstruktor som sätter namnet på läkemedlet vid instansiering.
        }
        #endregion Constructor
    }
}
