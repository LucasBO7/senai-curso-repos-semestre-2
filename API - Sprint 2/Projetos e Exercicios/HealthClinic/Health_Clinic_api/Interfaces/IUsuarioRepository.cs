using Health_Clinic_api.Domains;

namespace Health_Clinic_api.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);
        Usuario BuscaPorEmailESenha(string email, string senha);
    }
}
