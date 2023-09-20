using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domain
{
    public class TiposUsuarioDomain
    {
        public int IdTiposUsuarioDomain { get; set; }

        [Required]
        public string? Titulo { get; set; }
    }
}
