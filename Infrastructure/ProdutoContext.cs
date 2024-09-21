using Dapper;
using EstoqueApi.Models;
using MySql.Data.MySqlClient;

namespace EstoqueApi.Infrastructure
{
    public class ProdutoContext
    {
        private readonly string _connectionString;

        public ProdutoContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Produto> ListarProdutos()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Produto";
                return connection.Query<Produto>(query);
            }
        }
    }
}
