using Dapper;
using EstoqueApi.Models;
using MySql.Data.MySqlClient;

namespace EstoqueApi.Repositories
{
    public class PrecoHistoricoRepository
    {
        private readonly string _connectionString;

        public PrecoHistoricoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<PrecoHistorico> ListarPrecoHistorico()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM PrecoHistorico";
                return connection.Query<PrecoHistorico>(query);
            }
        }
    }
}

