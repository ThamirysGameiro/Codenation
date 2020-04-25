using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Application.Interface;
using RestauranteCodenation.Application.ViewModel;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao _app;
        public UsuarioController(IUsuarioAplicacao app)
        {
            _app = app;
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] UsuarioViewModel usuario)
        {
            return await _app.Incluir(usuario);
        }

        [HttpPost("Login")]
        public async Task<string> Login(LoginViewModel login)
        {
            return await _app.Login(login);
        }
    }
}