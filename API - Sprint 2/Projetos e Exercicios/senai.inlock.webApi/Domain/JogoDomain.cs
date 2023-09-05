using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domain
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Descricao { get; set; }

        [Required]
        public DateOnly DataLancamento { get; set; }

        [Required]
        public float Valor { get; set; }



        public int IdEstudio { get; set; }
        public EstudioDomain Estudio { get; set; }
    }
}