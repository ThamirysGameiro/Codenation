using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Application;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaAplicacao _app;
        public AgendaController(IAgendaAplicacao app)
        {
            _app = app;
        }
        
        [HttpGet]
        public IEnumerable<AgendaViewModel> Get()
        {
            return _app.SelecionarTodos();
        }

        [HttpGet("{id}")]
        public AgendaViewModel Get(int id)
        {
            return _app.SelecionarPorId(id);
        }

        [HttpPost]
        public AgendaViewModel Post([FromBody] AgendaViewModel agenda)
        {
            _app.Incluir(agenda);
            return agenda;
        }

        [HttpPut]
        public AgendaViewModel Put([FromBody] AgendaViewModel agenda)
        {
            _app.Alterar(agenda);
            return agenda;
        }

        [HttpDelete("{id}")]
        public List<AgendaViewModel> Delete(int id)
        {
            _app.Excluir(id);
            return _app.SelecionarTodos();
        }
    }
}
