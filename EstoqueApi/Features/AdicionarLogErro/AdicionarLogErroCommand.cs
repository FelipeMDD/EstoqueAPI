using EstoqueApi.Models;
using MediatR;

namespace EstoqueApi.Features
{
    public class AdicionarLogErroCommand : IRequest<LogErro>
    {
        public string Texto { get; set; }
        public string EndPoint { get; set; }

        public AdicionarLogErroCommand(string texto, string endPoint)
        {
            Texto = texto;
            EndPoint = endPoint;
        }
    }
}