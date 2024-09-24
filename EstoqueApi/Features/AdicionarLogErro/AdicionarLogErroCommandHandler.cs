using EstoqueApi.Interfaces;
using EstoqueApi.Models;
using EstoqueApi.Repositories;

namespace EstoqueApi.Features.AdicionarLogErro
{
    public class AdicionarLogErroCommandHandler
    {
        private readonly ILogErroRepository _logErroRepository;
        public AdicionarLogErroCommandHandler(ILogErroRepository logErroRepository)
        {
            _logErroRepository = logErroRepository;
        }
        public async Task<LogErro> Handle(AdicionarLogErroCommand request, CancellationToken cancellationToken)
        {
            var logErro = new LogErro
            {
                Texto = request.Texto,
                EndPoint = request.EndPoint
            };

            await _logErroRepository.InsereLogErroAsync(logErro);
            return logErro;
        }

    }
}
