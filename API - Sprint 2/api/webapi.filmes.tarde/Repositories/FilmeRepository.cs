using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string _stringConexao = "Data Source = NOTE14-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection connection = new(_stringConexao))
            {
                string queryUpdateByBody = "UPDATE Filme SET IdGenero = @IdGeneroFilme, Titulo = @TituloFilme WHERE IdFilme = @IdDoFilme";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new(queryUpdateByBody, connection))
                {
                    command.Parameters.AddWithValue("IdGeneroFilme", filme.IdGenero);
                    command.Parameters.AddWithValue("TituloFilme", filme.Titulo);
                    command.Parameters.AddWithValue("IdDoFilme", filme.IdFilme);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection connection = new(_stringConexao))
            {
                string queryUpdateByUrl = "UPDATE Filme SET IdGenero = @IdGeneroFilme, Titulo = @TituloFilme WHERE IdFilme = @IdDoFilme";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new(queryUpdateByUrl, connection))
                {
                    command.Parameters.AddWithValue("IdGeneroFilme", filme.IdGenero);
                    command.Parameters.AddWithValue("TituloFilme", filme.Titulo);
                    command.Parameters.AddWithValue("IdDoFilme", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int id)
        {
            FilmeDomain filmeBuscado = new FilmeDomain();

            using (SqlConnection connection = new(_stringConexao))
            {
                string querySelectById = "SELECT * FROM Filme WHERE IdFilme = @IdDoFilme";

                connection.Open(); 

                SqlDataReader reader;

                using (SqlCommand command = new(querySelectById, connection))
                {
                    command.Parameters.AddWithValue("IdDoFilme", id);

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        filmeBuscado.IdFilme = Convert.ToInt32(reader[ nameof(FilmeDomain.IdFilme) ]);
                        filmeBuscado.IdGenero = Convert.ToInt32(reader[nameof(FilmeDomain.IdGenero)]);
                        filmeBuscado.Titulo = reader[nameof(FilmeDomain.Titulo)].ToString();

                        GeneroDomain genero = new()
                        {
                            IdGenero = Convert.ToInt32(reader[nameof(GeneroDomain.IdGenero)]),
                            Nome = reader[nameof(GeneroDomain.Nome)].ToString()
                        };

                        filmeBuscado.Genero = genero;

                        return filmeBuscado;
                    }
                }

            }

            return null;
        }

        public List<FilmeDomain> ListarTodos()
        {
            // Criar lista de Filme onde será armazenado os dados
            List<FilmeDomain> listaFilmes = new();

            // Declara a SqlConnection passando a string de conexão como parametro
            using (SqlConnection connection = new(_stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT Filme.IdFilme, Genero.IdGenero, Filme.Titulo, Genero.Nome FROM Filme left join Genero on Genero.IdGenero = Filme.IdGenero";

                // Abre a conexão com o banco de dados
                connection.Open();

                // Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados
                SqlDataReader reader;

                // Declara o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand sqlCommand = new(querySelectAll, connection))
                {
                    // Executa a query SQL no banco de dados
                    reader = sqlCommand.ExecuteReader();

                    // Enquanto houver registros para serem lidos no reader
                    // o laço se repetirá
                    while (reader.Read())
                    {
                        FilmeDomain filmeInDb = new()
                        {
                            IdFilme = Convert.ToInt32(reader[0]),
                            // Atribui a propriedade IdGenero o valor da coluna IdGenero da tabela
                            IdGenero = Convert.ToInt32(reader[1]),
                            // Atribui a propriedade Titulo o valor da coluna Titulo da tabela
                            Titulo = reader["Titulo"].ToString()
                        };

                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(reader[1]),
                            Nome = reader[3].ToString()
                        };

                        filmeInDb.Genero = genero;


                        // Adiciona o objeto criado dentro da lista
                        listaFilmes.Add(filmeInDb);
                    }
                }
            }

            return listaFilmes;
        }


        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection connection = new(_stringConexao))
            {
                string queryRegister = $"INSERT INTO Filme(IdGenero, Titulo) VALUES(@IdDoGenero, @TituloFilme)";

                connection.Open();

                using (SqlCommand command = new SqlCommand(queryRegister, connection))
                {
                    command.Parameters.AddWithValue("IdDoGenero", novoFilme.IdGenero);
                    command.Parameters.AddWithValue("TituloFilme", novoFilme.Titulo);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection connection = new(_stringConexao))
            {
                string queryDelete = "DELETE FROM Filme WHERE IdFilme = @IdFilmeADeletar";

                connection.Open();

                using (SqlCommand command = new(queryDelete, connection))
                {
                    command.Parameters.AddWithValue("IdFilmeADeletar", id);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}