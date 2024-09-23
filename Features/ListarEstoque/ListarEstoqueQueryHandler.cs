using EstoqueApi.Models;
using EstoqueApi.Repositories;
using MediatR;

namespace EstoqueApi.Features
{
    // Define a query que será enviada ao handler
    public partial class ListarEstoque : IRequest<IEnumerable<Estoque>> { }

    // Define o handler para a query
    public class ListarEstoqueQueryHandler : IRequestHandler<ListarEstoque, IEnumerable<Estoque>>
    {
        private readonly EstoqueRepository _estoqueRepository;

        public ListarEstoqueQueryHandler(EstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        // Método que lida com a query
        public async Task<IEnumerable<Estoque>> Handle(ListarEstoque request, CancellationToken cancellationToken)
        {
            return await _estoqueRepository.ListarEstoque();
        }
    }
}