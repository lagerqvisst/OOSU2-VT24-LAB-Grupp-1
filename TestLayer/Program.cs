using DataLayer;
using BusinessLayer;

namespace TestLayer {     
    class Program {
        static void Main(string[] args)
        {
            PatientMgmtContext context = new PatientMgmtContext();
            UnitOfWork unitOfWork = new UnitOfWork();
            DrugController drugController = new DrugController();
            //context.Database.EnsureDeleted();

            //context.Database.EnsureCreated();
            //Seed.SeedData(context);


            drugController.FillDrugsFromApi();
            unitOfWork.SeedDBDrugs();
        }
    }
}
