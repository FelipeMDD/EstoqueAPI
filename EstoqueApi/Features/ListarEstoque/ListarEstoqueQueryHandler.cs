using EstoqueApi.Models;
using EstoqueApi.Repositories;
using MediatR;

namespace EstoqueApi.Features
{
    public partial class ListarEstoque : IRequest<IEnumerable<Estoque>> { }

    public class ListarEstoqueQueryHandler : IRequestHandler<ListarEstoque, IEnumerable<Estoque>>
    {
        private readonly EstoqueRepository _estoqueRepository;

        public ListarEstoqueQueryHandler(EstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<IEnumerable<Estoque>> Handle(ListarEstoque request, CancellationToken cancellationToken)
        {
            return await _estoqueRepository.ListarEstoque();
        }
    }
}