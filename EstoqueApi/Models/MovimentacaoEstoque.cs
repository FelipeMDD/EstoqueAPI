using EstoqueApi.Models.Enum;

namespace EstoqueApi.Models
{
    public class MovimentacaoEstoque
    {
        public int MovimentacaoID { get; set; }
        public int ProdutoID { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public int QuantidadeMovimentada { get; set; }
        public TipoMovimentacao TipoMovimentacao { get; set; } 
        public double? CustoMovimentacao { get; set; }
    }
}
