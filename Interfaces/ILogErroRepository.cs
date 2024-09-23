using EstoqueApi.Models;

namespace EstoqueApi.Interfaces
{
    public interface ILogErroRepository
    {
        IEnumerable<LogErro> ListarLogErro();
        Task InsereLogErroAsync(LogErro logErro);
    }
}
