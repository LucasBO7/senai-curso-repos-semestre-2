using Health_Clinic_api.Domains;

namespace Health_Clinic_api.Interfaces
{
    public interface IComentarioRepository
    {
        void Adicionar(Comentario novoComentario);
        Comentario Remover(Guid idConsulta);
        Comentario Editar(Guid idComentario, Comentario comentario);
    }
}