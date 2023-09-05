using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    /// <summary>
    /// Define que a rota de uma requisição será no seguinte formato:
    /// dominio/api/nomeController
    /// Exemplo: http://localhost:5000/api/Genero
    /// </summary>
    [Route("api/[controller]")]

    /// <summary>
    /// Define que é um controlador de API
    /// </summary>
    [ApiController]

    /// <summary>
    /// Define que o tipo de resposta da API é JSON
    /// </summary>
    [Produces("application/json")] // Especifica que essa API trabalha no formato de JSON

    public class FilmeController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }

        /// <summary>
        /// Instância do objeto _filmeRepository para que haja referência aos métodos no repositório
        /// </summary>
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository(); // Guarda todo o conteúdo que há na Classe/Repositório GeneroRepository
        }

        /// <summary>
        /// Endpoint que acessa o método de listar os Filmes
        /// </summary>
        /// <returns>Lista de Filmes e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> filmes = _filmeRepository.ListarTodos();

                if (!filmes.Any())
                {
                    return Problem("Não há nenhum filme inserido!");
                }

                return Ok(filmes);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método de listar um filme pesquisado por id
        /// </summary>
        /// <param name="id">Id do filme (IdFilme)</param>
        /// <returns>Objeto Filme pesquisado e um status code</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado == null)
                {
                    return Problem("Não foi possível encontrar o filme buscado.");
                }

                return Ok(filmeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                // Verifica se o filme preenchido está vazio
                if (novoFilme == null)
                {
                    return Problem("Preencha as informações antes de realizar o cadastro!");
                }

                _filmeRepository.Cadastrar(novoFilme);

                return Ok(novoFilme);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, FilmeDomain filme)
        {
            try
            {
                if (filme != null)
                {
                    _filmeRepository.AtualizarIdUrl(id, filme);
                    return Ok();
                }
                return Problem("Você deve preencher os valores do filme!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        [HttpPut]
        public IActionResult PutByBody(FilmeDomain filme)
        {
            try
            {
                if (filme != null)
                {
                    _filmeRepository.AtualizarIdCorpo(filme);
                    return Ok();
                }
                return Problem("Você deve preencher os valores do filme!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
