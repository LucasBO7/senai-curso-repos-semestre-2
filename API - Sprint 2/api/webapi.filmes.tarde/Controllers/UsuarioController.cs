using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
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
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Objeto que possui acesso aos métodos do UsuarioRepository definidos na Interface
        /// </summary>
        private UsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instância do objeto _usuarioRepository para que haja referência aos objetos no repositório
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Realiza o Login do usuário por de um email e senha
        /// </summary>
        /// <param name="email">Email do usuário inserido</param>
        /// <param name="senha">Senha do usuário inserido</param>
        /// <returns>Status code</returns>
        [HttpGet]
        public IActionResult Login(string email, string senha)
        {
            try
            {
                UsuarioDomain usuario = _usuarioRepository.Login(email, senha);

                if (usuario == null)
                {
                    return NotFound("O usuário com o email e senha inserido não foi encontrado. Verifique se digitou corretamente ou se esse usuário existe.");
                }
                return Ok(usuario);
            }
            catch (Exception erro)
            {
                return NotFound(erro.Message);
            }
        }

    }
}