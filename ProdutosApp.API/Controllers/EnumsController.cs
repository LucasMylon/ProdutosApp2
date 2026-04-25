using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Domain.Enums;

namespace ProdutosApp.API.Controllers
{
    [Route("api/v1/enums")]
    [ApiController]
    public class EnumsController : ControllerBase
    {
        [HttpGet("categorias")]
        public async Task<IActionResult> GetCategoriasAsync()
        {
            var result = Enum.GetValues(typeof(CategoriaProduto))
                            .Cast<CategoriaProduto>()
                            .Select(e => new { Id = (int)e, Name = e.ToString() });
            return Ok(result);

        }
        [HttpGet("status")]
        public async Task<IActionResult> GetStatusAsync()
        {
            var result = Enum.GetValues(typeof(StatusProduto))
                            .Cast<StatusProduto>()
                            .Select(e => new { Id = (int)e, Name = e.ToString() });
            return Ok(result);
        }
    }
}
