using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteCodenation.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteCodenation.Data.Map
{
    public class PratoMap : IEntityTypeConfiguration<Prato>
    {
        public void Configure(EntityTypeBuilder<Prato> builder)
        {
            builder.ToTable("Prato");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(x => x.Descricao)
               .HasColumnType("varchar(500)")
               .IsRequired();

            builder.Property(x => x.Preco)
               .HasColumnType("decimal(18,2)")
               .IsRequired();
        }
    }
}
