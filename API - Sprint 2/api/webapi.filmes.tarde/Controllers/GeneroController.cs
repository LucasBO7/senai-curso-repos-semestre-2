using Microsoft.AspNetCore.Authorization;
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
        [Authorize] // Precisa estar logado para acessar a rota
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


        /// <summary>
        /// Endpoint que acessa o método de listar um gênero pesquisado por id
        /// </summary>
        /// <param name="id">Id do gênero (IdGenero)</param>
        /// <returns>Objeto Genero pesquisado e um status code</returns>
        [HttpGet("{id}")]
        [Authorize] // Precisa estar logado para acessar a rota
        public IActionResult GetbyId(int id)
        {
            try
            {
                // Cria um objeto para receber os genero
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado == null)
                {
                    return NotFound("O Gênero buscado não foi encontrado!");
                }

                // Retorna o status code 200 Ok e o Genero no formato JSON
                return Ok(generoBuscado);

            }
            catch (Exception erro)
            {
                // Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")] // Precisa estar logado para acessar a rota
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                // Faz a chamada para o método Cadastrar
                _generoRepository.Cadastrar(novoGenero);

                // Retorna um status code
                return Created("Objeto criado", novoGenero);
            }
            catch (Exception erro)
            {
                // Retorna um BadRequest (400) e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize] // Precisa estar logado para acessar a rota
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método Deletar
                _generoRepository.Deletar(id);

                // Retorna um status code
                return NoContent();
            }
            catch (Exception erro)
            {
                // Retorna um BadRequest (204/200) e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método de atualizar um Genero passando o id pela url
        /// </summary>
        /// <param name="id">id do Genero que será atualizado</param>
        /// <returns>Status code</returns>
        [HttpPut("{id}")]
        [Authorize] // Precisa estar logado para acessar a rota
        public IActionResult PutByUrl(int id, GeneroDomain genero)
        {
            try
            {
                // Faz a chamada para o método AtualizarIdUrl
                _generoRepository.AtualizarIdUrl(id, genero);

                if (genero == null)
                {
                    return NotFound("O gênero não foi encontrado!");
                }

                // Retorna o status code
                return Ok();
            }
            catch (Exception erro)
            {
                // Retorna um BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método de atualizar um Genero passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto Genero com as alterações</param>
        /// <returns>Status code</returns>
        [HttpPut]
        [Authorize] // Precisa estar logado para acessar a rota
        public IActionResult PutByBody(GeneroDomain genero)
        {
            try
            {
                // Faz a chamada para o método AtualizarIdCorpo
                _generoRepository.AtualizarIdCorpo(genero);

                if (genero == null)
                {
                    return NotFound("Genero não encontrado!");
                }

                // Retorna o status code
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}