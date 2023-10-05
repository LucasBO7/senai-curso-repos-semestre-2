using Health_Clinic_api.Context;
using Health_Clinic_api.Domains;
using Health_Clinic_api.Interfaces;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        /// <summary>
        /// Busca as consultas cuja as quais o médico está relacionado
        /// </summary>
        /// <param name="id">Id do médico</param>
        /// <returns>Lista de objetos do tipo Consulta</returns>
        public List<Consulta> BuscarConsultasPorMedico(Guid id)
        {
            return _healthClinicContext.Consulta.Where(m => m.IdMedico == id).Select(c => new Consulta()
            {
                IdConsulta = c.IdPaciente,
                Data = c.Data,
                Prontuario = c.Prontuario,
                Medico = new()
                {
                    IdMedico = c.IdMedico,
                    CRM = c.Medico.CRM,
                    NumeroCelular = c.Medico.NumeroCelular,
                    Especializacao = new()
                    {
                        IdEspecializacao = c.Medico.Especializacao.IdEspecializacao,
                        Nome = c.Medico.Especializacao.Nome
                    },
                    Usuario = new()
                    {
                        IdUsuario = c.Medico.Usuario.IdUsuario,
                        Nome = c.Medico.Usuario.Nome,
                        Email = c.Medico.Usuario.Email
                    },
                    Clinica = new()
                    {
                        IdClinica = c.Medico.Clinica.IdClinica,
                        NomeFantasia = c.Medico.Clinica.NomeFantasia,
                        Endereco = c.Medico.Clinica.Endereco,
                        HorarioAbertura = c.Medico.Clinica.HorarioAbertura,
                        HorarioFechamento = c.Medico.Clinica.HorarioFechamento
                    }
                }
            }).ToList();
        }

        /// <summary>
        /// Remove um médico existente
        /// </summary>
        /// <param name="id">Id do médico</param>
        /// <returns>Objeto do tipo Medico</returns>
        public Medico Remover(Guid id)
        {
            Medico medicoBuscado = _healthClinicContext.Medico.FirstOrDefault(m => m.IdMedico == id)!;
            if (medicoBuscado != null)
            {
                _healthClinicContext.Medico.Remove(medicoBuscado);
                _healthClinicContext.SaveChanges();
                return medicoBuscado;
            }
            return null!;
        }
    }
}
