using EstoqueApi.Features;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using EstoqueApi.ViewModels;

namespace EstoqueApi.Controllers
{
    [ApiController]
    [Route("api/movimentacao/[controller]")]
    public class MovimentacaoController : Controller
    {
        private readonly IMediator _mediator;

        public MovimentacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("listar")]
        public async Task<MovimentacaoViewModel> ListarMovimentacaoDiaria([FromQuery] DateTime data)
        {
            var query = new ListarMovimentacaoQuery(data);
            var estoque = await _mediator.Send(query);
            return estoque;
        }
    }
}
