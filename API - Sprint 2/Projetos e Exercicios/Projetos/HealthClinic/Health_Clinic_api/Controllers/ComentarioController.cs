using Health_Clinic_api.Domains;
using Health_Clinic_api.Interfaces;
using Health_Clinic_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Health_Clinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepository _comentarioRepository { get; set; }

        public ComentarioController()
        {
            _comentarioRepository = new ComentarioRepository();
        }


        /// <summary>
        /// Método que executa função Cadastrar da ComentarioRepository
        /// </summary>
        /// <param name="comentario">Objeto do tipo Clinica</param>
        /// <returns>Statuscode</returns>
        [HttpPost]
        public IActionResult Post(Comentario comentario)
        {
            try
            {
                _comentarioRepository.Adicionar(comentario);
                return Ok("Clínica cadastrada com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Método que executa função Editar da ComentarioRepository
        /// </summary>
        /// <param name="novaClinica">Objeto do tipo Clinica</param>
        /// <returns>Statuscode</returns>
        [HttpPut]
        public IActionResult Put(Guid idComentario, Comentario comentario)
        {
            try
            {
                Comentario comentarioBuscado = _comentarioRepository.Editar(idComentario, comentario);
                return comentarioBuscado != null ? Ok("Comentario inserido com sucesso!") : NotFound("Comentário não encontrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Método que executa função Remover da ComentarioRepository
        /// </summary>
        /// <param name="novaClinica">Objeto do tipo Clinica</param>
        /// <returns>Statuscode</returns>
        [HttpDelete]
        public IActionResult Delete(Guid idComentario)
        {
            try
            {
                Comentario comentarioBuscado = _comentarioRepository.Remover(idComentario);
                return comentarioBuscado != null ? Ok("Comentario removido com sucesso!") : NotFound("Comentário não encontrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
