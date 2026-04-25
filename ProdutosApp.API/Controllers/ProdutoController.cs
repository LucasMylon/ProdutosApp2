using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Domain.Dtos;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Enums;
using ProdutosApp.Infra.Data.Repositories;

namespace ProdutosApp.API.Controllers
{
    [Route("api/v1/produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutosController(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProdutoRequest request)
        {
            var produto = new Produto
            {
                Nome = request.Nome!,
                Preco = request.Preco!.Value,
                Quantidade = request.Quantidade!.Value,
                Categoria = (CategoriaProduto)request.Categoria!.Value,
                Status = (StatusProduto)request.Status!.Value
            };

            await _produtoRepository.AdicionarAsync(produto);

            return StatusCode(201, new { mensagem = "Produto cadastrado com sucesso.", produto = ToResponse(produto) });
        }

        private ProdutoResponse ToResponse(Produto produto)
        {
            return new ProdutoResponse
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                Total = produto.Preco * produto.Quantidade,
                DataHoraCadastro = produto.DataHoraCadastro,
                Categoria = new EnumDto
                {
                    Id = (int)produto.Categoria,
                    Nome = produto.Categoria.ToString()
                },
                Status = new EnumDto
                {
                    Id = (int)produto.Status,
                    Nome = produto.Status.ToString()
                }
            };
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutAsync(Guid Id, [FromBody] ProdutoRequest request)
        {

            var produto = await _produtoRepository.ConsultarPorIdAsync(Id);

            if (produto == null)
            {
                return NotFound(new { mensagem = "Produto não encontrado." });
            }

            produto.Nome = request.Nome!;
            produto.Preco = request.Preco!.Value;
            produto.Quantidade = request.Quantidade!.Value;
            produto.Categoria = (CategoriaProduto)request.Categoria!.Value;
            produto.Status = (StatusProduto)request.Status!.Value;

            await _produtoRepository.ModificarAsync(produto);

            return Ok(new { mensagem = "Produto atualizado com sucesso.", produto = ToResponse(produto) });
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var produto = await _produtoRepository.ConsultarPorIdAsync(Id);

            if (produto == null)
            {
                return NotFound(new { mensagem = "Produto não encontrado." });
            }
            await _produtoRepository.ExcluirAsync(produto);
            return Ok(new
            {
                mensagem = "Produto excluído com sucesso.",
                produto = ToResponse(produto)
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var produtos = await _produtoRepository.ConsultarAsync();
            var response = produtos.Select(p => ToResponse(p)).ToList();
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var produto = await _produtoRepository.ConsultarPorIdAsync(Id);

            if (produto == null)
            {
                return NotFound(new { mensagem = "Produto não encontrado." });
            }
            return Ok(ToResponse(produto));
        }
    }
}
