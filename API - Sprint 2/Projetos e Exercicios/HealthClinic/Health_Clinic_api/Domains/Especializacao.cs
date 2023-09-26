using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic_api.Domains
{
    [Table("Especializacao")]
    [Index(nameof(Nome), IsUnique = true)]
    public class Especializacao
    {
        [Key]
        public Guid IdEspecializacao { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "O nome da especialização é obrigatório!")]
        public string? Nome { get; set; }
    }
}