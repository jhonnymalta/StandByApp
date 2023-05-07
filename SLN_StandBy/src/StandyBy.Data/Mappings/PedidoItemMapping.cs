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
    internal class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(p => p.Id);           
            builder.Property(p => p.ValorTotal).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(navigationExpression: p => p.Pedido);

            builder.ToTable("PedidosItens");



        }
    }
}
