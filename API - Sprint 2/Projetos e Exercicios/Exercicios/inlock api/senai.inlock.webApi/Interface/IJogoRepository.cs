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

        /// <summary>
        /// Busca um Jogo do banco com seus respectivos Estudios
        /// </summary>
        /// <returns>Objeto do tipo Jogo</returns>
        JogoDomain Buscar(string nomeJogo);

        /// <summary>
        /// Deleta um Jogo do banco de dados
        /// </summary>
        /// <param name="jogoADeletar">Objeto do tipo Jogo</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um Jogo existente do banco de dados
        /// </summary>
        /// <param name="jogo"></param>
        void AtualizarIdUrl(int id, JogoDomain jogo);
    }
}