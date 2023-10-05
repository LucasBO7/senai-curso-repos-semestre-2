using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(ComentarioEvento))]
    public class ComentarioEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição é obrigatória!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Informação sobre exibição obrigatória!")]
        public bool Exibe { get; set; }

        // Referência tabela Usuario = FK
        [Required(ErrorMessage = "O usuário é obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        // Referência tabela Evento = FK
        [Required(ErrorMessage = "O evento é obrigatório!")]
        public Guid IdEvento { get; set; }
        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
