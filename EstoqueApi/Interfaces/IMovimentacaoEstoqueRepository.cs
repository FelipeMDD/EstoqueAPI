using EstoqueApi.Models;
using EstoqueApi.ViewModels;

namespace EstoqueApi.Interfaces
{
    public interface IMovimentacaoEstoqueRepository
    {
        IEnumerable<MovimentacaoEstoque> ListarEstoque();
        Task<bool> RegistrarMovimentacaoEstoque(MovimentacaoEstoque movimentacaoEstoque);
        List<MovimentacaoPecaViewModel> ListarMovimentacaoEstoque(DateTime dataMovimentacao);
    }
}
