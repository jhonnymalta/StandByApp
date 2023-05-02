
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
    internal class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CpfCnpj).IsRequired().HasColumnType("nvarchar(14)");
            builder.Property(p => p.Nome).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(p => p.Ativo).IsRequired().HasColumnType("bit");

            builder.ToTable("Clientes");



        }
    }
}
