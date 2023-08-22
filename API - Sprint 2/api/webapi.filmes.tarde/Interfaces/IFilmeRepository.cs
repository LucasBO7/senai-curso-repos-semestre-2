using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo Filme Repository
    /// </summary>
    public interface IFilmeRepository
    {
        // CRUD

        /// <summary>
        /// Cadastrar um novo filme
        /// </summary>
        /// <param name="filme">Objeto que será cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);


        /// <summary>
        /// Retornar todos os Filmes cadastrados
        /// </summary>
        /// <returns>Lista de objetos Filme</returns>
        List<FilmeDomain> ListarTodos();


        /// <summary>
        /// Buscar um objeto através do seu id
        /// </summary>
        /// <param name="id">Objeto que foi buscado</param>
        FilmeDomain BuscarPorId(int id);


        /// <summary>
        /// Atualizar um Filme existente passando um id pelo corpo da requisição
        /// </summary>
        /// <param name="filme"></param>
        void Atualizar(FilmeDomain filme);


        /// <summary>
        /// Atualizar um Filme existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado</param>
        /// <param name="filme">Objeto com as novas informações</param>
        void AtualizarIdUrl(int id, FilmeDomain filme);



        /// <summary>
        /// Deletar um Filme existente
        /// </summary>
        /// <param name="id">Id do objeto a ser deletado</param>
        void Deletar(int id);
    }
}
