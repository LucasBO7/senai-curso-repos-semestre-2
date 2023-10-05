using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_CodeFirst.Domains
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email do usuário é obrigatório!")]
        [EmailAddress(ErrorMessage = "Endereço de email inválido")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 20 caracteres")]
        public string? Senha { get; set; }

        // Referência tabela TipoUsuario
        [Required(ErrorMessage = "Tipo do usuário obrigatório!")]
        public Guid IdTipoUsuario { get; set; }
        [ForeignKey(nameof(IdTipoUsuario))]
        public TiposUsuario? TipoUsuario { get; set; }
    }
}