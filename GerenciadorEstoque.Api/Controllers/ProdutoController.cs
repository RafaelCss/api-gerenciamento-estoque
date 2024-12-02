using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IActionResult BuscarProdutos([FromQuery] int id)
        {
            return Ok(new { id });
        }
    }
}
