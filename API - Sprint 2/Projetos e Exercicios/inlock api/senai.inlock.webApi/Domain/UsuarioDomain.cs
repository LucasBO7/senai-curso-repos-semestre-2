using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domain
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Senha { get; set; }


        public int IdTipoUsuario { get; set; }
        public TiposUsuarioDomain TipoUsuario { get; set; }
    }
}
