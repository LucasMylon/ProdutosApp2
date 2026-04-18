using Microsoft.EntityFrameworkCore;
using ProdutosApp.Infra.Data.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutosApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions <DataContext> context) : base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
        }
        
        
    }
}
