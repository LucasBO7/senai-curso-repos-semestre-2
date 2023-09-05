using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repository
{
    public class JogoRepository : IJogoRepository
    {
        private string _stringConexao = "Data Source = NOTE14-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Busca todos os objetos do tipo Jogo
        /// </summary>
        /// <returns>Lista de objetos do tipo Jogo</returns>
        public List<JogoDomain> BuscarTodos()
        {
            List<JogoDomain> jogos = new List<JogoDomain>();

            using (SqlConnection connection = new SqlConnection(_stringConexao))
            {
                // Código SQL que será executado
                string queryGetAll = "SELECT Jogo.IdJogo, Jogo.Nome, Estudio.IdEstudio, Estudio.Nome AS 'NomeEstudio', Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor FROM Jogo LEFT JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio;";

                // Abre o banco de dados
                connection.Open();

                // Declara o SqlDataReader para percorrer as linhas da tabela do banco de dados
                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(queryGetAll, connection))
                {
                    // Executa a query SQL no banco de dados
                    reader = command.ExecuteReader();

                    // Adiciona os dados na lista enquanto houver linhas na tabela
                    while (!reader.Read())
                    {
                        JogoDomain jogoNoBd = new()
                        {
                            IdJogo = Convert.ToInt32(reader[nameof(JogoDomain.IdJogo)]),
                            Nome = reader[nameof(JogoDomain.Nome)].ToString(),
                            IdEstudio = Convert.ToInt32(reader[nameof(JogoDomain.IdEstudio)]),
                            Descricao = reader[nameof(JogoDomain.Descricao)].ToString(),
                            DataLancamento = reader[nameof(JogoDomain.DataLancamento)],
                            Valor = float.Parse(reader[nameof(JogoDomain.Valor)])
                        };
                        
                    }
                }

            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            throw new NotImplementedException();
        }
    }
}
