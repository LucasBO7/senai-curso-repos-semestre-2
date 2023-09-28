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

        /// <summary>
        /// Cadastra um novo médico na tabela do banco
        /// </summary>
        /// <param name="novoMedico">Objeto do tipo Medico</param>
        public void Cadastrar(Medico novoMedico)
        {
            if (novoMedico != null)
            {
                _healthClinicContext.Medico.Add(novoMedico);
                _healthClinicContext.SaveChanges();
            }
        }

        /// <summary>
        /// Busca todos os médicos da tabela do banco
        /// </summary>
        /// <returns>Lista de objetos do tipo Medico</returns>
        public List<Medico> BuscarTodos()
        {
            List<Medico> medicos = _healthClinicContext.Medico.ToList();

            if (medicos != null)
            {
                return medicos;
            }
            return null!;
        }

    }
}
