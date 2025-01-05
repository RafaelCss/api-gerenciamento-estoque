
using Dominio.Respostas;
using Flunt.Notifications;
using MediatR;

namespace Dominio.Comandos.ComandoBase;

public abstract class Comando<TResposta> : Notifiable<Notification>, IRequest<Resposta<TResposta>>
{
   protected Comando() { }
}
