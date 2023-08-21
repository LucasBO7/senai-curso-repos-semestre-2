using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Representa a entidade(tabela) Filme
    /// </summary>
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "O título do filme é obrigatório!")]
        public string? Titulo { get; set; }


        public int IdGenero { get; set; }
        // Referência para a classe GeneroDomain
        public GeneroDomain? Genero { get; set; }
    }
}
