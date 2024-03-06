using DataLayer;
using BusinessLayer;
using Microsoft.Data.SqlClient;

namespace TestLayer {     
    class Program {
        static void Main(string[] args)
        {
            PatientMgmtContext context = new PatientMgmtContext();
            UnitOfWork unitOfWork = new UnitOfWork();
            DrugController drugController = new DrugController();
            DiagnosisController diagnosisController = new DiagnosisController();
            //context.Reset();



            //context.Database.EnsureDeleted();

            //context.Database.EnsureCreated();
            //Seed.SeedData(context);


            //drugController.FillDrugsFromApi();
            //unitOfWork.SeedDBDrugs();

<<<<<<< HEAD
         
=======
       
>>>>>>> a2a05d2657f916a6b875873b2197213c4e67c4dd
            
        }
        


    }
}

