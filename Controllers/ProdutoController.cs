using EstoqueApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly ProdutoContext _produtoRepository;

        public ProdutoController(ProdutoContext produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult GetProdutos()
        {
            var produtos = _produtoRepository.ListarProdutos();
            return Ok(produtos);
        }
    }
}
