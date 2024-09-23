using EstoqueApi.Models;

namespace EstoqueApi.Interfaces
{
    public interface ILogErroRepository
    {
        IEnumerable<LogErro> ListarLogErro();
        Task<bool> InsereLogErroAsync(LogErro logErro);
    }
}
