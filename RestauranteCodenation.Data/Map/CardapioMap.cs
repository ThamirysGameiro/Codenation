using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteCodenation.Domain;

namespace RestauranteCodenation.Data.Map
{
    public class CardapioMap : IEntityTypeConfiguration<Cardapio>
    {
        public void Configure(EntityTypeBuilder<Cardapio> builder)
        {
            builder.ToTable("Cardapio");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
              .HasColumnType("varchar(100)")
              .IsRequired();

            builder.Property(x => x.Descricao)
             .HasColumnType("varchar(500)");             
        }
    }
}
