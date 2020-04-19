using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestauranteCodenation.Application;
using RestauranteCodenation.Application.App;
using RestauranteCodenation.Application.Interface;
using RestauranteCodenation.Application.Mapper;
using RestauranteCodenation.Application.ViewModel;
using RestauranteCodenation.Data;
using RestauranteCodenation.Data.Repositorio;
using RestauranteCodenation.Domain.Repositorio;
using System.Text;

namespace RestauranteCodenation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = 
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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

            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddSwaggerGen(x => x.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Restaurante da Thamy", Version = "v1" }));

            services.AddDbContext<Contexto>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MinhaConexao")));

            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<Contexto>();

            var section = Configuration.GetSection("Token");
            services.Configure<Token>(section);

            var token = section.Get<Token>();
            var key = Encoding.ASCII.GetBytes(token.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = token.ValidoEm,
                    ValidIssuer = token.Emissor
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api da Thamy");
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
