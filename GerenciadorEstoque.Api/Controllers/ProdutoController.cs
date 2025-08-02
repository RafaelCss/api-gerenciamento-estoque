

using Dominio.Comandos.Cadastro;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modelos.Models.Request.Produtos;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProdutoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarProdutosAsync([FromBody] ProdutosRequestModel produtosRequest,CancellationToken cancellationToken)
    {
        var resposta = await CadastrarProdutoComando.ExecutarAsync(_mediator ,  produtosRequest, cancellationToken);
        return Ok(resposta);
    }
}
    