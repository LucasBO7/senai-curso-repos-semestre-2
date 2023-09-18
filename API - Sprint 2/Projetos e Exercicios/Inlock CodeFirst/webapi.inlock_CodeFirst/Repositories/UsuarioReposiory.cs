using webapi.inlock_CodeFirst.Contexts;
using webapi.inlock_CodeFirst.Domains;
using webapi.inlock_CodeFirst.Interfaces;
using webapi.inlock_CodeFirst.Utils;

namespace webapi.inlock_CodeFirst.Repositories
{
    public class UsuarioReposiory : IUsuarioRepository
    {
        // O objeto UsuarioRepository passa a ter informações do context. Porém, de forma segura, pois ele poderá somente ler/dar get no conteúdo da context
        private readonly InLockContext context;
        public UsuarioReposiory()
        {
            context = new InLockContext();
        }


        public Usuario BuscarUsuario(string email, string senha)
        {
            try
            {
                var usuarioBuscado = context.Usuario.FirstOrDefault(u => u.Email == email);

                if (usuarioBuscado != null)
                {
                    bool mesmaSenha = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (mesmaSenha)
                    {
                        return usuarioBuscado;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha);

                context.Usuario.Add(usuario);

                context.SaveChanges();
            }
            catch (Exception erro)
            {
                throw;
            }
        }
    }
}