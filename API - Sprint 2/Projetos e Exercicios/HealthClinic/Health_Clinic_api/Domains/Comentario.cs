using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic_api.Domains
{
    [Table("Comentario")]
    public class Comentario
    {
        [Key]
        public Guid IdFeedback { get; set; } = Guid.NewGuid();


        [Required(ErrorMessage = "O id do paciente é obrigatório!")]
        public Guid IdPaciente { get; set; }
        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descricao é obrigatória!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "O status é obrigatória!")]
        [DefaultValue(0)]
        public bool Status { get; set; }
    }
}
