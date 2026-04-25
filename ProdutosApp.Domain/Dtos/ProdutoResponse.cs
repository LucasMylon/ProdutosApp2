using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutosApp.Domain.Dtos
{
    public class ProdutoResponse
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public EnumDto? Categoria { get; set; }
        public EnumDto? Status { get; set; }
    }
    public class EnumDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }
}
