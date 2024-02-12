using EntityLayer;
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
            optionsBuilder.UseSqlServer(@"Server=sqlutb2-db.hb.se,56077;Database=oosu2401;User Id=oosu2401;Password=DES049;TrustServerCertificate=True;");



            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.patient)
                .WithMany(p => p.patientAppointments)
                .HasForeignKey(a => a.patientId);

            modelBuilder.Entity<Appointment>()  
                .HasOne(a => a.doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.doctorID)
                .OnDelete(DeleteBehavior.Cascade);
                

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.receptionist)
                .WithMany(r => r.receptionistAppointments)
                .HasForeignKey(a => a.receptionistId);      


        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

    }
}
