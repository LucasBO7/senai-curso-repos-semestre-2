using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_CodeFirst.Domains
{
    [Table("Estudio")]
    public class Estudio
    {
        [Key] // Indica que é chave primária
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        // Indica que é coluna e o tipo da coluna
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome obrigatório!")]
        public string? Nome { get; set; }

        public List<Jogo> Jogos { get; set; } = new List<Jogo>();
    }
}