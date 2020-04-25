using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Application;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioController : ControllerBase
    {
        private readonly ICardapioAplicacao _app;
        public CardapioController(ICardapioAplicacao app)
        {
            _app = app;
        }
                
        [HttpGet]
        public IEnumerable<CardapioViewModel> Get()
        {
            return _app.SelecionarTodos();
        }

        [HttpGet("{id}")]
        public CardapioViewModel Get(int id)
        {
            return _app.SelecionarPorId(id);
        }

        [HttpPost]
        public CardapioViewModel Post([FromBody] CardapioViewModel cardapio)
        {
            _app.Incluir(cardapio);
            return cardapio;
        }

        [HttpPut("{id}")]
        public CardapioViewModel Put([FromBody] CardapioViewModel cardapio)
        {
            _app.Alterar(cardapio);
            return cardapio;
        }

        [HttpDelete("{id}")]
        public List<CardapioViewModel> Delete(int id)
        {
            _app.Excluir(id);
            return _app.SelecionarTodos();
        }
    }
}
