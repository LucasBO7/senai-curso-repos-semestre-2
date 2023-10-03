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

        /// <summary>
        /// Insere um Comentário na área de feedbacks de uma consulta identificada por Id
        /// </summary>
        /// <param name="idConsulta">Id da consulta</param>
        /// <param name="novoComentario">Objeto do tipo Comentario</param>
        public void AdicionarComentario(Guid idConsulta, Comentario novoComentario)
        {
            Consulta consultaBuscada = _healthClinicContext.Consulta.FirstOrDefault(c => c.IdConsulta == idConsulta)!;

            // Se houver uma consulta com o id informado e o comentário tiver um valor
            if (consultaBuscada != null && novoComentario != null)
            {
                // Insere o comentário na tabela de Feedbacks
                _healthClinicContext.Comentario.Add(novoComentario);

                // Insere o comentário no IdComentario da tabela Consulta
                consultaBuscada.IdComentario = novoComentario.IdComentario;
                _healthClinicContext.Update(consultaBuscada);
                _healthClinicContext.SaveChanges();
            }
        }

        /// <summary>
        /// Remove um comentário com base em uma consulta
        /// </summary>
        /// <param name="idConsulta">Id da Consulta</param>
        /// <returns>Objeto do tipo Comentario</returns>
        public Comentario RemoverComentario(Guid idConsulta)
        {
            Consulta consulta = _healthClinicContext.Consulta.Include(f => f.Comentario).FirstOrDefault(c => c.IdConsulta == idConsulta)!;

            if (consulta != null)
            {
                _healthClinicContext.Comentario.Remove(consulta.Comentario!);
                return consulta.Comentario!;
            }
            return null!;
        }

        /// <summary>
        /// Edita um comentário existente com base em uma consulta
        /// </summary>
        /// <param name="idConsulta">Id da Consulta</param>
        /// <param name="comentario">Objeto do tipo Comentario</param>
        /// <returns></returns>
        public Comentario EditarComentario(Guid idConsulta, Comentario comentario)
        {
            Consulta consultaBuscada = _healthClinicContext.Consulta.FirstOrDefault(c => c.IdConsulta == idConsulta)!;

            if (consultaBuscada != null)
            {
                consultaBuscada.IdComentario = comentario.IdComentario;
                _healthClinicContext.Update(consultaBuscada);
                _healthClinicContext.SaveChanges();
                return consultaBuscada.Comentario!;
            }
            return null!;
        }
    }
}
