using Flunt.Notifications;

namespace Dominio.Respostas;

public class Resposta<T>
{
    public T Data { get; }
    public IReadOnlyCollection<Notification> Notifications { get; }
    public bool Invalid => Notifications?.Count > 0;

    public Resposta(T data)
    {
        Data = data;
    }

    public Resposta(IReadOnlyCollection<Notification> notifications)
    {
        Notifications = notifications;
    }
}
