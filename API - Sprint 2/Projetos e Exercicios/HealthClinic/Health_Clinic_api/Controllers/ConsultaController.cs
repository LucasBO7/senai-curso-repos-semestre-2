using Health_Clinic_api.Domains;
using Health_Clinic_api.Interfaces;
using Health_Clinic_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Health_Clinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            try
            {
                _consultaRepository.Cadastrar(novaConsulta);
                return Ok("Consulta criada com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Consulta consultaBuscada = _consultaRepository.BuscarPorId(id);
                return Ok(consultaBuscada);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Clinica clinica)
        {
            try
            {

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Clinica clinica)
        {
            try
            {

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
