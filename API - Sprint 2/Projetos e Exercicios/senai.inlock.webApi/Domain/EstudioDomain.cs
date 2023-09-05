using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domain
{
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Nome { get; set; }
    }
}
