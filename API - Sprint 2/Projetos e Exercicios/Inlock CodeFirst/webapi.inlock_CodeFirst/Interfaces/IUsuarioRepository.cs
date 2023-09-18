using webapi.inlock_CodeFirst.Domains;

namespace webapi.inlock_CodeFirst.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuario(string email, string senha);

        void Cadastrar(Usuario usuario);
    }
}