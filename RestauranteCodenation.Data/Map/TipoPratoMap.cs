using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteCodenation.Domain;

namespace RestauranteCodenation.Data.Map
{
    public class TipoPratoMap : IEntityTypeConfiguration<TipoPrato>
    {
        public void Configure(EntityTypeBuilder<TipoPrato> builder)
        {
            builder.ToTable("TipoPrato");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.HasMany<Prato>(p => p.Pratos)
                .WithOne(t => t.TipoPrato)
                .HasForeignKey(t => t.IdTipoPrato);
        }
    }
}
