namespace EstoqueApi.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string PartNumber { get; set;} = string.Empty;
        public double PrecoMedioCusto { get; set; }
    }
}
