using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Enums;
using ProdutosApp.Infra.Data.Repositories;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync(
                [FromQuery] string nome,
                [FromQuery] decimal preco,
                [FromQuery] int quantidade,
                [FromQuery] int categoria,
                [FromQuery] int status
            )
        {
            var produto = new Produto
            {
                Nome = nome,
                Preco = preco,
                Quantidade = quantidade,
                Categoria = (CategoriaProduto)categoria,
                Status = (StatusProduto)status
            };

            var produtoRepository = new ProdutoRepository();
            await produtoRepository.AdicionarAsync(produto);

            return StatusCode(201, new { mensagem = "Produto cadastrado com sucesso." });
        }
    }
}
