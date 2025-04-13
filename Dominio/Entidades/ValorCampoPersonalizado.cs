namespace Dominio.Entidades;

public class ValorCampoPersonalizado
{
    public int CampoPersonalizadoId { get; set; }
    public CampoPersonalizado Campo { get; set; }
    public int EntidadeId { get; set; }         // Id do Produto, Cliente, etc.
    public string NomeEntidade { get; set; }    // "Produto", "Cliente", etc.
    public string Valor { get; set; }
}
