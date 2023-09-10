using Microsoft.AspNetCore.Authorization;
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
        //[Authorize(Roles = "Comum, Administrador")]
        public IActionResult GetAll()
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

        [HttpPost("nome")]
        //[Authorize(Roles = "Comum, Administrador")]
        public IActionResult Get(JogoDomain jogoBuscado)
        {
            try
            {
                jogoBuscado = _jogoRepository.Buscar(jogoBuscado.Nome);

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

        [HttpPost]
        //[Authorize(Roles = "Administrador")]
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

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _jogoRepository.Deletar(id);

                return Ok("Jogo deletado com sucesso!");
            }
            catch (Exception erro)
            {
                return Problem(erro.Message);
            }
        }

        [HttpPut]
        //[Authorize(Roles = )]
        public IActionResult PutIdByUrl(int id, JogoDomain jogo)
        {
            try
            {
                _jogoRepository.AtualizarIdUrl(id, jogo);

                if (jogo == null)
                    return NotFound("O Jogo não foi encontrado!");

                return Ok("Jogo alterado com sucesso!");
            }
            catch (Exception erro)
            {
                return Problem(erro.Message);
            }
        }
    }
}