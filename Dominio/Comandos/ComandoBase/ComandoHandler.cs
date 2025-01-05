using Dominio.Respostas;
using MediatR;

namespace Dominio.Comandos.ComandoBase;

public abstract class ComandoHandler<TComando, TResposta> : IRequestHandler<TComando , Resposta<TResposta>>
    where TComando : Comando<TResposta>
{
    public abstract Task<Resposta<TResposta>> Handle(TComando request , CancellationToken cancellationToken);

    protected Resposta<TResposta> CriarResposta(IReadOnlyCollection<Flunt.Notifications.Notification> notifications)
    {
        return new Resposta<TResposta>(notifications);
    }
}