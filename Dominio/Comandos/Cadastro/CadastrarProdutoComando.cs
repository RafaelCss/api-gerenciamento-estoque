using Dominio.Comandos.ComandoBase;
using Dominio.Entidades;
using Dominio.Interface;
using Dominio.Respostas;
using MediatR;

namespace Dominio.Comandos.Cadastro;

public class CadastrarProdutoComando : Comando<Guid>
{
    public string Nome { get; private set; }
    public string Email { get; private set; }

    public CadastrarProdutoComando(string nome , string email)
    {
        Nome = nome;
        Email = email;

        AddNotifications(new Flunt.Validations.Contract<CadastrarProdutoComando>()
            .Requires()
            .IsNotNullOrWhiteSpace(Nome , nameof(Nome) , "O nome não pode ser vazio.")
            .IsEmail(Email , nameof(Email) , "O e-mail fornecido é inválido.")
        );
    }


    /// <summary>
    /// Método estático para criar e executar o comando.
    /// </summary>
    /// <param name="mediator">Instância do IMediator.</param>
    /// <param name="nome">Nome do usuário.</param>
    /// <param name="email">E-mail do usuário.</param>
    /// <param name="cancellationToken">Token de cancelamento.</param>
    /// <returns>Retorna a resposta do comando.</returns>
    public static async Task<Resposta<Guid>> ExecutarAsync(
        IMediator mediator ,
        string nome ,
        string email ,
        CancellationToken cancellationToken)
    {
        var comando = new CadastrarProdutoComando(nome , email);
        return await mediator.Send(comando , cancellationToken);
    }
}

public class CadastrarProdutoComandoHandler : ComandoHandler<CadastrarProdutoComando , Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CadastrarProdutoComandoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public override async Task<Resposta<Guid>> Handle(CadastrarProdutoComando request , CancellationToken cancellationToken)
    {
        if (!request.IsValid)
            return CriarResposta(request.Notifications);


        var produto = new Produto("Teste Comando"," testando", 30 , 20);

        await _unitOfWork.Repositorio<Produto>().AddAsync(produto);

        if (await _unitOfWork.SaveChangesAsync(cancellationToken) < 0)
        {
            request.AddNotification("Commit" , "Erro ao salvar os dados no banco.");
            return CriarResposta(request.Notifications);
        }

        return new Resposta<Guid>(produto.Id);
    }
}