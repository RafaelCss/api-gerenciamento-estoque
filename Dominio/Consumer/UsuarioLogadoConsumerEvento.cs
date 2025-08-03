using Dominio.Entidades;
using Dominio.Eventos;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Dominio.Consumer
{
    public class UsuarioLogadoConsumerEvento : 
        IConsumer<UsuarioLogadoEvento>
    {
        private readonly ILogger<UsuarioLogadoConsumerEvento> _logger;

        public UsuarioLogadoConsumerEvento(ILogger<UsuarioLogadoConsumerEvento> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<UsuarioLogadoEvento> context)
        {
            _logger.LogInformation($"Produto recebido: {context.Message.Nome}");
            return Task.CompletedTask;
        }
    }

}
