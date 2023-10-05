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
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository { get; set; }

        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        /// <summary>
        /// Cadastra um TipoEveto na tabela no banco
        /// </summary>
        /// <param name="tipoEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(tipoEvento);
                return Ok("Tipo de evento cadastrado com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um Tipo de evento por id
        /// </summary>
        /// <param name="id">Id do TipoEvento</param>
        /// <returns>StatusCode</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoEventoRepository.Deletar(id);
                return Ok("O Tipo de evento foi deletado com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um Tipo de evento por id
        /// </summary>
        /// <param name="id">Id do Tipo de evento</param>
        /// <param name="tipoEvento">Objeto do tipo TipoEvento</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Atualizar(id, tipoEvento);
                return Ok("Tipo de evento atualizado com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca todos os TipoEvento salvos
        /// </summary>
        /// <returns>Lista de TipoEvento ou StatusCode</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<TipoEvento> tiposEvento = _tipoEventoRepository.BuscarTodos();
                if (tiposEvento != null)
                    return Ok(tiposEvento);
                return NotFound("Nenhum tipo de evento encontrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um TipoEvento por id
        /// </summary>
        /// <param name="id">Id do TipoEvento</param>
        /// <returns>TipoEvento ou StatusCode</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoEvento tipoEvento = _tipoEventoRepository.BuscarPorId(id);
                if (tipoEvento != null)
                    return Ok(tipoEvento);
                return NotFound("Tipo de evento não encontrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
