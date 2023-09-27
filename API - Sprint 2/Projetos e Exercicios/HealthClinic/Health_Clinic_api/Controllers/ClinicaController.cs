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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Método que executa função Cadastrar da ClinicaRepository
        /// </summary>
        /// <param name="novaClinica">Objeto do tipo Clinica</param>
        /// <returns>Statuscode</returns>
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(novaClinica);
                return Ok("Clínica cadastrada com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}