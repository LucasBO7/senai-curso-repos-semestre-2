using Health_Clinic_api.Domains;

namespace Health_Clinic_api.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica novaClinica);
    }
}