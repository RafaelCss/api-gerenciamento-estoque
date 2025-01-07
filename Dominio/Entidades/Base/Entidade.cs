using Flunt.Notifications;

namespace Dominio.Entidades.Base;

public class Entidade : Notifiable<Notification>
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;
}
