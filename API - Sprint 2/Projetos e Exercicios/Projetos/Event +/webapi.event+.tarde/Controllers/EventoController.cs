using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        private IEventoRepository _eventoRepository { get; set; }

        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        /// <summary>
        /// Cadastra um novo Evento na tabela do banco
        /// </summary>
        /// <param name="novoEvento">Objeto do tipo Evento</param>
        /// <returns>StatusCode</returns>
        [HttpPost]
        public IActionResult Post(Evento novoEvento)
        {
            try
            {
                _eventoRepository.Cadastrar(novoEvento);
                return Ok("Evento cadastrado com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um Evento na tabela do banco
        /// </summary>
        /// <param name="id">Id do Evento</param>
        /// <returns>Statuscode</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.Deletar(id);

                if (eventoBuscado != null)
                    return Ok("Evento deletado com sucesso!");
                return NotFound("Evento inserido não encontrado! Verifique os dados inseridos!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um Evento na tabela do banco
        /// </summary>
        /// <param name="id">Id do Evento</param>
        /// <param name="evento">Objeto do tipo Evento</param>
        /// <returns>Statuscode</returns>
        [HttpPut]
        public IActionResult Put(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.Atualizar(id, evento);

                if (eventoBuscado != null)
                {
                    return Ok("Evento alterado com sucesso!");
                }
                return NotFound("Evento inserido não encontrado! Verifique os dados inseridos!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um Evento pelo id
        /// </summary>
        /// <param name="id">Id do Evento</param>
        /// <returns>Statuscode com/sem Objeto do tipo Evento</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

                if (eventoBuscado != null)
                {
                    return Ok(eventoBuscado);
                }
                return NotFound("Evento inserido não encontrado! Verifique os dados inseridos!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca lista de todos eventos salvos na tabela do banco
        /// </summary>
        /// <returns>Statuscode com/sem Objeto do tipo Evento</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Evento> listaEventos = _eventoRepository.BuscarTodos();

                if (listaEventos != null)
                {
                    return Ok(listaEventos);
                }
                return NotFound("Nenhum evento encontrado! Não há eventos salvos!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}