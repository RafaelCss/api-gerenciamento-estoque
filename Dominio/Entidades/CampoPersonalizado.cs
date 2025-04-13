namespace Dominio.Entidades;

public class CampoPersonalizado
{
    public int Id { get; set; }
    public string NomeInterno { get; set; }     // "nomeVendedor"
    public string Rotulo { get; set; }          // "Nome do Vendedor"
    public string Tipo { get; set; }            // "string", "int", "bool", "date", etc.
    public string NomeEntidade { get; set; }    // "Produto", "Cliente", etc.
    public bool Obrigatorio { get; set; }
}
