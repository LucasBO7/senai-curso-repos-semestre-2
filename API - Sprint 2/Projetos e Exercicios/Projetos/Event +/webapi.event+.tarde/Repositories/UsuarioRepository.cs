using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Utils;

namespace webapi.event_.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        /// <summary>
        /// Busca Objeto Usuario no banco por meio de um email e senha inseridos. Comparando as senhas criptografadas (em hash)
        /// </summary>
        /// <param name="email">Email inserido</param>
        /// <param name="senha">Senha inserida</param>
        /// <returns></returns>
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            Usuario usuarioBuscado = _eventContext.Usuario.Include(u => u.TipoUsuario).FirstOrDefault(u => u.Email == email)!;

            if (usuarioBuscado != null)
            {
                bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                if (confere)
                {
                    usuarioBuscado.Senha = null;
                    return usuarioBuscado;
                }
            }

            return null!;

        }


        /// <summary>
        /// Busca Objeto Usuario no banco por meio de um id inserido
        /// </summary>
        /// <param name="id">Id do usuário inserido</param>
        /// <returns>Objeto do tipo Usuario</returns>
        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,

                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TipoUsuario!.Titulo
                        }
                    }
                ).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cadastra objeto do tipo Usuario no banco de dados. Gerando hash de criptografia da senha
        /// </summary>
        /// <param name="usuario">Objeto do tipo Usuario</param>
        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _eventContext.Add(usuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
