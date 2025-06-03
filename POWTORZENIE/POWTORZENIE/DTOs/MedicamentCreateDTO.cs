using System.ComponentModel.DataAnnotations;

namespace POWTORZENIE.DTOs;

public class MedicamentCreateDTO
{
    [Required]
    public int IdMedicament { get; set; }
    [MaxLength(100)] 
    [Required]
    public string Name { get; set; } = null!;
    [MaxLength(100)] 
    [Required]
    public string Description { get; set; } = null!;
    [MaxLength(100)] 
    [Required]
    public string Type { get; set; } = null!;
}