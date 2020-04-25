using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Application;

namespace RestauranteCodenation.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly IIngredienteAplicacao _app;
        public IngredienteController(IIngredienteAplicacao app)
        {
            _app = app;
        }        
        
        [HttpGet]
        public IEnumerable<IngredienteViewModel> Get()
        {
            return _app.SelecionarTodos();
        }
                
        [HttpGet("{id}")]
        public IngredienteViewModel Get(int id)
        {
            return _app.SelecionarPorId(id);
        }
                
        [HttpPost]
        public IngredienteViewModel Post([FromBody] IngredienteViewModel ingrediente)
        {
            _app.Incluir(ingrediente);
            return ingrediente;
        }

        [HttpPut]
        public IngredienteViewModel Put([FromBody] IngredienteViewModel ingrediente)
        {
            _app.Alterar(ingrediente);
            return ingrediente;
        }
                
        [HttpDelete("{id}")]
        public List<IngredienteViewModel> Delete(int id)
        {
            _app.Excluir(id);
            return _app.SelecionarTodos();
        }
    }
}
