using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StandBy.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandyBy.Data.Mappings
{
    internal class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Codigo).IsRequired().HasColumnType("nvarchar(10)");
            builder.Property(p => p.Descricao).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(p => p.Valor).IsRequired().HasColumnType("decimal(18,2)");

            builder.ToTable("Produtos");



        }
    }
}
