using EstoqueApi.Models;
using EstoqueApi.Repositories;
using MediatR;

namespace EstoqueApi.Features
{
    // Define a query que será enviada ao handler
    public partial class ListarProdutos : IRequest<IEnumerable<Produto>> { }

    // Define o handler para a query
    public class ListarProdutosQueryHandler : IRequestHandler<ListarProdutos, IEnumerable<Produto>>
    {
        private readonly ProdutoRepository _produtoRepository;

        public ListarProdutosQueryHandler(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // Método que lida com a query
        public async Task<IEnumerable<Produto>> Handle(ListarProdutos request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.ListarProdutos();
        }
    }
}