using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioController : ControllerBase
    {
        private readonly ICardapioRepositorio _repo;
        public CardapioController(ICardapioRepositorio repo)
        {
            _repo = repo;
        }
                
        [HttpGet]
        public IEnumerable<Cardapio> Get()
        {
            return _repo.SelecionarTodos();
        }

        [HttpGet("{id}")]
        public Cardapio Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        [HttpPost]
        public Cardapio Post([FromBody] Cardapio cardapio)
        {
            _repo.Incluir(cardapio);
            return cardapio;
        }

        [HttpPut("{id}")]
        public Cardapio Put([FromBody] Cardapio cardapio)
        {
            _repo.Alterar(cardapio);
            return cardapio;
        }

        [HttpDelete("{id}")]
        public List<Cardapio> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
