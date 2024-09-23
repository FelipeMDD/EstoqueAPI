using EstoqueApi.Models;

namespace EstoqueApi.Interfaces
{
    public interface IEstoqueRepository
    {
        Task<IEnumerable<Estoque>> ListarEstoque();
        Task<Estoque> VerificarQuantidadeEstoque(string partNumber);
        Task<bool> ConsumirEstoque(int quantidadeEstoque, int id);
    }
}
