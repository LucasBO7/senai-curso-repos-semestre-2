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

        /// <summary>
        /// Busca todos os pacientes na tabela do banco
        /// </summary>
        /// <returns>Lista de objetos do tipo Paciente</returns>
        public List<Paciente> BuscarTodos()
        {
            List<Paciente> pacientes = _healthClinicContext.Paciente.ToList();

            if (pacientes != null)
                return pacientes;
            return null!;
        }

        /// <summary>
        /// Busca todas as consultas atreladas à um id do paciente
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <returns>Lista de objetos do tipo Consulta</returns>
        public List<Consulta> BuscarConsultasPorPaciente(Guid id)
        {
            return _healthClinicContext.Consulta.Where(c => c.IdPaciente == id).Select(c => new Consulta()
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
            // Parei aqui
        }
    }
}
