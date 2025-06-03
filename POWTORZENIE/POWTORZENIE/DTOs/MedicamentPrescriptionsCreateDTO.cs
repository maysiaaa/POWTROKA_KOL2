using System.ComponentModel.DataAnnotations;

namespace POWTORZENIE.DTOs;

public class MedicamentPrescriptionsCreateDTO
{
    [Required]
    public int IdMedicament { get; set; }
    [Required]
    public int IdPrescription { get; set; }
    [Required]
    public int Dose { get; set; }
    [Required]
    public string Details { get; set; } = null!;
}