using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using senai.inlock.webApi.Repository;

namespace senai.inlock.webApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")] // Especifica que essa API trabalha no formato de JSON
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository;

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<JogoDomain> jogos = _jogoRepository.BuscarTodos();

                if (!jogos.Any())
                {
                    return BadRequest("Não há nenhum jogo salvo.");
                }
                return Ok(jogos);
            }
            catch (Exception erro)
            {
                return NotFound(erro.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);

                return Ok();
            }
            catch (Exception erro)
            {
                return Problem(erro.Message);
            }

        }
    }
}