using Flunt.Notifications;

namespace Dominio.Respostas;

public class Resposta<T>
{
    public T Data { get; }
    public IReadOnlyCollection<Notification> Erros { get; }
    public bool Invalid => Erros?.Count > 0;

    public Resposta(T data)
    {
        Data = data;
    }

    public Resposta(IReadOnlyCollection<Notification> erros)
    {
        Erros = erros;
    }
}
