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
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioLogado = _usuarioRepository.Login(usuario);

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

    }
}
