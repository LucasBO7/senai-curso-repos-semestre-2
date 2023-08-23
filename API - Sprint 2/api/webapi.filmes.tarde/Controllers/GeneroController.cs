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

    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instância do objeto _generoRepository para que haja referência aos métodos no repositório
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository(); // Guarda todo o conteúdo que há na Classe/Repositório GeneroRepository
        }

        /// <summary>
        /// Endpoint --> 
        /// Endpoint que acessa o método de listar os Generos
        /// </summary>
        /// <returns>Lista de Generos e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Cria uma lista para receber os generos
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                // retorna o status code 200 Ok e a lista de Generos no formato JSON
                return Ok(listaGeneros);
                // Forma 2:     return StatusCode(200, listaGeneros);

            }
            catch (Exception erro)
            {
                // Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        /*
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                // Cria um objeto para receber os genero
                GeneroDomain genero = _generoRepository.BuscarPorId(id);

                // Retorna o status code 200 Ok e o Genero no formato JSON
                return Ok(genero);
                // Forma 2:     return StatusCode(200, genero);
            }
            catch (Exception erro)
            {
                // Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }*/
    }
}