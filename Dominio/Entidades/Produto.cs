

using Dominio.Comandos.Cadastro;
using Dominio.Entidades.Base;
using Dominio.Entidades.Root;
using Flunt.Validations;

namespace Dominio.Entidades;

public class Produto : AggregateRoot
{
    // construtor ef
    public Produto()
    {
    }

    public Produto(string nome , string descricao , decimal preco , int quantidadeEstoque)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        AtualizarEstoque(quantidadeEstoque);
    }

    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }




    public Produto AtualizarEstoque(int quantidade)
    {
        QuantidadeEstoque = quantidade;


        //Exemplo Notificação na entidade -- 
        AddNotifications(new Contract<Produto>()
            .Requires()
            .IsNotNullOrWhiteSpace(Nome , nameof(Nome) , "O nome não pode ser vazio.")
            .IsEmail(Nome , nameof(Nome) , "O e-mail fornecido é inválido.")
        );

        return this;
    }
}
