using EstoqueApi.Interfaces;
using EstoqueApi.Models;
using EstoqueApi.Repositories;
using MediatR;

namespace EstoqueApi.Features
{
    public class AdicionarProdutoCommandHandler : IRequestHandler<AdicionarProdutoCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public AdicionarProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Handle(AdicionarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto
            {
                Nome = request.Nome,
                PartNumber = request.PartNumber,
                PrecoMedioCusto = request.PrecoMedioCusto
            };

            await _produtoRepository.InsereProduto(produto);
            return produto; 
        }
    }
}