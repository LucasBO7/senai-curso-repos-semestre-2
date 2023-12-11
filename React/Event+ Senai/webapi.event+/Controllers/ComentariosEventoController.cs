using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using System.Text;
using webapi.event_.Domains;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosEventoController : ControllerBase
    {
        ComentariosEventoRepository comentario = new();

        // armazena dados da API externa (IA - Azure)
        private readonly ContentModeratorClient _contentModeratorClient;

        /// <summary>
        /// Construtor que recebe os dados necessários para o acesso ao serviço externo
        /// </summary>
        /// <param name="contentModeratorClient">objeto do tipo ContentModeratorClient</param>
        public ComentariosEventoController(ContentModeratorClient contentModeratorClient)
        {
            _contentModeratorClient = contentModeratorClient;
        }

        [HttpPost("CadastroIA")]
        public async Task<IActionResult> PostIA(ComentariosEvento comentarioEvento)
        {
            try
            {
                // se a descrição do comentário não for passado no objeto
                if (string.IsNullOrEmpty(comentarioEvento.Descricao))
                {
                    return BadRequest("O texto a ser analisado não pode ser vazio!");
                }

                // converte a string(descrição do comentário) em um MemoryStream
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(comentarioEvento.Descricao));

                // realiza a moderação do comentário(descrição do comentário)
                var moderationResult = await _contentModeratorClient.TextModeration
                    .ScreenTextAsync("text/plain", stream, "por", false, false, null, true);

                // se existir termos ofensivos
                if (moderationResult.Terms != null)
                {
                    // atribuir false para "Exibe"
                    comentarioEvento.Exibe = false;

                    // cadastra o comentário
                    comentario.Cadastrar(comentarioEvento);
                }
                else
                {
                    comentarioEvento.Exibe = true;
                    comentario.Cadastrar(comentarioEvento);
                }
                return Ok(comentarioEvento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(comentario.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("BuscarPorIdUsuario")]
        public IActionResult GetByUserId(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return Ok(comentario.BuscarPorIdUsuario(idUsuario, idEvento));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(ComentariosEvento novoComentario)
        {
            try
            {
                comentario.Cadastrar(novoComentario);
                return StatusCode(201, novoComentario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                comentario.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
