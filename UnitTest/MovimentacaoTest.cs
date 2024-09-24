using EstoqueApi.Features;
using EstoqueApi.Interfaces;
using EstoqueApi.Models;
using EstoqueApi.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EstoqueApi.UnitTest.MovimentacaoTeste
{
    public class ListarMovimentacaoQueryHandlerTests
    {
        private readonly Mock<IMovimentacaoEstoqueRepository> _movimentacaoRepositoryMock;
        private readonly ListarMovimentacaoQueryHandler _handler;

        public ListarMovimentacaoQueryHandlerTests()
        {
            _movimentacaoRepositoryMock = new Mock<IMovimentacaoEstoqueRepository>();
            _handler = new ListarMovimentacaoQueryHandler(_movimentacaoRepositoryMock.Object);
        }

        [Fact]
        public async Task ReturnViewModelVazia()
        {
            // Arrange
            var query = new ListarMovimentacaoQuery ( DateTime.Now ); 
            _movimentacaoRepositoryMock.Setup(repo => repo.ListarMovimentacaoEstoque(query.Data))
                                        .Returns(new List<MovimentacaoPecaViewModel>()); 

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(0, result.TotalPeca);
            Assert.Equal(0, result.PrecoMedio);
            Assert.Empty(result.MovimentacaoPeca);
        }

        [Fact]
        public async Task ReturnViewModel()
        {
            // Arrange
            var query = new ListarMovimentacaoQuery (DateTime.Now);
            var movimentacaoList = new List<MovimentacaoPecaViewModel>
            {
                new MovimentacaoPecaViewModel { Quantidade = 5, Custo = 10, DataMovimentacao = DateTime.Now },
                new MovimentacaoPecaViewModel { Quantidade = 3, Custo = 12, DataMovimentacao = DateTime.Now }
            };

            _movimentacaoRepositoryMock.Setup(repo => repo.ListarMovimentacaoEstoque(query.Data))
                                        .Returns(new List<MovimentacaoPecaViewModel>());

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(8, result.TotalPeca); 
            Assert.Equal(11.0, result.PrecoMedio); 
            Assert.Equal(2, result.MovimentacaoPeca.Count);
        }
    }
}
