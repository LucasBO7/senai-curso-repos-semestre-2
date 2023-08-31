using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "A senha deve conter de 3 a 20 caracteres.")]
        public string? Senha { get; set; }


        public int IdPermissao { get; set; }
        // Referência para a classe PermissaoDomains
        public Permissao Permissao { get; set; }
    }
}
