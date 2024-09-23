using EstoqueApi.Models;
using MediatR;

namespace EstoqueApi.Features
{
    public class ConsumirEstoqueCommand : IRequest<string>
    {
        public string PartNumber { get; set; }
        public int QuantidadeConsumida { get; set; }
        public ConsumirEstoqueCommand(string partNumber, int quantidadeConsumida)
        {
            PartNumber = partNumber;
            QuantidadeConsumida = quantidadeConsumida;
        }
    }
}


