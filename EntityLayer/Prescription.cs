﻿using EntityLayer.Junction;
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
        #region Presrcription properties

        public int prescriptionId { get; set; } // Primärnyckel för Prescription.
        public int patientId { get; set; }  // Främmande nyckel för att koppla till en patient.
        public string patientName { get; set; } // Namnet på patienten som Prescription är utfärdat för.
        public DateTime dateofPrescription { get; set; } // Datum då Prescription utfärdades.

        public ObservableCollection<Drug> drugs { get; set; } = new ObservableCollection<Drug>(); // En samling av Drugs i Prescription.

        public int drugCount { get; set; } // Antalet Drugs i Prescription.

        public List<PrescriptionDrug> PrescriptionDrugs { get; set; } = new List<PrescriptionDrug>(); // En lista som håller reda på sambandet mellan Prescription & Drugs.

        #endregion Presrcription properties

        // Här skapas en ny instans av observableCollection för att lagra läkemedel. Vi skapar också en 
        // ny lista för att hålla reda på sambandet mellan recept (Prescription) och läkemedel (Drugs).


        //Konstruktor för att instansiera en Prescription
        public Prescription(int patientId,DateTime dateofPrescription)

        #region Instans av observableCollection för att lagra läkemedel
        {
            this.patientId = patientId;
            this.dateofPrescription = dateofPrescription.Date;
            drugs = new ObservableCollection<Drug>(); //Lägger till listan för varje instans för att det inte ska vara null.
            PrescriptionDrugs = new List<PrescriptionDrug>(); //Lägger till listan för varje instans för att det inte ska vara null.
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
