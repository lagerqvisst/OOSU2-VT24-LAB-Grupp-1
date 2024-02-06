using DataLayer;

namespace TestLayer
{
    public class Program
    {
        public static UnitOfWork unitOfWork;
        public static void Main(string[] args)
        {
            PatientMgmtContext context = new PatientMgmtContext();
            unitOfWork = new UnitOfWork();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Seed.SeedData(context);

            Console.WriteLine("Do you want to create a new patient? - PRESS 1");
            int choice = int.Parse(Console.ReadLine());

            if(choice == 1)
            {
                unitOfWork.CreatePatient("test1234", "xtxTest patient", "test adress", "test phone 123213321", "test@gmail.com");
            }
            

            Console.ReadLine(); 
        }
    }
}
        