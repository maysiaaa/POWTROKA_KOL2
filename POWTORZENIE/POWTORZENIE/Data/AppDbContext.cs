using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using POWTORZENIE.Models;

namespace POWTORZENIE.Data;

public class AppDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Prescription_Medicament> PrescriptionsMedicaments { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var doctor = new List<Doctor>
        {
            new()
            {
                IdDoctor = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com",
            }
        };

        var medicament = new List<Medicament>
        {
            new ()
            {
                IdMedicament = 1,
                Name = "16c",
                Description = "over 16 years old",
                Type = "Pain",
            }
        };

        var patient = new List<Patient>
        {
            new()
            {
                IdPatient = 1,
                FirstName = "John",
                LastName = "Doe",
                Birthdate = DateTime.Now,
            }
        };
        
        var prescription = new List<Prescription>
        {
            new()
            {
                IdPatient = 1,
                IdDoctor = 1,
                IdPrescription = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Now,
            }
        };
        
        var prescriptionmedicament = new List<Prescription_Medicament>
        {
            new()
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 4,
                Details = "Once a day"
            }
        };
        
        modelBuilder.Entity<Doctor>().HasData(doctor);
        modelBuilder.Entity<Medicament>().HasData(medicament);
        modelBuilder.Entity<Patient>().HasData(patient);
        modelBuilder.Entity<Prescription>().HasData(prescription);
        modelBuilder.Entity<Prescription_Medicament>().HasData(prescriptionmedicament);
    }
}