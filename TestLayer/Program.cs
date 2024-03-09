using DataLayer;
using BusinessLayer;
using Microsoft.Data.SqlClient;

namespace TestLayer {     
    class Program {
        static void Main(string[] args)
        {

            //Detta projekt används för att testa metoder och klasser i BusinessLayer och DataLayer
            //Främst används projektet för att seeda om databasen när vi migrerar till en ny version av databasen

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


            
        }
        


    }
}

