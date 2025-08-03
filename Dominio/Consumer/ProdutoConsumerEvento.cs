using Dominio.Entidades;
using Dominio.Eventos;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Dominio.Consumer
{
    public class ProdutoConsumerEvento : IConsumer<ProdutoCriadoEvento>
    {
        private readonly ILogger<ProdutoConsumerEvento> _logger;

        public ProdutoConsumerEvento(ILogger<ProdutoConsumerEvento> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<ProdutoCriadoEvento> context)
        {
            _logger.LogInformation($"Produto recebido: {context.Message.Nome}");
            return Task.CompletedTask;
        }
    }

}
