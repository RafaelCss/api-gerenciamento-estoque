using Dominio.Entidade;
using Infra.UOW.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public  IActionResult BuscarProdutosAsync([FromQuery] int id)
        {
            var servicoRepository =  _unitOfWork.Repository<Produto>();

              servicoRepository.AddAsync(new Produto("teste", "teste", 300,20));

              _unitOfWork.SaveChanges();

            return Ok(new { id });
        }
    }
}
