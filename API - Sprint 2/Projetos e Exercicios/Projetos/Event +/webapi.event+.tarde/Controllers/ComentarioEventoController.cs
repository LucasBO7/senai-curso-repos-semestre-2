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
    public class ComentarioEventoController : ControllerBase
    {
        private IComentarioEvento _comentarioEventoRepository { get; set; }

        public ComentarioEventoController()
        {
            _comentarioEventoRepository = new ComentarioEventoRepository();
        }

        /// <summary>
        /// Cadastra um novo comentario de evento na tabela do banco
        /// </summary>
        /// <param name="comentarioEvento">Objeto do tipo ComentarioEvento</param>
        /// <returns>StatusCode</returns>
        [HttpPost]
        public IActionResult Post(ComentarioEvento comentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(comentarioEvento);
                return Ok("Comentário registrado com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um ComentarioEvento na tabela do banco
        /// </summary>
        /// <param name="id">Id do ComentarioEvento</param>
        /// <returns>Statuscode</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = _comentarioEventoRepository.Deletar(id);

                if (comentarioEventoBuscado != null)
                    return Ok("Comentário deletado com sucesso!");
                return NotFound("Comentário inserido não encontrado! Verifique os dados inseridos!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um ComentarioEvento na tabela do banco
        /// </summary>
        /// <param name="id">Id do Evento</param>
        /// <param name="comentarioEvento">Objeto do tipo Evento</param>
        /// <returns>Statuscode</returns>
        [HttpPut]
        public IActionResult Put(Guid id, ComentarioEvento comentarioEvento)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = _comentarioEventoRepository.Atualizar(id, comentarioEvento);

                if (comentarioEventoBuscado != null)
                {
                    return Ok("Comentário alterado com sucesso!");
                }
                return NotFound("Comentário inserido não encontrado! Verifique os dados inseridos!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um ComentarioEvento pelo id
        /// </summary>
        /// <param name="id">Id do ComentarioEvento</param>
        /// <returns>Statuscode com/sem Objeto do tipo ComentarioEvento</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = _comentarioEventoRepository.BuscarPorId(id);

                if (comentarioEventoBuscado != null)
                {
                    return Ok(comentarioEventoBuscado);
                }
                return NotFound("Comentário inserido não encontrado! Verifique os dados inseridos!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca lista de todos comentários de eventos salvos na tabela do banco
        /// </summary>
        /// <returns>Statuscode com/sem Objeto do tipo ComentarioEvento</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<ComentarioEvento> listaComentarioEventoBuscado = _comentarioEventoRepository.BuscarTodos();

                if (listaComentarioEventoBuscado != null)
                {
                    return Ok(listaComentarioEventoBuscado);
                }
                return NotFound("Nenhum comentário encontrado! Não há comentários salvos!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
