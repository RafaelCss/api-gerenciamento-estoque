using Dominio.Entidade.Base;

namespace Dominio.Entidade;

public class Produto : EntidadeBase
{
    // construtor ef
    public Produto()
    {
    }


    public required string Nome { get; set; }
    public required string Descricao { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }


    
    public Produto(string nome , string descricao , decimal preco , int quantidadeEstoque)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        AtualizarEstoque(quantidadeEstoque);
    }

    public Produto AtualizarEstoque(int quantidade)
    {
        QuantidadeEstoque = quantidade;

        return this;
    }
}
