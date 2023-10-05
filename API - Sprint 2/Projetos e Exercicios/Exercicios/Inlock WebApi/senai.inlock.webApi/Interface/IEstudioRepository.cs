using senai.inlock.webApi.Domain;

namespace senai.inlock.webApi.Interface
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// Insere um novo Estudio na tabela de Estudios no banco de dados
        /// </summary>
        /// <param name="novoEstudio">Objeto do tipo Estudio</param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Busca um Estudio da tabela de Estudio no banco de dados
        /// </summary>
        /// <returns>Objeto do tipo Estudio</returns>
        List<EstudioDomain> BuscarPorId();

        /// <summary>
        /// Busca uma lista de Objetos do tipo Estudio da tabela de Estudio
        /// </summary>
        /// <returns>Lista de objetos do tipo Estudio</returns>
        List<EstudioDomain> BuscarTodos();

        /// <summary>
        /// Deleta um Objeto do tipo Estudio da tabela de Estudio
        /// </summary>
        void Deletar();
    }
}