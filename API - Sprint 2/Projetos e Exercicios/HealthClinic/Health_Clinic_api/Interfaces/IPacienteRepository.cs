using Health_Clinic_api.Domains;

namespace Health_Clinic_api.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente novoPaciente);
        List<Paciente> BuscarTodos();
        List<Consulta> BuscarConsultasPorPaciente(Guid id);
    }
}
