using Microsoft.AspNetCore.Identity;
using RestauranteCodenation.Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteCodenation.Data.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsuarioRepositorio(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Incluir(string nome, string email, string senha)
        {
            var usu = new IdentityUser()
            {
                UserName = nome,
                Email = email,
                EmailConfirmed = true
            };

            var retorno = await _userManager.CreateAsync(usu, senha);
           
            return retorno.Succeeded;
        }

        public async Task<IdentityUser> Login(string email, string senha)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            if (usuario != null &&
                await _userManager.CheckPasswordAsync(usuario, senha))
            {
                return usuario;
            }

            return null;
        }
    }
}
