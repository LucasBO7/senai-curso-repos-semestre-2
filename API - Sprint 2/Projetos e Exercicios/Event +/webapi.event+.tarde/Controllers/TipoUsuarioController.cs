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
        /// Cadastra um novo tipoUsuario na tabela TipoUsuario do banco de dados
        /// </summary>
        /// <param name="tipoUsuario">Objeto do tipo TipoUsuario</param>
        /// <returns>Statuscode</returns>
        [HttpPost]
        //[Authorize("Administrador")]
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

        /// <summary>
        /// Deleta um id com base no usuário
        /// </summary>
        /// <param name="id">Id inserido</param>
        /// <returns>Statuscode</returns>
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

        /// <summary>
        /// Busca todos os TipoUsuarios
        /// </summary>
        /// <returns>Lista de TipoUsuarios</returns>
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

        /// <summary>
        /// Busca um TipoUsuario por id
        /// </summary>
        /// <param name="id">Id inserido</param>
        /// <returns>Objeto TipoUsuario ou Statuscode</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuario = _tipoUsuarioRepository.BuscarPorId(id);

                if (tipoUsuario != null)
                    return Ok(tipoUsuario);
                return NotFound("TipoUsuario não encontrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um objeto TipoUsuario buscado por Id
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <param name="tipoUsuario">Objeto TipoUsuario</param>
        /// <returns>StatusCode</returns>
        [HttpPut]
        public IActionResult Put(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuario);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
