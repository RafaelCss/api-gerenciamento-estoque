namespace Dominio.Entidades;

public class ValorCampoPersonalizado
{
    public int CampoPersonalizadoId { get; set; }
    public CampoPersonalizado Campo { get; set; }
    public int EntidadeId { get; set; }      
    public string NomeEntidade { get; set; }    
    public decimal Valor { get; set; }
}
