using Health_Clinic_api.Context;
using Health_Clinic_api.Domains;
using Health_Clinic_api.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Cadastra uma nova Consulta na tabela do banco
        /// </summary>
        /// <param name="novaConsulta">Objeto do tipo Consulta</param>
        public void Cadastrar(Consulta novaConsulta)
        {
            if (novaConsulta != null)
            {
                _healthClinicContext.Consulta.Add(novaConsulta);
                _healthClinicContext.SaveChanges();
            }
        }

        /// <summary>
        /// Remove um Consulta por id
        /// </summary>
        /// <param name="id">Id do consulta</param>
        /// <returns>Objeto do tipo Consulta</returns>
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

        /// <summary>
        /// Altera/Atualiza um prontuário de uma Consulta por id
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <param name="prontuario">Objeto do tipo string para o prontuário</param>
        /// <returns></returns>
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

        /// <summary>
        /// Busca uma Consulta existente no banco por id
        /// </summary>
        /// <param name="id">Id da Consulta</param>
        /// <returns>Objeto do tipo Consulta</returns>
        public Consulta BuscarPorId(Guid id)
        {
            Consulta consultaBuscada = _healthClinicContext.Consulta
                .Include(c => c.Medico).Include(c => c.Medico.Clinica).Include(m => m.Medico.Especializacao)
                .Include(c => c.Comentario).Include(c => c.Comentario.Status).Include(c => c.Paciente).Include(c => c.Comentario.Paciente.Usuario)
                .FirstOrDefault(c => c.IdConsulta == id)!;
            if (consultaBuscada != null)
            {
                return consultaBuscada;
            }
            return null!;
        }
    }
}
