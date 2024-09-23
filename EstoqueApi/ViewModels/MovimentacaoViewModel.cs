namespace EstoqueApi.ViewModels
{
    public class MovimentacaoViewModel
    {
        public int TotalPeca { get; set; }
        public double PrecoMedio { get; set; }
        public List<MovimentacaoPecaViewModel>? MovimentacaoPeca { get; set; }
    }
    public class MovimentacaoPecaViewModel
    {
        public string Nome  { get; set; } = String.Empty;
        public string PartNumber { get; set; } = String.Empty;
        public DateTime DataMovimentacao { get; set; }
        public int Quantidade { get; set; }
        public double Custo { get; set;} 
    }
}
