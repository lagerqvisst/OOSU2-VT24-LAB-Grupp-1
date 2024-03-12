using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;

namespace BusinessLayer
{

    public class DoctorController
    {
        #region UnitOfWork
        private UnitOfWork unitOfWork = new UnitOfWork();
        #endregion UnitOfWork

        #region CRUD Operations

        // Hämtar en läkare baserat på läkarens ID från databasen och returnerar läkarens information

       
        public Doctor GetDoctorById(int doctorId)
        {
            return unitOfWork.DoctorRepository.FirstOrDefault(d => d.doctorID == doctorId);
        }

        // Hämtar alla läkare från databasen returnar en lista med alla läkare.
        public List<Doctor> GetAllDoctors()
        {
            return unitOfWork.DoctorRepository.Find(d => true).ToList();
        }

        #endregion #region CRUD Operations
    }
}
