using EstoqueApi.Models;
using MediatR;

namespace EstoqueApi.Features
{
    public class ListarProdutosQuery : IRequest<IEnumerable<Produto>>
    {
        public ListarProdutosQuery()
        {
        }
    }
}