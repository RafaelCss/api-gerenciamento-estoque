using Dominio.Comandos.ComandoBase;
using Dominio.Entidades;
using Dominio.Interface;
using Dominio.Respostas;
using MediatR;
using Modelos.Models.Request.Produtos;

namespace Dominio.Comandos.Cadastro;

public class CadastrarProdutoComando : Comando<Guid>
{
    
    public ProdutosRequestModel ProdutosRequest { get; private set; }

    public CadastrarProdutoComando(ProdutosRequestModel produtosRequest)
    {
        ProdutosRequest = produtosRequest;
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
        ProdutosRequestModel produtosRequest,
        CancellationToken cancellationToken)
    {
        var comando = new CadastrarProdutoComando(produtosRequest);
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
            return new Resposta<Guid>(request.Notifications);


        var produto = new Produto(request.ProdutosRequest.Nome, request.ProdutosRequest.Descricao, request.ProdutosRequest.CodigoBarras);

        if (!produto.IsValid)
        {
            return new Resposta<Guid>(produto.Notifications);
        }

        await _unitOfWork.Repositorio<Produto>().AddAsync(produto);

        if (await _unitOfWork.SalvarAsync(cancellationToken) < 0)
        {
            produto.AddNotification("Commit" , "Erro ao salvar os dados no banco.");
              return new Resposta<Guid>(produto.Notifications);
        }

        return new Resposta<Guid>(produto.Id);
    }
}