using Health_Clinic_api.Context;
using Health_Clinic_api.Domains;
using Health_Clinic_api.Interfaces;

namespace Health_Clinic_api.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ComentarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Adicionar(Comentario novoComentario)
        {
            if (novoComentario != null)
            {
                _healthClinicContext.Comentario.Add(novoComentario);
                _healthClinicContext.SaveChanges();
            }
        }

        public Comentario Editar(Guid idComentario, Comentario comentario)
        {
            Comentario comentarioBuscado = _healthClinicContext.Comentario.FirstOrDefault(c => c.IdComentario == idComentario)!;

            if (comentarioBuscado != null && comentario != null)
            {
                comentarioBuscado.Descricao = comentario.Descricao;
                comentarioBuscado.Status = comentario.Status;
                return comentarioBuscado;
            }
            return null!;
        }

        public Comentario Remover(Guid idComentario)
        {
            Comentario comentarioBuscado = _healthClinicContext.Comentario.FirstOrDefault(c => c.IdComentario == idComentario)!;

            if (comentarioBuscado != null)
            {
                _healthClinicContext.Comentario.Remove(comentarioBuscado);
                _healthClinicContext.SaveChanges();
                return comentarioBuscado;
            }
            return null!;
        }
    }
}