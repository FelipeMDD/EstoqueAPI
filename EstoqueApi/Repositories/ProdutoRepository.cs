using Dapper;
using EstoqueApi.Interfaces;
using EstoqueApi.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace EstoqueApi.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string _connectionString;

        public ProdutoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Produto";
                return await connection.QueryAsync<Produto>(query);
            }
        }
        public async Task<Produto> ListarProdutoPorID(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Produto WHERE ProdutoID = @Id";
                var result = await connection.QueryAsync<Produto>(query, new { Id = id });
                
                return result.FirstOrDefault();              
            }
        }
        public async Task<Produto> ListarProdutoPorPartNumber(string partnumber)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Produto WHERE PartNumber = @Partnumber";
                var result = await connection.QueryAsync<Produto>(query, new { Partnumber = partnumber });

                return result.FirstOrDefault();
            }
        }
        public async Task<bool> InsereProduto(Produto produto)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO Produto (Nome, PartNumber, PrecoMedioCusto) VALUES (@Nome, @PartNumber, @PrecoMedioCusto);";
                var result = await connection.ExecuteScalarAsync<int>(query, produto);

                return result > 0;
            }
        }
        public async Task<bool> DeleteProduto(string partNumber)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "delete from Produto where PartNumber = PartNumber = @PartNumber";
                var result = await connection.ExecuteScalarAsync<int>(query, partNumber);

                return result > 0;
            }
        }
    }
}
