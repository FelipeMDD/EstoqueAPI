using EstoqueApi.ViewModels;
using EstoqueApi.Repositories;
using MediatR;
using EstoqueApi.Models;

namespace EstoqueApi.Features
{
    public class ListarMovimentacaoQueryHandler : IRequestHandler<ListarMovimentacaoQuery, MovimentacaoViewModel>
    {
        private readonly MovimentacaoEstoqueRepository _movimentacaoRepository;

        public ListarMovimentacaoQueryHandler(MovimentacaoEstoqueRepository movimentacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task<MovimentacaoViewModel> Handle(ListarMovimentacaoQuery request, CancellationToken cancellationToken)
        {
            var movimentacao = _movimentacaoRepository.ListarMovimentacaoEstoque(request.Data);

            var peca = movimentacao.Sum(a => a.Quantidade);

            if (peca == 0)
            {
                return new MovimentacaoViewModel
                {
                    TotalPeca = 0,
                    PrecoMedio = 0,
                    MovimentacaoPeca = new List<MovimentacaoPecaViewModel>()
                };
            }
            else
            {
                var result = new MovimentacaoViewModel
                {
                    TotalPeca = peca,
                    PrecoMedio = movimentacao.Sum(b => b.Custo) / peca,
                    MovimentacaoPeca = movimentacao
                };
                return result;
            }        
        }
    }
}
