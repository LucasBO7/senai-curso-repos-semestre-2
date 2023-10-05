using Health_Clinic_api.Domains;
using Health_Clinic_api.Interfaces;
using Health_Clinic_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Health_Clinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Cadastra um novo médico
        /// </summary>
        /// <param name="novoMedico">Objeto do tipo Medico</param>
        /// <returns>Statuscode</returns>
        [HttpPost]
        //[Authorize("Administrador")]
        public IActionResult Post(Medico novoMedico)
        {
            try
            {
                _medicoRepository.Cadastrar(novoMedico);
                return Ok("Médico cadastrado com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca todos os médicos do banco
        /// </summary>
        /// <returns>Lista de objetos do tipo Medico e Statuscode</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Medico> medicos = _medicoRepository.BuscarTodos();
                if (medicos.Any())
                    return Ok(medicos);
                return NotFound("Nenhum médico existente!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca todas as consultas pelo Id do médico
        /// </summary>
        /// <param name="id">Id do médico</param>
        /// <returns>Lista de objetos do tipo Consulta e Statuscode</returns>
        [HttpGet("ConsultasDoMedico")]
        public IActionResult GetQueryByDoctorId(Guid id)
        {
            try
            {
                List<Consulta> consultas = _medicoRepository.BuscarConsultasPorMedico(id);
                if (consultas.Any())
                    return Ok(consultas);
                return NotFound("Nenhum médico existente!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Deleta um médico existente
        /// </summary>
        /// <param name="id">Id do médico</param>
        /// <returns>Statuscode</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Medico medicoDeletado = _medicoRepository.Remover(id);
                if (medicoDeletado != null)
                    return Ok("Médico removido com sucesso do sistema!");
                return NotFound("Nenhum médico encontrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}