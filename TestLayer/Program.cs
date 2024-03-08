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

            string fact = LoginController.GetTodaysFact().Result;
            Console.WriteLine(fact);
            Console.ReadLine();

            //context.Reset();



            //context.Database.EnsureDeleted();

            //context.Database.EnsureCreated();
            //Seed.SeedData(context);


            //drugController.FillDrugsFromApi();
            //unitOfWork.SeedDBDrugs();


            
        }
        


    }
}

