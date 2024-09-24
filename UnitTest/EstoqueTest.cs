using EstoqueApi.Features;
using EstoqueApi.Interfaces;
using EstoqueApi.Models;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EstoqueApi.UnitTest.EstoqueTeste
{
    public class ConsumirEstoqueCommandHandlerTests
    {
        private readonly Mock<IEstoqueRepository> _estoqueRepositoryMock;
        private readonly Mock<IMovimentacaoEstoqueRepository> _movimentacaoEstoqueRepositoryMock;
        private readonly ConsumirEstoqueCommandHandler _handler;

        public ConsumirEstoqueCommandHandlerTests()
        {
            _estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            _movimentacaoEstoqueRepositoryMock = new Mock<IMovimentacaoEstoqueRepository>();
            _handler = new ConsumirEstoqueCommandHandler(_estoqueRepositoryMock.Object, _movimentacaoEstoqueRepositoryMock.Object);
        }

        [Fact]
        public async Task ProdutoNaoExiste()
        {
            // Arrange
            var command = new ConsumirEstoqueCommand("P1", 1);
            _estoqueRepositoryMock.Setup(repo => repo.VerificarQuantidadeEstoque(command.PartNumber))
                                  .ReturnsAsync((Estoque)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("Produto não existe", result);
        }

        [Fact]
        public async Task ReturnEstoqueVazio()
        {
            // Arrange
            var command = new ConsumirEstoqueCommand("P1", 1);
            var estoque = new Estoque { ProdutoID = 1, QuantidadeDisponivel = 0 };
            _estoqueRepositoryMock.Setup(repo => repo.VerificarQuantidadeEstoque(command.PartNumber))
                                  .ReturnsAsync(estoque);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("Não há peças desse produto no estoque", result);
        }

        [Fact]
        public async Task ReturnQuantidadeMenorQueConsumida()
        {
            // Arrange
            var command = new ConsumirEstoqueCommand("P1", 5);
            var estoque = new Estoque { ProdutoID = 1, QuantidadeDisponivel = 3 };
            _estoqueRepositoryMock.Setup(repo => repo.VerificarQuantidadeEstoque(command.PartNumber))
                                  .ReturnsAsync(estoque);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("Quantidade em estoque menor que a consumida", result);
        }

        [Fact]
        public async Task ReturnEstoqueAtualizado()
        {
            // Arrange
            var command = new ConsumirEstoqueCommand("P1", 1);
            var estoque = new Estoque { ProdutoID = 1, QuantidadeDisponivel = 5 };
            _estoqueRepositoryMock.Setup(repo => repo.VerificarQuantidadeEstoque(command.PartNumber))
                                  .ReturnsAsync(estoque);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("Estoque atualizado", result);
            _movimentacaoEstoqueRepositoryMock.Verify(repo => repo.RegistrarMovimentacaoEstoque(It.IsAny<MovimentacaoEstoque>()), Times.Once);
            _estoqueRepositoryMock.Verify(repo => repo.ConsumirEstoque(estoque.ProdutoID, command.QuantidadeConsumida), Times.Once);
        }
    }
}