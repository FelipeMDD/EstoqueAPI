using EstoqueApi.Models;
using EstoqueApi.Features;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace EstoqueApi.Controllers
{
    [ApiController]
    [Route("api/estoque/[controller]")]
    public class EstoqueController : Controller
    {
        private readonly IMediator _mediator;

        public EstoqueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Estoque>> ListarEstoque()
        {
            var query = new ListarEstoque();
            var estoque = await _mediator.Send(query);
            return estoque.ToList();
        }

        [HttpPut]
        [Route("consumir")]
        public async Task<IActionResult> ConsumirEstoque([FromBody] ConsumirEstoqueCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _mediator.Send(command);
                return CreatedAtAction(nameof(ConsumirEstoque), new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
