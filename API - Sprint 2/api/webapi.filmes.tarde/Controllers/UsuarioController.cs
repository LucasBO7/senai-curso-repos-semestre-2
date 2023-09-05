using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Repositories;
using System.Text;

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
        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("O usuário com o email e senha inserido não foi encontrado. Verifique se digitou corretamente ou se esse usuário existe.");
                }

                // Caso encontre o usuário buscado, prossegue para a criação do Token

                // 1 - Definir as informações(Claims) que serão fornecidas no Token (Payload)
                var claims = new[]
                {
                    // formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Permissao),
                    // Existe a possibilidade de criar uma Claim personalizada
                    new Claim("Claim Personalizada", "Valor Personalizado")
                };

                // 2 - Definir a chave de acesso do toten
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                // 3 - Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4 - Gerar o tokens
                var token = new JwtSecurityToken
                (
                    // emissor do token
                    issuer: "webapi.filmes.tarde",

                    // destinatário
                    audience: "webapi.filmes.tarde",

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

                //return Ok(usuarioBuscado);
            }
            catch (Exception erro)
            {
                return NotFound(erro.Message);
            }
        }

    }
}