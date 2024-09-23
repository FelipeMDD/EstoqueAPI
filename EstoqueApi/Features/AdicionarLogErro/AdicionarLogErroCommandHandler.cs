using EstoqueApi.Models;
using EstoqueApi.Repositories;

namespace EstoqueApi.Features.AdicionarLogErro
{
    public class AdicionarLogErroCommandHandler
    {
        private readonly LogErroRepository _logErroRepository;
        public AdicionarLogErroCommandHandler(LogErroRepository logErroRepository)
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
