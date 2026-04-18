using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutosApp.Infra.Data.Maps
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTOS");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired().HasColumnName("ID");

            builder.Property(p => p.Nome).IsRequired().HasColumnName("NOME").HasMaxLength(100);

            builder.Property(p => p.Preco).IsRequired().HasColumnName("PRECO").HasColumnType("DECIMAL(10,2)");

            builder.Property(p => p.Quantidade).IsRequired().HasColumnName("QUANTIDADE");

            builder.Property(p => p.DataHoraCadastro).IsRequired().HasColumnName("DATAHORACADASTRO");

            builder.Property(p => p.Status).IsRequired().HasColumnName("STATUS");

            builder.Property(p => p.Categoria).IsRequired().HasColumnName("CATEGORIA");

            builder.HasIndex(p => p.Nome).IsUnique();




        }
    }
}
