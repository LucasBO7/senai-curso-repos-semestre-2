using senai.inlock.webApi.Domain;

namespace senai.inlock.webApi.Interface
{
    public interface IJogoRepository
    {
        /// <summary>
        /// Realiza um cadastro de um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto com os dados inseridos para cadastro do novo jogo</param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Realiza a busca de todos os Jogos do banco com seus respectivos Estudios
        /// </summary>
        /// <returns>Lista de objetos do tipo JogoDomain</returns>
        List<JogoDomain> BuscarTodos();
    }
}