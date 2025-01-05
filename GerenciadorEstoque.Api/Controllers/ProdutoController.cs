
using Dominio.Comandos.Cadastro;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> CadastrarProdutosAsync(CancellationToken cancellationToken)
    {
        var resposta = await CadastrarProdutoComando.ExecutarAsync(_mediator , "teste" , "teste@teste.com.br" , CancellationToken.None);
        return Ok(resposta);
    }
}
    