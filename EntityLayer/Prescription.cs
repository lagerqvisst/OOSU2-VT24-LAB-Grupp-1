using EntityLayer.Junction;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Prescription

    {
        #region Properties

        public int prescriptionId { get; set; } // Primärnyckel för receptet.
        public int patientId { get; set; }  // Främmande nyckel för att koppla till en patient.

        public string patientName { get; set; } // Namnet på patienten som receptet är utfärdat för.
        public DateTime dateofPrescription { get; set; } // Datum då receptet utfärdades.

        public ObservableCollection<Drug> drugs { get; set; } = new ObservableCollection<Drug>(); // En samling av läkemedel i receptet.

        public int drugCount { get; set; } // Antalet läkemedel i receptet.

        public List<PrescriptionDrug> PrescriptionDrugs { get; set; } = new List<PrescriptionDrug>(); // En lista som håller reda på sambandet mellan recept och läkemedel.

        #endregion Properties

        // Här skapas en ny instans av observableCollection för att lagra läkemedel. Vi skapar också en 
        // ny lista för att hålla reda på sambandet mellan recept (Prescription) och läkemedel (drugs).


        public Prescription(int patientId,DateTime dateofPrescription)

        #region Instans av observableCollection för att lagra läkemedel
        {
            this.patientId = patientId;
            this.dateofPrescription = dateofPrescription.Date;
            drugs = new ObservableCollection<Drug>();
            PrescriptionDrugs = new List<PrescriptionDrug>();
            patientName = "";


        }
        #endregion Instans av observableCollection för att lagra läkemedel

        #region Metoder för att tilldela värden
        // Metod för att tilldela ett värde till patientName.

        public void SetPatientName(string patientName)
        {
            this.patientName = patientName;
        }

        // Metod för att tilldela ett värde till antal läkemedel (drugCount).
        public void SetDrugCount(int drugCount)
        {
            this.drugCount = drugCount;
        }

        #endregion Metoder för att tilldela värden
    }
}
