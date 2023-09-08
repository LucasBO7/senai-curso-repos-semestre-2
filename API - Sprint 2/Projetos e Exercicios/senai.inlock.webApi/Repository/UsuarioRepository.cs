using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string _stringConexao = "Data Source = DESKTOP-84UMQCT\\SQLEXPRESS; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Realiza o login do usuário: Busca um usuário no banco de dados com base em um email e senha inseridos pelo usuário e retorna o objeto Usuario com todas as informações
        /// </summary>
        /// <param name="usuario">Objeto Usuario</param>
        /// <returns>Objeto Usuario buscado</returns>
        public UsuarioDomain Login(UsuarioDomain usuario)
        {
            UsuarioDomain usuarioLogado = new();

            using (SqlConnection connection = new(_stringConexao))
            {
                // Query que realizará o login/busca do usuário no banco de dados
                string queryLogin = "SELECT Usuario.IdUsuario, Usuario.Email, Usuario.Senha, TiposUsuario.IdTipoUsuario, TiposUsuario.Titulo FROM Usuario INNER JOIN TiposUsuario ON Usuario.IdTipoUsuario = TiposUsuario.IdTipoUsuario WHERE Usuario.Email = @EmailUsuarioInserido AND Usuario.Senha = @SenhaUsuarioInserido;";

                // Abre a conexão com o banco de dados
                connection.Open();

                // Reader para percorrer as linhas da tabela
                SqlDataReader reader;

                using (SqlCommand command = new(queryLogin, connection))
                {
                    command.Parameters.AddWithValue("EmailUsuarioInserido", usuario.Email);
                    command.Parameters.AddWithValue("SenhaUsuarioInserido", usuario.Senha);

                    reader = command.ExecuteReader();

                    // Se houver um Usuario com as informações descritas. Ou seja, Se a tabela de retorno contiver uma ou mais linhas
                    if (reader.Read())
                    {
                        usuarioLogado = new()
                        {
                            IdUsuario = Convert.ToInt32(reader[nameof(UsuarioDomain.IdUsuario)]),
                            IdTipoUsuario = Convert.ToInt32(reader[nameof(UsuarioDomain.IdTipoUsuario)]),
                            Email = reader[nameof(UsuarioDomain.Email)].ToString(),
                            Senha = reader[nameof(UsuarioDomain.Senha)].ToString()
                        };

                        TiposUsuarioDomain tipoUsuario = new()
                        {
                            IdTiposUsuarioDomain = Convert.ToInt32(reader[nameof(UsuarioDomain.IdTipoUsuario)]),
                            Titulo = reader[nameof(TiposUsuarioDomain.Titulo)].ToString(),
                        };

                        usuarioLogado.TipoUsuario = tipoUsuario;
                        return usuarioLogado;
                    }
                }
            }
            return null;
        }



    }
}