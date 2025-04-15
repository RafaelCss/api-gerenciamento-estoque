using Flunt.Notifications;
using Flunt.Validations;

namespace Dominio.Entidades.Base;

public class Entidade : Notifiable<Notification>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;
    public Contract<Entidade> Contrato()
    {
        var contract = new Contract<Entidade>();

        return contract;
    }
}
