using Dapper;
using EstoqueApi.Interfaces;
using EstoqueApi.Models;
using MySql.Data.MySqlClient;

namespace EstoqueApi.Repositories
{
    public class LogErroRepository : ILogErroRepository
    {
        private readonly string _connectionString;

        public LogErroRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IEnumerable<LogErro> ListarLogErro()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM LogErro";
                return connection.Query<LogErro>(query);
            }
        }
        public async Task InsereLogErroAsync(LogErro logErro)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO LogErro (Texto, Endpoint) VALUES (@Texto, @Endpoint);";
                var result = await connection.ExecuteScalarAsync<int>(query, logErro);
            }
        }
    }
}
