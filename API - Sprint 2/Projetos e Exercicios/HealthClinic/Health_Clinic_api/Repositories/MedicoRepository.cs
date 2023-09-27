using Health_Clinic_api.Context;
using Health_Clinic_api.Domains;
using Health_Clinic_api.Interfaces;

namespace Health_Clinic_api.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public MedicoRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Cadastrar(Medico novoMedico)
        {
            if (novoMedico != null)
            {
                _healthClinicContext.Medico.Add(novoMedico);
                _healthClinicContext.SaveChanges();
            }
        }
    }
}
