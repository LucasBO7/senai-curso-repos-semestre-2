using senai.inlock.webApi.Domain;

namespace senai.inlock.webApi.Interface
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Realiza o login em um usuário existente
        /// </summary>
        /// <param name="usuario">Usuario passado para login (campos de Email e Senha)</param>
        /// <returns>Objeto do tipo Usuario</returns>
        UsuarioDomain Login(string email, string senha);

        /// <summary>
        /// Insere um novo usuário no banco de dados
        /// </summary>
        /// <param name="usuario">Objeto do tipo Usuario com os dados da nova inserção</param>
        void Cadastrar(UsuarioDomain usuario);

        /// <summary>
        /// Busca todos os objetos da tabela de Usuarios do banco
        /// </summary>
        /// <returns>Lista de objetos do tipo Usuario</returns>
        List<UsuarioDomain> BuscarTodos();

        /// <summary>
        /// Busca um usuário específico da tabela de Usuarios do banco
        /// </summary>
        /// <returns>Objeto do tipo Usuario</returns>
        UsuarioDomain Buscar(int id);

        /// <summary>
        /// Deleta um dos registros da tabela de Usuario
        /// </summary>
        /// <param name="usuarioADeletar">objeto do tipo Usuario com os dados para referência de deleção</param>
        void Deletar(int id);

        /// <summary>
        /// Atuaiza/Edita um Usuario existente da tabela de Usuarios do banco
        /// </summary>
        /// <param name="usuario">Objeto do tipo Usuario</param>
        void Atualizar(UsuarioDomain usuario);
    }
}
