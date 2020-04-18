﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestauranteCodenation.Data.Map;
using RestauranteCodenation.Domain;

namespace RestauranteCodenation.Data
{
    public class Contexto : IdentityDbContext
    {
        public DbSet<Cardapio> Cardapio { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<Prato> Prato { get; set; }
        public DbSet<TipoPrato> TipoPrato { get; set; }
        public DbSet<Agenda> DiaCardapio { get; set; }
        public DbSet<PratosIngredientes> PratosIngredientes { get; set; }
        public DbSet<AgendaCardapio> AgendaCardapio { get; set; }

        public Contexto(DbContextOptions<Contexto> options)
             : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IngredienteMap());
            modelBuilder.ApplyConfiguration(new PratoMap());
            modelBuilder.ApplyConfiguration(new PratosIngredientesMap());
            modelBuilder.ApplyConfiguration(new TipoPratoMap());
            modelBuilder.ApplyConfiguration(new AgendaCardapioMap());
            modelBuilder.ApplyConfiguration(new AgendaMap());
            modelBuilder.ApplyConfiguration(new CardapioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
