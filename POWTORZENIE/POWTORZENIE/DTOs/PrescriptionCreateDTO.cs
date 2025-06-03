using System.ComponentModel.DataAnnotations;
using POWTORZENIE.Models;

namespace POWTORZENIE.DTOs;

public class PrescriptionCreateDTO
{
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    [Required]
    public int IdDoctor { get; set; }
    [Required]
    public Patient Patient { get; set; } = null!;
    [Required]
    public virtual ICollection<MedicamentPrescriptionsCreateDTO> Medicaments { get; set; } = null!;
    
}