using EstoqueApi.Models;

namespace EstoqueApi.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ListarProdutos();
        Task<Produto> ListarProdutoPorID(int id);
        Task<Produto> ListarProdutoPorPartNumber(string partNumber);
        Task<bool> InsereProduto(Produto produto);
        Task<bool> DeleteProduto(string partNumber);
    }
}
