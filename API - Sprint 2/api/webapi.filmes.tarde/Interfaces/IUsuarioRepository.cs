using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo Usuario
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Logar em um usuário existente
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        UsuarioDomain Login(string email, string senha);
    }
}
