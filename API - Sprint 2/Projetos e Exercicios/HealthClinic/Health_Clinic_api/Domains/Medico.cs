using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic_api.Domains
{
    [Table("Medico")]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();


        [Required(ErrorMessage = "O id da clínica é obrigatório!")]
        public Guid IdClinica { get; set; }
        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }


        [Required(ErrorMessage = "O id da especialização é obrigatória!")]
        public Guid IdEspecializacao { get; set; }
        [ForeignKey(nameof(IdEspecializacao))]
        public Especializacao? Especializacao { get; set; }


        [Required(ErrorMessage = "O id do usuário é obrigatório")]
        public Guid IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }


        [Column(TypeName = "VARCHAR(13)")]
        [Required(ErrorMessage = "O crm é obrigatório!")]
        public string? CRM { get; set; }

        [Column(TypeName = "VARCHAR(22)")]
        [Required(ErrorMessage = "O número do celular é obrigatório!")]
        public string? NumeroCelular { get; set; }
    }
}