using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IInstituicaoRepository
    {
        /// <summary>
        /// Método que realiza o cadastro de uma Insituicao
        /// </summary>
        /// <param name="instituicao">Objeto do tipo Instituicao</param>
        void Cadastrar(Instituicao instituicao);

        /// <summary>
        /// Método que deleta uma Instituicao
        /// </summary>
        /// <param name="id">Id da Instituicao</param>
        void Deletar(Guid id);

        /// <summary>
        /// Busca lista de todos objetos Instituicao
        /// </summary>
        /// <returns>Lista de objetos Insituicao</returns>
        List<Instituicao> BuscarTodos();

        /// <summary>
        /// Busca objeto Instituicao por id
        /// </summary>
        /// <param name="id">Id da instituicao</param>
        /// <returns>Lista de objetos Insituicao</returns>
        Instituicao BuscarPorId(Guid id);

        /// <summary>
        /// Atualiza um objeto Insituicao existenteS
        /// </summary>
        /// <param name="id">Id da instituicao</param>
        /// <param name="instituicao">Objeto do tipo Instituicao</param>
        void Atualizar(Guid id, Instituicao instituicao);
    }
}
