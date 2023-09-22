using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IEventoRepository
    {
        /// <summary>
        /// Método que realiza o cadastro de uma Evento
        /// </summary>
        /// <param name="evento">Objeto do tipo Evento</param>
        void Cadastrar(Evento evento);

        /// <summary>
        /// Método que deleta uma Evento
        /// </summary>
        /// <param name="id">Id da Evento</param>
        /// <returns>Objeto tipo Evento</returns>
        Evento Deletar(Guid id);

        /// <summary>
        /// Busca lista de todos objetos Evento
        /// </summary>
        /// <returns>Lista de objetos Evento</returns>
        List<Evento> BuscarTodos();

        /// <summary>
        /// Busca objeto Evento por id
        /// </summary>
        /// <param name="id">Id da Evento</param>
        /// <returns>Lista de objetos Evento</returns>
        Evento BuscarPorId(Guid id);

        /// <summary>
        /// Atualiza um objeto Evento existenteS
        /// </summary>
        /// <param name="id">Id da Evento</param>
        /// <param name="evento">Objeto do tipo Evento</param>
        /// <returns>Objeto tipo Evento</returns>
        Evento Atualizar(Guid id, Evento evento);
    }
}
