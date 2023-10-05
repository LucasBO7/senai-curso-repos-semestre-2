using Health_Clinic_api.Domains;
using Health_Clinic_api.Interfaces;
using Health_Clinic_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Health_Clinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto do tipo Paciente</param>
        /// <returns>Statuscode</returns>
        [HttpPost]
        public IActionResult Post(Paciente novoPaciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(novoPaciente);
                return Ok("Paciente cadastrado com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca todos os pacientes do banco
        /// </summary>
        /// <returns>Lista de objetos tipo Paciente e Statucode</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Paciente> pacientes = _pacienteRepository.BuscarTodos();
                if (pacientes.Any())
                    return Ok(pacientes);
                return NotFound("Nenhum paciente existente!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca todas as consultas pelo Id do paciente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lista de objetos do tipo Consulta e Statuscode</returns>
        [HttpGet("ConsultasDoPaciente")]
        public IActionResult GetQueryByPatientId(Guid id)
        {
            try
            {
                List<Consulta> consultas = _pacienteRepository.BuscarConsultasPorPaciente(id);
                if (consultas.Any())
                    return Ok(consultas);
                return NotFound("Não há nenhuma consulta agendada!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}