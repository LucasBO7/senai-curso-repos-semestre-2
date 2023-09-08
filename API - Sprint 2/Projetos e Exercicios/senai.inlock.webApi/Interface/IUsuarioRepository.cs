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
        UsuarioDomain Login(UsuarioDomain usuario);
    }
}
