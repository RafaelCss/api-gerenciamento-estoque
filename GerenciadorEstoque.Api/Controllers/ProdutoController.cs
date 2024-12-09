
using Dominio.Entidades;
using Infra.Repositorio.Interface;
using Infra.UOW.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IContextoLeitura<Produto> _contexto;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoController(IContextoLeitura<Produto> contexto, IUnitOfWork unitOfWork)
        {
            _contexto = contexto;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public  IActionResult BuscarProdutosAsync([FromQuery] Guid id)
        {
             var servicoRepository = _contexto.Query().FirstOrDefault(p => p.Id.Equals(id));

            //var servicoRepository = _unitOfWork.Repositorio<Produto>().GetByIdAsync(id).Result;

            return Ok(servicoRepository);
        }
    }
}
