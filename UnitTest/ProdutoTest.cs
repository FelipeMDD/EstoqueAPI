using EstoqueApi.Repositories;
using EstoqueApi.Features;
using Moq;
using EstoqueApi.Models;
using Xunit;
using EstoqueApi.Interfaces;

namespace EstoqueApi.UnitTest.ProdutoTeste
{
    public class ProdutosHandlerTests
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly ListarProdutosQueryHandler _handler;

        public ProdutosHandlerTests()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _handler = new ListarProdutosQueryHandler(_produtoRepositoryMock.Object);
        }

        [Fact]
        public async Task RetornoOk_Produto()
        {
            // Arrange
            var produtosMock = new List<Produto>
            {
                new Produto { ProdutoID = 1, Nome = "Produto 1" },
                new Produto { ProdutoID = 2, Nome = "Produto 2" }
            };

            _produtoRepositoryMock.Setup(repo => repo.ListarProdutos())
                                  .ReturnsAsync(produtosMock);

            // Act
            var result = await _handler.Handle(new ListarProdutosQuery(), CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count());
            _produtoRepositoryMock.Verify(repo => repo.ListarProdutos(), Times.Once);
        }
    }
}