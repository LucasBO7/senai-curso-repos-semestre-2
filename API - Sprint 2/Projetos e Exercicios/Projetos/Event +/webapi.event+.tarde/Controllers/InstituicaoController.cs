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
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository { get; set; }

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Busca todas as Instituições da tabela no Banco
        /// </summary>
        /// <returns>Lista de Instituições e StatusCode</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Instituicao> listaInstituicoes = _instituicaoRepository.BuscarTodos();

                if (listaInstituicoes != null)
                    return Ok(listaInstituicoes);

                return NotFound("Nenhuma instituição encontrada!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Cadastra uma nova Instituição na tabela no banco
        /// </summary>
        /// <param name="instituicao">Objeto do tipo Instituicao</param>
        /// <returns>StatusCode</returns>
        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca Instituicao por meio do id especificado
        /// </summary>
        /// <param name="id">Id da instituicao</param>
        /// <returns>Objeto do tipo Instituicao ou StatusCode</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);
                return Ok(instituicaoBuscada);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta uma Instituicao por meio de um id especificado
        /// </summary>
        /// <param name="id">Id da Instituicao</param>
        /// <returns>StatusCode</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                if (id != null)
                {
                    _instituicaoRepository.Deletar(id);
                    return Ok("Instituição removida com sucesso!");
                }
                return NotFound("Instituição inserida não encontrada! Verifique os dados inseridos!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza uma Instituicao na tabela do banco
        /// </summary>
        /// <param name="id">Id da Instituicao</param>
        /// <param name="instituicao">Objeto do tipo Id</param>
        /// <returns>StatusCode</returns>
        [HttpPut]
        public IActionResult Put(Guid id, Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Atualizar(id, instituicao);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}