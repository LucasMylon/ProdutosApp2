using Microsoft.EntityFrameworkCore;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutosApp.Infra.Data.Repositories
{
    public class ProdutoRepository
    {
        private readonly DataContext context;
        public async Task AdicionarAsync(Produto produto)
        {
            await context.AddAsync(produto);

            await context.SaveChangesAsync();
        }

        public async Task ModificarAsync(Produto produto) 
        {
            context.Update(produto);

            await context.SaveChangesAsync();
        }
        public async Task ExcluirAsync(Produto produto)
        {
            context.Remove(produto);

            await context.SaveChangesAsync();
        }

        public async Task<List<Produto>> ConsultarAsync()
        {
            return await context
                .Set<Produto>()
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

       public async Task<Produto?> ConsultarPorIdAsync(Guid id)
        {
            return await context
                .Set<Produto>()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
