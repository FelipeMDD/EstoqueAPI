namespace EstoqueApi.Models
{
    public class Estoque
    {
        public int EstoqueID { get; set; }
        public int ProdutoID { get; set; }
        public int? QuantidadeDisponivel { get; set; }
    }
}
