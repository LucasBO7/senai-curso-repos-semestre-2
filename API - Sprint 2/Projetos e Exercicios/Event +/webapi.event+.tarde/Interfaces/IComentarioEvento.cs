using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IComentarioEvento
    {
        /// <summary>
        /// Método que realiza o cadastro de um comentario de um evento
        /// </summary>
        /// <param name="comentarioEvento">Objeto do tipo ComentarioEvento</param>
        void Cadastrar(ComentarioEvento comentarioEvento);

        /// <summary>
        /// Método que deleta um comentário de um evento
        /// </summary>
        /// <param name="id">Id do ComentarioEvento</param>
        /// <returns>Objeto tipo ComentarioEvento</returns>
        ComentarioEvento Deletar(Guid id);

        /// <summary>
        /// Busca lista de todos objetos ComentarioEvento
        /// </summary>
        /// <returns>Lista de objetos ComentarioEvento</returns>
        List<ComentarioEvento> BuscarTodos();

        /// <summary>
        /// Busca objeto ComentarioEvento por id
        /// </summary>
        /// <param name="id">Id do ComentarioEvento</param>
        /// <returns>Lista de objetos ComentarioEvento</returns>
        ComentarioEvento BuscarPorId(Guid id);

        /// <summary>
        /// Atualiza um objeto ComentarioEvento existente
        /// </summary>
        /// <param name="id">Id do ComentarioEvento</param>
        /// <param name="comentarioEvento">Objeto do tipo ComentarioEvento</param>
        /// <returns>Objeto do tipo ComentarioEvento</returns>
        ComentarioEvento Atualizar(Guid id, ComentarioEvento comentarioEvento);
    }
}
