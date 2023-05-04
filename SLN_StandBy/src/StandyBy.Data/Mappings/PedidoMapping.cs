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
    internal class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Valor).IsRequired().HasColumnType("decimal(18,2)");

            // builder.HasOne(navigationExpression: p => p.Cliente).WithOne(navigationExpression: c => c.Pedido);
            builder.HasOne(navigationExpression: p => p.Cliente).WithMany(navigationExpression: c => c.Pedido)
                .HasForeignKey(p => p.ClienteId);

            builder.HasMany(navigationExpression: p => p.PedidosItens).WithOne(navigationExpression: c => c.Pedido)
                .HasForeignKey(c => c.PedidoId);



            builder.ToTable("Pedidos");



        }
    }
}
