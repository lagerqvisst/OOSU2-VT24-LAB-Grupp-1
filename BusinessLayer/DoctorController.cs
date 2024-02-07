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
       UnitOfWork unitOfWork = new UnitOfWork();


        public Doctor GetDoctorById(int doctorId)
        {
            return unitOfWork.DoctorRepository.FirstOrDefault(d => d.doctorID == doctorId);
        }
        public List<Doctor> GetAllDoctors()
        {
            return unitOfWork.DoctorRepository.Find(d => true).ToList();
        }


    }
}
