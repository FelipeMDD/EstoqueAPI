using EstoqueApi.ViewModels;
using MediatR;

namespace EstoqueApi.Features
{
    public class ListarMovimentacaoQuery : IRequest<MovimentacaoViewModel>
    {
        public DateTime Data { get; set; }
        public ListarMovimentacaoQuery(DateTime data)
        {
            Data = data.Date;
        }
    }
}
