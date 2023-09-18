using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock_CodeFirst.Domains;
using webapi.inlock_CodeFirst.Interfaces;
using webapi.inlock_CodeFirst.Repositories;

namespace webapi.inlock_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioReposiory();
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return Ok(usuario);
            }
            catch (Exception erro)
            {
                //return BadRequest(erro.Message);
                throw;
            }
        }

        // Falta implementar o endpoint
        /*
        [HttpGet]
        public IActionResult GetByEmailAndPassword(string email, string senha)
        {
            try
            {
                
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }*/
    }
}