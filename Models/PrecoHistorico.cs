namespace EstoqueApi.Models
{
    public class PrecoHistorico
    {
        public int PrecoHistoricoID { get; set; }
        public int ProdutoID { get; set; }
        public double PrecoAntigo { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
