﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(PresencaEvento))]
    public class PresencaEvento
    {
        [Key]
        public Guid IdPresencaEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A situação é obrigatória!")]
        public bool Situacao { get; set; }

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