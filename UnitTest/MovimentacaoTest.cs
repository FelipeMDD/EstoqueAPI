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
        private readonly Mock<IEstoqueRepository> _estoqueRepositoryMock;
        private readonly ListarMovimentacaoQueryHandler _handler;

        public ListarMovimentacaoQueryHandlerTests()
        {
            _movimentacaoRepositoryMock = new Mock<IMovimentacaoEstoqueRepository>();
            _estoqueRepositoryMock = new Mock<IEstoqueRepository>();
            _handler = new ListarMovimentacaoQueryHandler(_movimentacaoRepositoryMock.Object);
        }

        [Fact]
        public async Task ReturnViewModelVazia()
        {
            var query = new ListarMovimentacaoQuery ( DateTime.Now ); 
            _movimentacaoRepositoryMock.Setup(repo => repo.ListarMovimentacaoEstoque(query.Data))
                                        .Returns(new List<MovimentacaoPecaViewModel>()); 

            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.Equal(0, result.TotalPeca);
            Assert.Equal(0, result.PrecoMedio);
            Assert.Empty(result.MovimentacaoPeca);
        }

        [Fact]
        public async Task ReturnViewModel()
        {
            var query = new ListarMovimentacaoQuery (DateTime.Now);
            var movimentacaoList = new List<MovimentacaoPecaViewModel>
            {
                new MovimentacaoPecaViewModel { Quantidade = 5, Custo = 10, DataMovimentacao = DateTime.Now },
                new MovimentacaoPecaViewModel { Quantidade = 3, Custo = 12, DataMovimentacao = DateTime.Now }
            };

            _movimentacaoRepositoryMock.Setup(repo => repo.ListarMovimentacaoEstoque(query.Data))
                                        .Returns(movimentacaoList);

            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.Equal(8, result.TotalPeca); 
            Assert.Equal(2.75, result.PrecoMedio); 
            Assert.Equal(2, result.MovimentacaoPeca.Count);
        }
    }
}
