using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string _stringConexao = "Data Source = NOTE14-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(string email, string senha)
        {
            UsuarioDomain usuario = new();

            using (SqlConnection connection = new(_stringConexao))
            {
                string queryLogin = "SELECT IdUsuario, Email, Permissao FROM Usuario WHERE Email = @EmailInserido AND Senha = @SenhaInserida";

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
                            Permissao = reader["Permissao"].ToString()
                        };

                        return usuario;
                    }

                }
            }

            return null;
        }
    }
}