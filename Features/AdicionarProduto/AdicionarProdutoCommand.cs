using EstoqueApi.Models;
using MediatR;

namespace EstoqueApi.Features
{
    public class AdicionarProdutoCommand : IRequest<Produto>
    {
        public string Nome { get; set; }
        public string PartNumber { get; set; }
        public double PrecoMedioCusto { get; set; }

        public AdicionarProdutoCommand(string nome, string partNumber, double precoMedioCusto)
        {
            Nome = nome;
            PartNumber = partNumber;
            PrecoMedioCusto = precoMedioCusto;
        }
    }
}