using DataLayer;

namespace TestLayer {     
    class Program {
        static void Main(string[] args)
        {
            PatientMgmtContext context = new PatientMgmtContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Seed.SeedData(context);
        }
    }
}
