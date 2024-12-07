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

            var produto =  servicoRepository.GetByIdAsync(Guid.Parse("42edd8e8-51f9-4b33-a306-0f67af353a88")).Result;

            servicoRepository.Update(produto);
              _unitOfWork.SaveChanges();

            return Ok(new { id });
        }
    }
}
