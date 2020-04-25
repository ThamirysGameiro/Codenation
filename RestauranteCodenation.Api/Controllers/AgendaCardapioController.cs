using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Application;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaCardapioController : ControllerBase
    {
        private readonly IAgendaCardapioAplicacao _app;
        public AgendaCardapioController(IAgendaCardapioAplicacao app)
        {
            _app = app;
        }
                
        [HttpGet]
        public IEnumerable<AgendaCardapioViewModel> Get()
        {
            return _app.SelecionarTodos();
        }
                
        [HttpGet("{id}")]
        public AgendaCardapioViewModel Get(int id)
        {
            return _app.SelecionarPorId(id);
        }
                
        [HttpPost]
        public AgendaCardapioViewModel Post([FromBody] AgendaCardapioViewModel agendaCardapio)
        {
            _app.Incluir(agendaCardapio);
            return agendaCardapio;
        }
                
        [HttpPut]
        public AgendaCardapioViewModel Put([FromBody] AgendaCardapioViewModel agendaCardapio)
        {
            _app.Alterar(agendaCardapio);
            return agendaCardapio;
        }

        [HttpDelete("{id}")]
        public List<AgendaCardapioViewModel> Delete(int id)
        {
            _app.Excluir(id);
            return _app.SelecionarTodos();
        }
    }
}
