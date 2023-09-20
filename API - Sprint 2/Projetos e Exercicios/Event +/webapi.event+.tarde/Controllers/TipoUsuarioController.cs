using Microsoft.AspNetCore.Authorization;
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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Cadastra um nobo tipoUsuario na tabela TipoUsuario do banco de dados
        /// </summary>
        /// <param name="tipoUsuario">Objeto do tipo TipoUsuario</param>
        /// <returns>Statuscode</returns>
        [HttpPost]
        [Authorize("Administrador")]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);
                return Ok("TipoUsuario deletado com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<TipoUsuario> listaTiposUsuario = _tipoUsuarioRepository.Listar();

                if (listaTiposUsuario != null)
                {
                    return Ok(listaTiposUsuario);
                }
                return NotFound("Não foi encontrado nenhum TipoUsuario!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
