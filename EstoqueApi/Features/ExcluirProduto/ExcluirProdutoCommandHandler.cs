using EstoqueApi.Models;
using EstoqueApi.Repositories;
using MediatR;

namespace EstoqueApi.Features
{
    public class ExcluirProdutoCommandHandler : IRequestHandler<ExcluirProdutoCommand, string>
    {
        private readonly ProdutoRepository _produtoRepository;

        public ExcluirProdutoCommandHandler(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<string> Handle(ExcluirProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ListarProdutoPorPartNumber(request.PartNumber);

            if (produto.Nome.Any())
            {             
                await _produtoRepository.DeleteProduto(produto.PartNumber);
                return "Produto PartNumer: "+ produto.Nome + " deletado";
            }
            else
                return "Produto não encontrado"; 
        }
    }
}