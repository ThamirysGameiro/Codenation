using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Application;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPratoController : ControllerBase
    {
        private readonly ITipoPratoAplicacao _app;
        public TipoPratoController(ITipoPratoAplicacao app)
        {
            _app = app;
        }

        [HttpGet]
        public IEnumerable<TipoPratoViewModel> Get()
        {
            return _app.SelecionarTodos();
        }

        [HttpGet("{id}")]
        public TipoPratoViewModel Get(int id)
        {
            return _app.SelecionarPorId(id);
        }

        [HttpPost]
        public TipoPratoViewModel Post([FromBody] TipoPratoViewModel tipoPrato)
        {
            _app.Incluir(tipoPrato);
            return tipoPrato;
        }

        [HttpPut("{id}")]
        public TipoPratoViewModel Put([FromBody] TipoPratoViewModel tipoPrato)
        {
            _app.Alterar(tipoPrato);
            return tipoPrato;
        }

        [HttpDelete("{id}")]
        public List<TipoPratoViewModel> Delete(int id)
        {
            _app.Excluir(id);
            return _app.SelecionarTodos();
        }
    }
}
