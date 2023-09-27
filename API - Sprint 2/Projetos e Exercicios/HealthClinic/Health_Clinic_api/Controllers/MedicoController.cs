using Health_Clinic_api.Domains;
using Health_Clinic_api.Interfaces;
using Health_Clinic_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Health_Clinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _clinicaRepository { get; set; }

        public MedicoController()
        {
            _clinicaRepository = new MedicoRepository();
        }


        [HttpPost]
        public IActionResult Post(Medico novoMedico)
        {
            try
            {
                _clinicaRepository.Cadastrar(novoMedico);
                return Ok("Médico cadastrado com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
