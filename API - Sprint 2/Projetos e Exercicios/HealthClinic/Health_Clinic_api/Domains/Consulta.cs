using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic_api.Domains
{
    [Table("Consulta")]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();


        [Required(ErrorMessage = "O id do médico é obrigatório!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }


        [Required(ErrorMessage = "O id do feedback é obrigatório!")]
        public Guid IdFeedback { get; set; }
        [ForeignKey(nameof(IdFeedback))]
        public Comentario? Comentario { get; set; }


        [Required(ErrorMessage = "O id do paciente é obrigatório!")]
        public Guid IdPaciente { get; set; }
        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data é obrigatória!")]
        public DateTime Data { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "O prontuário é obrigatório!")]
        public string? Prontuario { get; set; }
    }
}