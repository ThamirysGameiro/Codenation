using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestauranteCodenation.Application;
using RestauranteCodenation.Application.App;
using RestauranteCodenation.Application.Interface;
using RestauranteCodenation.Data;
using RestauranteCodenation.Data.Repositorio;
using RestauranteCodenation.Domain.Repositorio;
using System;

namespace RestauranteCodenation.Infra.IoC
{
    public class Bootstrap
    {
        public static void RegistroDeServicos(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<ITipoPratoRepositorio, TipoPratoRepositorio>();
            services.AddScoped<IAgendaCardapioRepositorio, AgendaCardapioRepositorio>();
            services.AddScoped<IAgendaRepositorio, AgendaRepositorio>();
            services.AddScoped<ICardapioRepositorio, CardapioRepositorio>();
            services.AddScoped<IIngredienteRepositorio, IngredienteRepositorio>();
            services.AddScoped<IPratoRepositorio, PratoRepositorio>();
            services.AddScoped<IPratosIngredientesRepositorio, PratosIngredientesRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddScoped<ITipoPratoAplicacao, TipoPratoAplicacao>();
            services.AddScoped<IAgendaCardapioAplicacao, AgendaCardapioAplicacao>();
            services.AddScoped<IAgendaAplicacao, AgendaAplicacao>();
            services.AddScoped<ICardapioAplicacao, CardapioAplicacao>();
            services.AddScoped<IIngredienteAplicacao, IngredienteAplicacao>();
            services.AddScoped<IPratoAplicacao, PratoAplicacao>();
            services.AddScoped<IPratosIngredientesAplicacao, PratosIngredientesAplicacao>();
            services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();

            services.AddDbContext<Contexto>(options =>
           options.UseSqlServer(configuration.GetConnectionString("MinhaConexao")));

            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<Contexto>();
        }
    }
}
