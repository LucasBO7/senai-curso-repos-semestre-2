using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic_api.Domains
{
    [Table("Paciente")]
    [Index(nameof(CPF), nameof(RG), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();


        [Required(ErrorMessage = "O id do usuário é obrigatório!")]
        public Guid? IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }


        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "O cpf é obrigatório!")]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR(7)")]
        [Required(ErrorMessage = "O rg é obrigatório!")]
        public string? RG { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de nascimento é obrigatória!")]
        public DateTime DataNascimento { get; set; }
    }
}