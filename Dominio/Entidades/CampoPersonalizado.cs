using Dominio.Entidades.Root;

namespace Dominio.Entidades;

public class CampoPersonalizado :AggregateRoot
{
    public string? NomeInterno { get; set; }
    public string? Rotulo { get; set; }
    public string? Tipo { get; set; }       
    public string? NomeEntidade { get; set; } 
    public bool Obrigatorio { get; set; }

    // Ef
    public CampoPersonalizado() { }


    public CampoPersonalizado(string nomeInterno , string rotulo , string tipo , string nomeEntidade , bool obrigatorio)
    {
        NomeInterno = nomeInterno;
        Rotulo = rotulo;
        Tipo = tipo;
        NomeEntidade = nomeEntidade;
        Obrigatorio = obrigatorio;
    }

    public CampoPersonalizado AdicionaNomeInterno(string nomeInterno)
    {
        NomeInterno = nomeInterno;

        AddNotifications( Contrato()
            .Requires()
            .IsNotNullOrWhiteSpace(NomeInterno , nameof(NomeInterno) , "O nome interno não pode ser vazio.")
        );

        return this;
    }

}
