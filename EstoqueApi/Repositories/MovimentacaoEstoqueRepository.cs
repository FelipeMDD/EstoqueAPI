using Dapper;
using EstoqueApi.Interfaces;
using EstoqueApi.Models;
using EstoqueApi.ViewModels;
using MySql.Data.MySqlClient;

namespace EstoqueApi.Repositories
{
    public class MovimentacaoEstoqueRepository : IMovimentacaoEstoqueRepository
    {
        private readonly string _connectionString;

        public MovimentacaoEstoqueRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<MovimentacaoEstoque> ListarEstoque()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM MovimentacaoEstoque";
                return connection.Query<MovimentacaoEstoque>(query);
            }
        }

        public async Task<bool> RegistrarMovimentacaoEstoque(MovimentacaoEstoque movimentacaoEstoque)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = @"
                INSERT INTO MovimentacaoEstoque (ProdutoID, DataMovimentacao, QuantidadeMovimentada, TipoMovimentacao, CustoMovimentacao)
                VALUES (@ProdutoID, @DataMovimentacao, @QuantidadeMovimentada, @TipoMovimentacao, (SELECT PrecoMedioCusto FROM Produto WHERE ProdutoID = @ProdutoID));
                SELECT LAST_INSERT_ID();"; 

                var id = await connection.ExecuteScalarAsync<int>(query, movimentacaoEstoque);
                return id > 0;
            }
        }

        public List<MovimentacaoPecaViewModel> ListarMovimentacaoEstoque(DateTime dataMovimentacao)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"SELECT p.Nome,p.PartNumber,m.DataMovimentacao, m.QuantidadeMovimentada as 'Quantidade', m.CustoMovimentacao as 'Custo' FROM Produto p 
                                inner join MovimentacaoEstoque m on m.ProdutoID = p.ProdutoID
                                where m.TipoMovimentacao = 'saida' and m.DataMovimentacao = @dataMovimentacao;";
                return connection.Query<MovimentacaoPecaViewModel>(query,new { dataMovimentacao }).ToList();
            }
        }
    }
}
