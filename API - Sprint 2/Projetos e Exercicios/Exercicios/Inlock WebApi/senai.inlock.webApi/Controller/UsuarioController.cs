using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using senai.inlock.webApi.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace senai.inlock.webApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")] // Especifica que essa API trabalha no formato de JSON
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Objeto para acessar os métodos do UsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instância do objeto _usuarioRepository para que seja possível referência aos objetos no repositorio
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Realiza o Login do Usuario. Ou seja, busca um usuário com os dados informados e retorna uma chave de autenticação
        /// </summary>
        /// <param name="usuario">Objeto do tipo Usuario</param>
        /// <returns>Token de acesso</returns>
        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioLogado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioLogado == null)
                    return NotFound("O usuário com o Email e Senha inseridos não foi encontrado. Verifique se inseriu corretamente os campos ou se o usuário existe.");

                // Caso encontre o usuário buscado, pressegue para a criação do Token

                //Definir as informações(Claims)que serão fornecidas no Token(Payload)
                var claims = new[]
                {
                    // formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioLogado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioLogado.Email),
                    new Claim(ClaimTypes.Role, usuarioLogado.TipoUsuario.Titulo)
                    // Existe a possibilidade de criar uma Claim personalizada
                    //new Claim("Claim Personalizada", "Valor Personalizado")
                };


                // 2 - Definir a chave de acesso do toten
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("usuario-chave-autenticacao-webapi-inlock-app"));

                // 3 - Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4 - Gerar o tokens
                var token = new JwtSecurityToken
                (
                    // emissor do token
                    issuer: "webapi.inlock.app",

                    // destinatário
                    audience: "webapi.inlock.app",

                    // dados definidos nas claims (Payload)
                    claims: claims,

                    // tempo de expiração
                    expires: DateTime.Now.AddMinutes(5),

                    // credenciais do token
                    signingCredentials: creds
                );

                // 5 - Retornar o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });


                //return Ok(usuarioLogado);
            }
            catch (Exception erro)
            {
                return NotFound(erro.Message);
            }

        }

        /// <summary>
        /// Insere um novo Usuario no banco
        /// </summary>
        /// <param name="usuario">Objeto do tipo Usuario</param>
        /// <returns>Status code</returns>
        [HttpPost("cadastrar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Register(UsuarioDomain usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return Ok("Usuário cadastrado com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca todos os Usuarios do banco
        /// </summary>
        /// <returns>Lista de objetos do tipo Usuario</returns>
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult GetAll()
        {
            try
            {
                List<UsuarioDomain> usuariosBuscados = _usuarioRepository.BuscarTodos();

                if (usuariosBuscados == null)
                    return NotFound();

                return Ok(usuariosBuscados);
            }
            catch (Exception erro)
            {
                return Problem(erro.Message);
            }

        }

        /// <summary>
        /// Busca todos os Usuarios do banco
        /// </summary>
        /// <returns>Lista de objetos do tipo Usuario</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult GetById(int id)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Buscar(id);

                if (usuarioBuscado == null)
                    return NotFound();

                return Ok(usuarioBuscado);
            }
            catch (Exception erro)
            {
                return Problem(erro.Message);
            }

        }

        /// <summary>
        /// Deleta um Usuario pelo id especificado
        /// </summary>
        /// <param name="id">id do Usuario a ser deletado</param>
        /// <returns>Status code</returns>
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound("Verifique se o Id escolhido existe.");
                }
                _usuarioRepository.Deletar(id);
                return Ok("Usuário deletado com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Editar um Usuario
        /// </summary>
        /// <param name="usuario">Objeto do tipo Usuario</param>
        /// <returns>Status code</returns>
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public IActionResult PutByBody(UsuarioDomain usuario)
        {
            try
            {
                if (usuario == null)
                    return NotFound();

                _usuarioRepository.Atualizar(usuario);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}