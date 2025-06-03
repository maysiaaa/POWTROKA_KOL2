using POWTORZENIE.Models;

namespace POWTORZENIE.DTOs;

public class PatientGetDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime Birthdate { get; set; }
    public virtual ICollection<Prescription> Prescriptions { get; set; } = null!;
    public virtual ICollection<Medicament> Medicaments { get; set; } = null!;
}