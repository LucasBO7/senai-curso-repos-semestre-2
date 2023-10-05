using Health_Clinic_api.Domains;

namespace Health_Clinic_api.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);
        List<Medico> BuscarTodos();
        List<Consulta> BuscarConsultasPorMedico(Guid id);
        Medico Remover(Guid id);
    }
}