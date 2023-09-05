using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os seguintes parâmetros:
        /// Data Source: nome do servidor do banco
        /// Initial Catalog: nome do banco de dados
        /// Autenticação
        ///     - windows : Integrated Security = true
        ///     - SqlServer: User Id = sa; Pwd = Senha
        /// </summary>
        private string _stringConexao = "Data Source = NOTE14-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Atualiza um genero pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto do genero alterado</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection connection = new(_stringConexao))
            {
                string queryUpdateByBody = $"UPDATE Genero SET Nome = @NomeGenero WHERE IdGenero = @idGeneroValor;";

                // Abre o banco de dados
                connection.Open();

                // Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados
                SqlDataReader reader;

                using (SqlCommand command = new(queryUpdateByBody, connection))
                {
                    command.Parameters.AddWithValue("@NomeGenero", genero.Nome);
                    command.Parameters.AddWithValue("@idGeneroValor", genero.IdGenero);

                    // Executa a query SQL e retorna somente o número de linhas afetadas, ou seja, não realiza uma query
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um genero pelo seu id, passado pela url
        /// </summary>
        /// <param name="id">Id passado pela url</param>
        /// <param name="genero">objeto do genero alterado</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection connection = new(_stringConexao))
            {
                string queryUpdateIdUrl = $"UPDATE Genero SET Nome = @NomeGenero WHERE IdGenero = @idGeneroValor;";

                // Abre o banco de dados
                connection.Open();

                // Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados
                SqlDataReader reader;

                using (SqlCommand command = new(queryUpdateIdUrl, connection))
                {
                    command.Parameters.AddWithValue("@NomeGenero", genero.Nome);
                    command.Parameters.AddWithValue("@idGeneroValor", id);

                    // Executa a query SQL e retorna somente o número de linhas afetadas, ou seja, não realiza uma query
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um genero pelo seu id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>objeto do tipo Genero buscado</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            // Instancia o Genero onde será armazenado os dados pegos do bd
            GeneroDomain generoBuscado = new();

            using (SqlConnection connection = new(_stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @idGeneroValor";

                // Abre a conexão com o banco de dados
                connection.Open();

                // Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados
                SqlDataReader reader;

                using (SqlCommand sqlCommand = new(querySelectById, connection))
                {
                    sqlCommand.Parameters.AddWithValue("idGeneroValor", id);

                    // Executa o comando SQL e insere o retorno do comando no objeto "reader"
                    reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        generoBuscado.IdGenero = Convert.ToInt32(reader[0]);
                        generoBuscado.Nome = reader[1].ToString();
                        return generoBuscado;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero"> Objeto com as infomações que serão cadastradas </param>
        /// <exception cref="NotImplementedException"></exception>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            // Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(_stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = $"INSERT INTO Genero(Nome) VALUES (@Nome)";

                // Declara o SqlCommand passando a query que será executada e a conexão con com o banco de dados
                using (SqlCommand command = new SqlCommand(queryInsert, con))
                {
                    command.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um objeto do tipo gênero
        /// </summary>
        /// <param name="id"> Deleta o gênero pelo seu Id </param>
        public void Deletar(int id)
        {
            // Declara SqlConnection passando a string de conexão como parametro
            using (SqlConnection connection = new SqlConnection(_stringConexao))
            {
                // Declara a instrução a ser executada
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @idGeneroValor";

                // Abre a conexão com o banco de dados
                connection.Open();

                // Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados
                SqlDataReader reader;

                // Declara o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand sqlCommand = new(queryDelete, connection))
                {
                    sqlCommand.Parameters.AddWithValue("idGeneroValor", id);

                    reader = sqlCommand.ExecuteReader();
                }

            }
        }

        /// <summary>
        /// Lista todos os objetos do tipo Genero
        /// </summary>
        /// <returns>Lista de objetos do tipo Genero</returns>
        public List<GeneroDomain> ListarTodos()
        {
            // Criar lista de Generos onde será armazenado os dados
            List<GeneroDomain> listaGeneros = new();

            // Declara a SqlConnection passando a string de conexão como parametro
            using (SqlConnection connection = new(_stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                // Abre a conexão com o banco de dados
                connection.Open();

                // Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados
                SqlDataReader reader;

                // Declara o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand sqlCommand = new(querySelectAll, connection))
                {
                    reader = sqlCommand.ExecuteReader();

                    // Enquanto houver registros para serem lidos no reader
                    // o laço se repetirá
                    while (reader.Read())
                    {
                        GeneroDomain generoDoBD = new()
                        {
                            // Atribui a propriedade IdGenero o valor da coluna IdGenero da tabela
                            IdGenero = Convert.ToInt32(reader[0]),
                            // Atribui a propriedade Nome o valor da coluna Nome da tabela
                            Nome = reader[1].ToString()
                        };

                        // Adiciona o objeto criado dentro da lista
                        listaGeneros.Add(generoDoBD);
                    }
                }
            }

            return listaGeneros;
        }
    }
}