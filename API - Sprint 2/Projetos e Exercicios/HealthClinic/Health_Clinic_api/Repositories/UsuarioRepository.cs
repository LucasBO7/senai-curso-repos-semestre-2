using Health_Clinic_api.Context;
using Health_Clinic_api.Domains;
using Health_Clinic_api.Interfaces;
using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Utils;

namespace Health_Clinic_api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public UsuarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto do tipo Usuario</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha!);
            _healthClinicContext.Usuario.Add(novoUsuario);
            _healthClinicContext.SaveChanges();
        }

        /// <summary>
        /// Busca um usuário por email e senha
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns></returns>
        public Usuario BuscaPorEmailESenha(string email, string senha)
        {
            Usuario usuarioBuscado = _healthClinicContext.Usuario.Include(m => m.TipoUsuario).FirstOrDefault(u => u.Email == email)!;

            if (usuarioBuscado != null)
            {
                bool senhaIgual = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                if (senhaIgual)
                {
                    usuarioBuscado.Senha = null;
                    return usuarioBuscado;
                }
            }
            return null!;
        }
    }
}