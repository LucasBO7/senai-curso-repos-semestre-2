using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;
using webapi.event_.tarde.ViewModels;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel loginViewModel)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginViewModel.Email!, loginViewModel.Senha!);

                if (usuarioBuscado == null)
                    return NotFound("Email ou senha inválidos!");

                // Se o usuário for encontrado, um token será gerado e retornado por JSON

                // 1 - Definir as informações(Claims) que serão fornecidas no Token (Payload)
                var claims = new[]
                {
                    // formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario!.Titulo!)
                };

                // 2 - Definir a chave de acesso do toten
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("event+-chave-atutenticacao-webapi"));

                // 3 - Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4 - Gerar o tokens
                var token = new JwtSecurityToken
                (
                    // emissor do token
                    issuer: "webapi.event+.webapi",

                    // destinatário
                    audience: "webapi.event+.webapi",

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


            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}