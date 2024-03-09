using EntityLayer;
using EntityLayer.Junction;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PatientMgmtContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sqlutb2-db.hb.se, 56077;Database=oosu2444;User Id=oosu2444;Password=UML928;TrustServerCertificate=True;Encrypt=True;");




            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Någon kan förklara hur vi skapar ett junctiontable? :) /alex

            modelBuilder.Entity<PrescriptionDrug>()
              .HasKey(pd => new { pd.prescriptionId, pd.drugId });

            modelBuilder.Entity<PrescriptionDrug>()
                .HasOne(pd => pd.Prescription)
                .WithMany(p => p.PrescriptionDrugs)
                .HasForeignKey(pd => pd.prescriptionId);

            modelBuilder.Entity<PrescriptionDrug>()
                .HasOne(pd => pd.Drug)
                .WithMany(d => d.PrescriptionDrugs)
                .HasForeignKey(pd => pd.drugId);


        }
        public void Reset()
        {
            #region Remove Tables
            using (SqlConnection conn = new SqlConnection(Database.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand("EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'; EXEC sp_msforeachtable 'DROP TABLE ?'", conn))
            {
                conn.Open();
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Exception)
                    {
                        // throw;
                    }
                }
                conn.Close();
            }
            #endregion
        }

        //Tabellerna som ska skapas i databasen
        #region DbSets
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<PrescriptionDrug> PrescriptionDrugs { get; set; }  
        #endregion

    }
}
