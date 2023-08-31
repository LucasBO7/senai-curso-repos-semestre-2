using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string _stringConexao = "Data Source = DESKTOP-ONQ7S9F; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(string email, string senha)
        {
            UsuarioDomain usuario = new();

            using (SqlConnection connection = new(_stringConexao))
            {
                string queryLogin = "SELECT Usuario.IdUsuario, Usuario.Email, Usuario.IdPermissao, Permissao.Nome FROM Usuario LEFT JOIN Permissao ON Usuario.IdPermissao = Permissao.IdPermissao WHERE Email = @EmailInserido AND Senha = @SenhaInserida";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new(queryLogin, connection))
                {
                    command.Parameters.AddWithValue("EmailInserido", email);
                    command.Parameters.AddWithValue("SenhaInserida", senha);

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        usuario = new()
                        {
                            IdUsuario = Convert.ToInt32(reader[nameof(UsuarioDomain.IdUsuario)]),
                            Email = reader[nameof(UsuarioDomain.Email)].ToString(),
                            IdPermissao = Convert.ToInt32(reader[nameof(UsuarioDomain.IdPermissao)])
                        };

                        Permissao permissao = new()
                        {
                            IdPermissao = Convert.ToInt32(reader[nameof(UsuarioDomain.IdPermissao)]),
                            Nome = reader[nameof(Permissao.Nome)].ToString()
                        };
                        // teSTE
                        usuario.Permissao = permissao;

                        return usuario;
                    }

                }
            }

            return null;
        }
    }
}