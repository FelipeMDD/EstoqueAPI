using Dapper;
using EstoqueApi.Interfaces;
using EstoqueApi.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace EstoqueApi.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly string _connectionString;

        public EstoqueRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Estoque>> ListarEstoque()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Estoque";
                return await connection.QueryAsync<Estoque>(query);
            }
        }

        public async Task<Estoque> VerificarQuantidadeEstoque(string partNumber)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT p.ProdutoID, e.EstoqueID, p.PartNumber, e.QuantidadeDisponivel FROM Produto p LEFT JOIN Estoque e ON p.ProdutoID = e.ProdutoID WHERE p.PartNumber = @partNumber;";

                var result = await connection.QueryAsync<Estoque>(query, new { partNumber });
                return result.FirstOrDefault();
            }
        }
        public async Task<bool> ConsumirEstoque(int quantidadeEstoque, int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync(); 
                var query = "UPDATE Estoque SET QuantidadeDisponivel = @QuantidadeDisponivel WHERE ProdutoID = @Id";

                var result = await connection.ExecuteScalarAsync<int>(query, new { QuantidadeDisponivel = quantidadeEstoque, Id = id });

                return result > 0;
            }
        }
    }
}
