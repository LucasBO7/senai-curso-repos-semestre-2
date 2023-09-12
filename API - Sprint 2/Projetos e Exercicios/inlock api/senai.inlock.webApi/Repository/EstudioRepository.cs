using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repository
{
    public class EstudioRepository : IEstudioRepository
    {
        private string _stringConexao = "Data Source = NOTE14-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Busca todos os objetos do tipo Estudio
        /// </summary>
        /// <returns>Lista de objetos do tipo Jogo</returns>
        public List<EstudioDomain> BuscarTodos()
        {
            // Criar lista de Estudios onde será armazenado os dados
            List<EstudioDomain> estudios = new();

            // Declara a SqlConnection passando a string de conexão como parametro
            using (SqlConnection connection = new(_stringConexao))
            {
                // Código SQL que será executado
                string queryGetAll = "SELECT Estudio.IdEstudio, Estudio.Nome, Jogo.Nome, Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor FROM Estudio INNER JOIN Jogo ON Estudio.IdEstudio = Jogo.IdEstudio;";

                // Abre o banco de dados
                connection.Open();

                // Declara o SqlDataReader para percorrer as linhas da tabela do banco de dados
                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(queryGetAll, connection))
                {
                    // Executa a query SQL no banco de dados
                    reader = command.ExecuteReader();

                    // Adiciona os dados na lista enquanto houver linhas na tabela
                    while (reader.Read())
                    {
                        EstudioDomain estudio = new()
                        {
                            IdEstudio = Convert.ToInt32(reader[nameof(JogoDomain.IdEstudio)]),
                            Nome = reader["NomeEstudio"].ToString(),
                        };

                        JogoDomain jogoNoBd = new()
                        {
                            IdJogo = Convert.ToInt32(reader[nameof(JogoDomain.IdJogo)]),
                            IdEstudio = Convert.ToInt32(reader[nameof(JogoDomain.IdEstudio)]),
                            Nome = reader["NomeJogo"].ToString(),
                            Descricao = reader[nameof(JogoDomain.Descricao)].ToString(),
                            DataLancamento = reader[nameof(JogoDomain.DataLancamento)].ToString(), // MEXER DEPOIS
                            Valor = Convert.ToDecimal(reader[nameof(JogoDomain.Valor)])
                        };

                        estudio.Jogos.Add(jogoNoBd);
                        // Adiciona o objeto criado dentro da lista
                        estudios.Add(estudio);
                    }
                }

            }

            return estudios;
        }

        /// <summary>
        /// Busca um objeto do tipo Estudio
        /// </summary>
        /// <returns>Objeto do tipo Estudio buscado</returns>
        public List<EstudioDomain> BuscarPorId()
        {
            // Objeto Jogo onde será armazenado os dados
            List<EstudioDomain> estudiosBuscados = new();

            // Declara a SqlConnection passando a string de conexão como parametro
            using (SqlConnection connection = new SqlConnection(_stringConexao))
            {
                // Código SQL que será executado
                string queryGetAll = "SELECT IdEstudio, Estudio.Nome FROM Estudio;";

                // Abre o banco de dados
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryGetAll, connection))
                {
                    // Executa a query SQL no banco de dados
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        EstudioDomain estudio = new()
                        {
                            IdEstudio = Convert.ToInt32(reader[nameof(JogoDomain.IdEstudio)]),
                            Nome = reader[nameof(JogoDomain.Nome)].ToString(),
                        };

                        string queryGetJogos = "SELECT * FROM Jogo WHERE IdEstudio = @IdDoEstudioInserido";
                        SqlDataReader jogosReader;
                        using (SqlCommand jogoCommand = new(queryGetJogos, connection))
                        {
                            jogoCommand.Parameters.AddWithValue("IdDoEstudioInserido", estudio.IdEstudio);

                            jogosReader = jogoCommand.ExecuteReader();

                            while (jogosReader.Read())
                            {
                                JogoDomain jogo = new()
                                {
                                    IdJogo = Convert.ToInt32(jogosReader[nameof(JogoDomain.IdJogo)]),
                                    IdEstudio = estudio.IdEstudio,
                                    Nome = jogosReader[nameof(JogoDomain.Nome)].ToString(),
                                    Descricao = jogosReader[nameof(JogoDomain.Descricao)].ToString(),
                                    DataLancamento = jogosReader[nameof(JogoDomain.DataLancamento)].ToString(),
                                    Valor = Convert.ToDecimal(jogosReader[nameof(JogoDomain.Valor)]),
                                };

                                estudio.Jogos.Add(jogo);
                            }
                        }

                        estudiosBuscados.Add(estudio);
                    }

                    return estudiosBuscados;

                }

            }

            return null;
        }

        /// <summary>
        /// Insere um novo Jogo no banco de dados
        /// </summary>
        /// <param name="novoJogo">Objeto do tipo Jogo com os dados inseridos</param>
        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection connection = new(_stringConexao))
            {
                string queryInsert = "INSERT INTO Jogo VALUES (@IdDoEstudio, @NomeJogo, @DescricaoJogo, @DataLancamentoJogo, @ValorJogo)";

                connection.Open();

                using (SqlCommand command = new(queryInsert, connection))
                {
                    command.Parameters.AddWithValue("IdDoEstudio", novoJogo.IdEstudio);
                    command.Parameters.AddWithValue("NomeJogo", novoJogo.Nome);
                    command.Parameters.AddWithValue("DescricaoJogo", novoJogo.Descricao);
                    command.Parameters.AddWithValue("DataLancamentoJogo", novoJogo.DataLancamento);
                    command.Parameters.AddWithValue("ValorJogo", novoJogo.Valor);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um Jogo específico existente no banco de dados, com o Id como referência de busca
        /// </summary>
        /// <param name="id">Id referente ao Jogo</param>
        public void Deletar(int id)
        {
            using (SqlConnection connection = new(_stringConexao))
            {
                string queryInsert = "DELETE FROM Jogo WHERE IdJogo = @IdJogoInserido;";

                connection.Open();

                using (SqlCommand command = new(queryInsert, connection))
                {
                    command.Parameters.AddWithValue("IdJogoInserido", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um Jogo existente na tabela Usuario do banco de dados
        /// </summary>
        /// <param name="id">Id referente ao Jogo existente na tabela</param>
        /// <param name="jogo">Objeto do tipo Jogo com as informações</param>
        public void AtualizarIdUrl(int id, JogoDomain jogo)
        {
            using (SqlConnection connection = new(_stringConexao))
            {
                string queryInsert = "UPDATE Jogo SET IdEstudio = @IdEstudioInserido, Nome = @NomeJogoInserido, Descricao = @DescricaoJogoInserido, DataLancamento = @DataLancamentoJogoInserido, Valor = @ValorJogoInserido;";

                connection.Open();

                using (SqlCommand command = new(queryInsert, connection))
                {
                    command.Parameters.AddWithValue("IdEstudioInserido", jogo.IdEstudio);
                    command.Parameters.AddWithValue("NomeJogoInserido", jogo.Nome);
                    command.Parameters.AddWithValue("DescricaoJogoInserido", jogo.Descricao);
                    command.Parameters.AddWithValue("DataLancamentoJogoInserido", jogo.DataLancamento);
                    command.Parameters.AddWithValue("ValorJogoInserido", jogo.Valor);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }
    }
}
