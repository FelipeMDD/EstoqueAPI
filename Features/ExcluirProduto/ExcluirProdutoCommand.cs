using EstoqueApi.Models;
using MediatR;

namespace EstoqueApi.Features
{
    public class ExcluirProdutoCommand : IRequest<string>
    {
        public string PartNumber { get; set; }

        public ExcluirProdutoCommand(string partNumber)
        {
            PartNumber = partNumber;
        }
    }
}