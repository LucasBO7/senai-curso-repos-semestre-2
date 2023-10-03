using Health_Clinic_api.Domains;

namespace Health_Clinic_api.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta novaConsulta);
        Consulta RemoverPorId(Guid id);
        Consulta BuscarPorId(Guid id);
        Consulta AtualizarProntuario(Guid id, string prontuario);

        void AdicionarComentario(Guid idConsulta, Comentario novoComentario);
        Comentario RemoverComentario(Guid idConsulta);
        Comentario EditarComentario(Guid idConsulta, Comentario comentario);
    }
}