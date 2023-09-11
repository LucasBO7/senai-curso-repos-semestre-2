using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string _stringConexao = "Data Source = NOTE14-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Realiza o login do usuário: Busca um usuário no banco de dados com base em um email e senha inseridos pelo usuário e retorna o objeto Usuario com todas as informações
        /// </summary>
        /// <param name="usuario">Objeto Usuario</param>
        /// <returns>Objeto Usuario buscado</returns>
        public UsuarioDomain Login(string email, string senha)
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
                    command.Parameters.AddWithValue("EmailUsuarioInserido", email);
                    command.Parameters.AddWithValue("SenhaUsuarioInserido", senha);

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

        public void Cadastrar(UsuarioDomain usuario)
        {
            using (SqlConnection connection = new(_stringConexao))
            {
                // Query SQL que será executada no banco de dados
                string queryInsertNewUser = "INSERT INTO Usuario VALUES(@IdTipoUsuarioInserido, @EmailUsuarioInserido, @SenhaUsuarioInserido);";

                // Abrea a conexão com o banco de dados
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryInsertNewUser, connection))
                {
                    command.Parameters.AddWithValue("IdTipoUsuarioInserido", usuario.IdTipoUsuario);
                    command.Parameters.AddWithValue("EmailUsuarioInserido", usuario.Email);
                    command.Parameters.AddWithValue("SenhaUsuarioInserido", usuario.Senha);

                    command.ExecuteNonQuery();
                }
            }

        }

        public UsuarioDomain Buscar(int id)
        {
            using (SqlConnection connection = new(_stringConexao))
            {
                UsuarioDomain usuario = new();

                // Query SQL que será executada no banco de dados
                string queryInsertNewUser = "SELECT Usuario.IdUsuario, Usuario.IdTipoUsuario, TiposUsuario.Titulo, Usuario.Email, Usuario.Senha FROM Usuario INNER JOIN TiposUsuario ON Usuario.IdTipoUsuario = TiposUsuario.IdTipoUsuario WHERE IdUsuario = @IdDoUsuario;";

                // Abrea a conexão com o banco de dados
                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(queryInsertNewUser, connection))
                {
                    command.Parameters.AddWithValue("IdDoUsuario", id);

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        usuario = new()
                        {
                            IdUsuario = Convert.ToInt32(reader[nameof(UsuarioDomain.IdUsuario)]),
                            IdTipoUsuario = Convert.ToInt32(reader[nameof(UsuarioDomain.IdTipoUsuario)]),
                            Email = reader[nameof(UsuarioDomain.Email)].ToString(),
                            Senha = reader[nameof(UsuarioDomain.Senha)].ToString(),
                        };

                        TiposUsuarioDomain tipoUsuario = new()
                        {
                            IdTiposUsuarioDomain = Convert.ToInt32(reader[nameof(UsuarioDomain.IdTipoUsuario)]),
                            Titulo = reader[nameof(TiposUsuarioDomain.Titulo)].ToString()
                        };

                        usuario.TipoUsuario = tipoUsuario;
                        return usuario;
                    }
                    return null;
                }
            }
        }

        public List<UsuarioDomain> BuscarTodos()
        {
            List<UsuarioDomain> usuarios = new();

            using (SqlConnection connection = new(_stringConexao))
            {
                // Query SQL que será executada no banco de dados
                string queryInsertNewUser = "SELECT Usuario.IdUsuario, Usuario.IdTipoUsuario, TiposUsuario.Titulo, Usuario.Email, Usuario.Senha FROM Usuario INNER JOIN TiposUsuario ON Usuario.IdTipoUsuario = TiposUsuario.IdTipoUsuario;";

                // Abrea a conexão com o banco de dados
                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(queryInsertNewUser, connection))
                {
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        UsuarioDomain usuario = new()
                        {
                            IdUsuario = Convert.ToInt32(reader[nameof(UsuarioDomain.IdUsuario)]),
                            IdTipoUsuario = Convert.ToInt32(reader[nameof(UsuarioDomain.IdTipoUsuario)]),
                            Email = reader[nameof(UsuarioDomain.Email)].ToString(),
                            Senha = reader[nameof(UsuarioDomain.Senha)].ToString(),
                        };

                        TiposUsuarioDomain tipoUsuario = new()
                        {
                            IdTiposUsuarioDomain = Convert.ToInt32(reader[nameof(UsuarioDomain.IdTipoUsuario)]),
                            Titulo = reader[nameof(TiposUsuarioDomain.Titulo)].ToString()
                        };

                        usuario.TipoUsuario = tipoUsuario;
                        usuarios.Add(usuario);
                    }
                    return usuarios;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection connection = new(_stringConexao))
            {
                // Query SQL que será executada no banco de dados
                string queryInsertNewUser = "DELETE FROM Usuario WHERE IdUsuario = @IdUsuarioInserido";

                // Abrea a conexão com o banco de dados
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryInsertNewUser, connection))
                {
                    command.Parameters.AddWithValue("IdUsuarioInserido", id);

                    command.ExecuteNonQuery();
                }
            }

        }

        public void Atualizar(UsuarioDomain usuario)
        {
            using (SqlConnection connection = new(_stringConexao))
            {
                // Query SQL que será executada no banco de dados
                string queryInsertNewUser = "UPDATE Usuario SET IdTipoUsuario = @IdTipoUsuarioInserido, Email = @EmailUsuarioInserido, Senha = @SenhaUsuarioInserido WHERE IdUsuario = @IdUsuarioInserido;";

                // Abrea a conexão com o banco de dados
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryInsertNewUser, connection))
                {
                    command.Parameters.AddWithValue("IdUsuarioInserido", usuario.IdUsuario);
                    command.Parameters.AddWithValue("IdTipoUsuarioInserido", usuario.IdTipoUsuario);
                    command.Parameters.AddWithValue("EmailUsuarioInserido", usuario.Email);
                    command.Parameters.AddWithValue("SenhaUsuarioInserido", usuario.Senha);

                    command.ExecuteNonQuery();
                }
            }

        }
    }
}