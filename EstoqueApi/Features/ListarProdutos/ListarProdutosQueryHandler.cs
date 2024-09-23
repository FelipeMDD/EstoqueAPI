using EstoqueApi.Interfaces;
using EstoqueApi.Models;
using EstoqueApi.Repositories;
using MediatR;

namespace EstoqueApi.Features
{
    public class ListarProdutosQueryHandler : IRequestHandler<ListarProdutosQuery, IEnumerable<Produto>>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ListarProdutosQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> Handle(ListarProdutosQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.ListarProdutos();
        }
    }
}