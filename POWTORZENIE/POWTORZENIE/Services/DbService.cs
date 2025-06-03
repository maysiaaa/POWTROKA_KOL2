using Microsoft.EntityFrameworkCore;
using POWTORZENIE.Data;
using POWTORZENIE.DTOs;
using POWTORZENIE.Exceptions;
using POWTORZENIE.Models;

namespace POWTORZENIE.Services;

public interface IDbService
{
    //public Task<ICollection<StudentGetDto>> GetStudentsDetailsAsync();
    public Task<PatientGetDTO> GetPatientDetailsByIdAsync(int patientId);
    public Task CreatePrescriptionAsync(PrescriptionCreateDTO prescriptionDetails);
    //public Task RemoveStudentAsync(int studentId);
    //public Task UpdateStudentAsync(int studentId, StudentUpdateDto studentData);
}
public class DbService(AppDbContext data) : IDbService
{
    public async Task<PatientGetDTO> GetPatientDetailsByIdAsync(int patientId)
    {
        var patient = await data.Patients.FirstOrDefaultAsync(p => p.IdPatient == patientId);
        if (patient is null)
        {
            throw new NotFoundException("Patient not found");
        }

        var patientDetails = new PatientGetDTO
        {
            Birthdate = patient.Birthdate,
            LastName = patient.LastName,
            FirstName = patient.FirstName,
            IdPatient = patient.IdPatient,
            Prescriptions = patient.Prescriptions
        };
        
        return patientDetails;

    }

    public async Task CreatePrescriptionAsync(PrescriptionCreateDTO prescriptionDetails)
    {
        var patient = await data.Patients.FirstOrDefaultAsync(p => p.IdPatient == prescriptionDetails.Patient.IdPatient);
        if (patient is null)
        {
            var newPatient = new Patient
            {
                IdPatient = prescriptionDetails.Patient.IdPatient,
                FirstName = prescriptionDetails.Patient.FirstName,
                LastName = prescriptionDetails.Patient.LastName,
                Birthdate = prescriptionDetails.Patient.Birthdate,
            };
            await data.Patients.AddAsync(newPatient);
            await data.SaveChangesAsync();
        }
        
        foreach (var med in prescriptionDetails.Medicaments)
        {
            var medId = await data.Medicaments.FirstOrDefaultAsync(g => g.IdMedicament == med.IdMedicament);
            if (medId is null)
            {
                throw new NotFoundException($"Medicament with id: {med.IdMedicament} not found");
            }
        }

        if (prescriptionDetails.Medicaments.Count > 10)
        {
            throw new TooManyMedicamentsException("The prescription is too long");
        }

        var medicamentsList = (prescriptionDetails.Medicaments ?? []).Select(med => new Prescription_Medicament
        {
            IdMedicament = med.IdMedicament,
            IdPrescription = med.IdPrescription,
            Dose = med.Dose,
            Details = med.Details
        }).ToList();
        
        var newPrescription = new Prescription
        {
            DueDate = prescriptionDetails.DueDate,
            Date = prescriptionDetails.Date,
            IdDoctor = prescriptionDetails.IdDoctor,
            IdPatient = prescriptionDetails.Patient.IdPatient,
            PrescriptionMedicaments = medicamentsList,
        };
        await data.Prescriptions.AddAsync(newPrescription);
        await data.SaveChangesAsync();
    }
}