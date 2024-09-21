namespace EstoqueApi.Models
{
    public class LogErro
    {
        public int LogID { get; set; }
        public string Texto { get; set; } = String.Empty;
        public string EndPoint { get; set; } = String.Empty ;
    }
}
