using Health_Clinic_api.Context;
using Health_Clinic_api.Domains;
using Health_Clinic_api.Interfaces;
using System.Runtime.CompilerServices;

namespace Health_Clinic_api.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ConsultaRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            if (novaConsulta != null)
            {
                _healthClinicContext.Consulta.Add(novaConsulta);
                _healthClinicContext.SaveChanges();
            }
        }

        public Consulta RemoverPorId(Guid id)
        {
            Consulta consultaBuscada = _healthClinicContext.Consulta.FirstOrDefault(c => c.IdConsulta == id)!;

            if (consultaBuscada != null)
            {
                _healthClinicContext.Consulta.Remove(consultaBuscada);
                _healthClinicContext.SaveChanges();
                return consultaBuscada;
            }
            return null!;
        }

        public Consulta AtualizarProntuario(Guid id, string prontuario)
        {
            Consulta consultaBuscada = _healthClinicContext.Consulta.FirstOrDefault(c => c.IdConsulta == id)!;

            if (consultaBuscada != null)
            {
                consultaBuscada.Prontuario = prontuario;
                _healthClinicContext.Update(consultaBuscada);
                _healthClinicContext.SaveChanges();
                return consultaBuscada;
            }
            return null!;
        }

        public Consulta BuscarPorId(Guid id)
        {
            Consulta consultaBuscada = _healthClinicContext.Consulta.FirstOrDefault(c => c.IdConsulta == id)!;
            if (consultaBuscada != null)
            {
                return consultaBuscada;
            }
            return null!;
        }
    }
}
