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
    public class PresencaEventoController : ControllerBase
    {
        private IPresencaEventoRepository _presencaEventoRepository { get; set; }

        public PresencaEventoController()
        {
            _presencaEventoRepository = new PresencaEventoRepository();
        }

        /// <summary>
        /// Cadastra uma presença em um Evento e Instituicao especificado por id
        /// </summary>
        /// <param name="presencaEvento">Objeto do tipo PresencaEvento</param>
        /// <returns>Statuscode</returns>
        [HttpPost]
        public IActionResult Post(PresencaEvento presencaEvento)
        {
            try
            {
                _presencaEventoRepository.Cadastrar(presencaEvento);
                return Ok("Presença registrada com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca uma presença de evento na tabela do banco por ids
        /// </summary>
        /// <param name="id">Id da PresencaEvento</param>
        /// <returns>Objeto do tipo PresencaEvento e Statuscode</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                PresencaEvento presencaEvento = _presencaEventoRepository.BuscarPorId(id);
                return Ok(presencaEvento);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca todas as presenças em eventos na tabela do banco
        /// </summary>
        /// <returns>Lista de objetos do tipo PresencaEvento e Statuscode</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<PresencaEvento> listaPresencasEventos = _presencaEventoRepository.BuscarTodos();
                if (listaPresencasEventos != null)
                    return Ok(listaPresencasEventos);
                return NotFound("Nenhuma presença em eventos encontrada!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza uma PresencaEvento na tabela do banco
        /// </summary>
        /// <param name="id">Id da PresencaEvento</param>
        /// <param name="presencaEvento">Objeto do tipo PresencaEvento</param>
        /// <returns>Statuscode</returns>
        [HttpPut]
        public IActionResult Put(Guid id, PresencaEvento presencaEvento)
        {
            try
            {
                PresencaEvento presencaEventoBuscado = _presencaEventoRepository.Atualizar(id, presencaEvento);
                if (presencaEventoBuscado != null)
                    return Ok("Presença alterada com sucesso!");
                return NotFound("Nenhuma presença em evento encontrada!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta uma PresencaEvento na tabela do banco
        /// </summary>
        /// <param name="id">Id da PresencaEvento</param>
        /// <returns>Statuscode</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                PresencaEvento presencaEventoDeletada = _presencaEventoRepository.Deletar(id);

                if (presencaEventoDeletada != null)
                    return Ok("Presença no evento retirada com sucesso!");
                return NotFound("Nenhuma presença neste evento encontrada! Verifique os dados inseridos!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}