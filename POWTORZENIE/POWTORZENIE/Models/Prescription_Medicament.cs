using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POWTORZENIE.Models;

[Table("Prescription_Medicament")]
[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public class Prescription_Medicament
{
    [Column("Medicament_Id")] 
    public int IdMedicament { get; set; }
    [Column("Prescription_Id")] 
    public int IdPrescription { get; set; }
    public int Dose { get; set; }
    [MaxLength(100)] public string Details { get; set; } = null!;
    
    [ForeignKey(nameof(IdMedicament))]
    public virtual Medicament Medicament { get; set; } = null!;
    
    [ForeignKey(nameof(IdPrescription))]
    public virtual Prescription Prescription { get; set; } = null!;
}