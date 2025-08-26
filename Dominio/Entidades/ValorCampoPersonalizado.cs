using Dominio.Entidades.Base;

namespace Dominio.Entidades;

public class ValorCampoPersonalizado: Entidade
{
    #region Construtor EF
    protected ValorCampoPersonalizado()
    {
    }
    #endregion
    public virtual CampoPersonalizado? Campo { get; set; }
    public Guid CampoId { get; set; }
    public string? NomeEntidade { get; set; }
    public decimal Valor { get; set; }

    public ValorCampoPersonalizado(CampoPersonalizado campoPersonalizado, Guid campoId, string nomeEntidade, decimal valor)
    {
        Campo = campoPersonalizado;
        CampoId = campoId;
        NomeEntidade = nomeEntidade;
        Valor = valor;
    }
}
