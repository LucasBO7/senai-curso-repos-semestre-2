using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    /// <summary>
    /// 
    /// </summary>
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
        private string _stringConexao = "Data Source = DESKTOP-ONQ7S9F; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";

        public void Atualizar(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
                    while(reader.Read())
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