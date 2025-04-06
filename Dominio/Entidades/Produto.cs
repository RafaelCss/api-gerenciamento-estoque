using Dominio.Entidades.Root;
using Flunt.Validations;

namespace Dominio.Entidades;

public class Produto : AggregateRoot
{
    // construtor ef
    public Produto()
    {
    }

    public Produto(string nome , string descricao , string codigoBarras)
    {
        AdicionarNomeProduto(nome);
        AdicionarDescricaoProduto(descricao);
        AdicionarCodigoBarrasProduto(codigoBarras);
    }

    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public string CodigoBarras { get; private set; }


    public Produto AdicionarNomeProduto(string nome)
    {
        Nome = nome;

        AddNotifications(new Contract<Produto>()
            .Requires()
            .IsNotNullOrWhiteSpace(Nome , nameof(Nome) , "O nome não pode ser vazio.")
        );

        return this;
    }

    public Produto AdicionarDescricaoProduto(string descricao)
    {
        Descricao = descricao;

        AddNotifications(new Contract<Produto>()
            .Requires()
            .IsNotNullOrWhiteSpace(Descricao , nameof(Descricao) , "A Descricao não pode ser vazia.")
        );

        return this;
    }


    public Produto AdicionarCodigoBarrasProduto(string codigoBarras)
    {

        CodigoBarras = codigoBarras;
        AddNotifications(new Contract<Produto>()
            .Requires()
            .IsNotNullOrWhiteSpace(CodigoBarras , nameof(CodigoBarras) , "O Codigo de Barras não pode ser vazio.")
        );

        return this;
    }

    public Produto Modificar(string nome , string descricao , string codigoBarras)
    {
        AdicionarNomeProduto(nome);
        AdicionarDescricaoProduto(descricao);
        AdicionarCodigoBarrasProduto(codigoBarras);

        return this;    
    }
}
