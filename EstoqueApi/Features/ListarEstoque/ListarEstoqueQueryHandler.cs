using EstoqueApi.Interfaces;
using EstoqueApi.Models;
using EstoqueApi.Repositories;
using MediatR;

namespace EstoqueApi.Features
{
    public partial class ListarEstoque : IRequest<IEnumerable<Estoque>> { }

    public class ListarEstoqueQueryHandler : IRequestHandler<ListarEstoque, IEnumerable<Estoque>>
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public ListarEstoqueQueryHandler(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<IEnumerable<Estoque>> Handle(ListarEstoque request, CancellationToken cancellationToken)
        {
            return await _estoqueRepository.ListarEstoque();
        }
    }
}