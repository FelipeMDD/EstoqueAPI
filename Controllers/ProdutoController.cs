using EstoqueApi.Models;
using EstoqueApi.Features;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace EstoqueApi.Controllers
{
    [ApiController]
    [Route("api/produto/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            var query = new ListarProdutosQuery();
            var produtos = await _mediator.Send(query);
            return produtos.ToList(); 
        }
        
        [HttpPost]
        public async Task<IActionResult> AdicionarProduto([FromBody] AdicionarProdutoCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var produto = await _mediator.Send(command);
                return CreatedAtAction(nameof(AdicionarProduto), produto);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message); 
            }
        }
        [HttpDelete]
        [Route("excluir")]
        public async Task<IActionResult> ExcluirProduto([FromBody] ExcluirProdutoCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _mediator.Send(command);
                return CreatedAtAction(nameof(ExcluirProduto), new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
