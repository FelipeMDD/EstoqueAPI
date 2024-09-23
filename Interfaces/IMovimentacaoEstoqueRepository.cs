using EstoqueApi.Models;

namespace EstoqueApi.Interfaces
{
    public interface IMovimentacaoEstoqueRepository
    {
        IEnumerable<MovimentacaoEstoque> ListarEstoque();
        Task<bool> RegistrarMovimentacaoEstoque(MovimentacaoEstoque movimentacaoEstoque);
    }
}
