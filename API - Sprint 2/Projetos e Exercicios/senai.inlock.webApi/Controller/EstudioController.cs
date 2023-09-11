using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using senai.inlock.webApi.Repository;
using System.Data;

namespace senai.inlock.webApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")] // Especifica que essa API trabalha no formato de JSON
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository;

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet()]
        //[Authorize(Roles = "Comum, Administrador")]
        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> jogoBuscado = _estudioRepository.BuscarPorId();

                if (jogoBuscado == null)
                {
                    return BadRequest("Não há nenhum jogo salvo.");
                }
                return Ok(jogoBuscado);
            }
            catch (Exception erro)
            {
                return NotFound(erro.Message);
            }
        }
    }
}
