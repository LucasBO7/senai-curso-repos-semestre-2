using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_CodeFirst.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do jogo obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição do jogo obrigatória!")]
        public string? Descricao { get; set; }


        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de lançamento do jogo obrigatória!")]
        public DateTime DataLancamento { get; set; }
        
        [Column(TypeName = "DECIMAL(4, 2)")]
        [Required(ErrorMessage = "Preço do jogo obrigatório!")]
        public decimal Preco { get; set; }

        // referência p/ tabela Estudio - FK
        public Guid IdEstudio { get; set; }

        // Indica que este tipo é referenciado por meio do IdEstudio de Jogo
        [ForeignKey(nameof(Jogo.IdEstudio))]
        public Estudio? Estudio { get; set; }

    }
}