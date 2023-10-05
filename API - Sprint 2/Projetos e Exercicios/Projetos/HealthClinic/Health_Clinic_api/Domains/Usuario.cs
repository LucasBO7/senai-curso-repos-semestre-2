using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic_api.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O email é obrigatório!")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha é obrigatória!")]
        [StringLength(60, MinimumLength = 8, ErrorMessage = "A senha deve conter de 8 a 60 caracteres")]
        public string? Senha { get; set; }


        [Required(ErrorMessage = "O id do tipo de usuário é obrigatório!")]
        public Guid? IdDoTipoUsuario { get; set; }
        [ForeignKey(nameof(IdDoTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}