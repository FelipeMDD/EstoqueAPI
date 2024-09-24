using EstoqueApi.Interfaces;
using EstoqueApi.Models;
using EstoqueApi.Repositories;
using MediatR;

namespace EstoqueApi.Features
{
    public class ConsumirEstoqueCommandHandler : IRequestHandler<ConsumirEstoqueCommand, string>
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IMovimentacaoEstoqueRepository _movimentacaoEstoqueRepository;

        public ConsumirEstoqueCommandHandler(IEstoqueRepository estoqueRepository, IMovimentacaoEstoqueRepository movimentacaoEstoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
            _movimentacaoEstoqueRepository = movimentacaoEstoqueRepository;
        }

        public async Task<string> Handle(ConsumirEstoqueCommand request, CancellationToken cancellationToken)
        {

            var pecaEstoque = await _estoqueRepository.VerificarQuantidadeEstoque(request.PartNumber);

            if (pecaEstoque == null)
                return "Produto não existe";
            else if (pecaEstoque.QuantidadeDisponivel == null || pecaEstoque.QuantidadeDisponivel == 0)
                return "Não há peças desse produto no estoque";
            else if (pecaEstoque.QuantidadeDisponivel < request.QuantidadeConsumida)
                return "Quantidade em estoque menor que a consumida";
            else
            {
                var movimentacaoEstoque = new MovimentacaoEstoque 
                {
                    ProdutoID = pecaEstoque.ProdutoID,
                    QuantidadeMovimentada = request.QuantidadeConsumida,
                    DataMovimentacao = DateTime.Now,
                    TipoMovimentacao = Models.Enum.TipoMovimentacao.Saida
                }; 

                await _movimentacaoEstoqueRepository.RegistrarMovimentacaoEstoque(movimentacaoEstoque);
                await _estoqueRepository.ConsumirEstoque(pecaEstoque.ProdutoID, request.QuantidadeConsumida);

                return "Estoque atualizado";
            }
        }
    }
}