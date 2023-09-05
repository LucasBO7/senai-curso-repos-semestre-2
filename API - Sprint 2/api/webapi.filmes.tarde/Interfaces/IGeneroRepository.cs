using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //CRUD

        // TipoDeRetorno NomeMetodo(TipoParametro NomeParametro);


        /// <summary>
        /// Cadastrar um novo usuário
        /// </summary>
        /// <param name="novoGenero">Objeto que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);


        /// <summary>
        /// Retornar todos os Generos cadastrados
        /// </summary>
        /// <returns>Lista de objetos Generos</returns>
        List<GeneroDomain> ListarTodos();


        /// <summary>
        /// Buscar um objeto através do seu id
        /// </summary>
        /// <param name="id">Id do objeto que será buscado</param>
        /// <returns>Objeto que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);


        /// <summary>
        /// Atualizar um Genero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto com as novas informações</param>
        void AtualizarIdCorpo(GeneroDomain genero);


        /// <summary>
        /// Atualizar um Genero existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado</param>
        /// <param name="genero">Objeto com as novas informações</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);


        /// <summary>
        /// Deletar um Genero existente
        /// </summary>
        /// <param name="id">Id do objeto a ser deletado</param>
        void Deletar(int id);
    }
}
