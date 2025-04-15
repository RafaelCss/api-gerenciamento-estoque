using Dominio.Entidades.Root;
using Flunt.Validations;

namespace Dominio.Entidades;

public class CampoPersonalizado :AggregateRoot
{
    public string NomeInterno { get; set; }     // "nomeVendedor"
    public string Rotulo { get; set; }          // "Nome do Vendedor"
    public string Tipo { get; set; }            // "string", "int", "bool", "date", etc.
    public string NomeEntidade { get; set; }    // "Produto", "Cliente", etc.
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
