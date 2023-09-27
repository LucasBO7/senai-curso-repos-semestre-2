using Health_Clinic_api.Context;
using Health_Clinic_api.Domains;
using Health_Clinic_api.Interfaces;

namespace Health_Clinic_api.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public PacienteRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        /// <summary>
        /// Cadastra um novo Paciente na tabela do banco
        /// </summary>
        /// <param name="novoPaciente">Objeto do tipo Paciente</param>
        public void Cadastrar(Paciente novoPaciente)
        {
            if (novoPaciente != null)
            {
                _healthClinicContext.Paciente.Add(novoPaciente);
                _healthClinicContext.SaveChanges();
            }
        }
    }
}
