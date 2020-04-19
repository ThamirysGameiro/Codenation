using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace RestauranteCodenation.Domain.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<bool> Incluir(string login, string email, string senha);
        Task<IdentityUser> Login(string email, string senha);
    }
}
