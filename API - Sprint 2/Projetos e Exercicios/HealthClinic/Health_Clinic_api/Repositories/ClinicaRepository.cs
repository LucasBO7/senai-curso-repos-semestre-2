using Health_Clinic_api.Context;
using Health_Clinic_api.Domains;
using Health_Clinic_api.Interfaces;

namespace Health_Clinic_api.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ClinicaRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        
        /// <summary>
        /// Cadastra uma Clinica na tabela no banco
        /// </summary>
        /// <param name="novaClinica">Objeto do tipo Clinica</param>
        public void Cadastrar(Clinica novaClinica)
        {
            if (novaClinica != null)
            {
                _healthClinicContext.Clinica.Add(novaClinica);
                _healthClinicContext.SaveChanges();
            }
        }
    }
}