using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPratoController : ControllerBase
    {
        private readonly ITipoPratoRepositorio _repo;
        public TipoPratoController(ITipoPratoRepositorio repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        public IEnumerable<TipoPrato> Get()
        {
            return _repo.SelecionarTodos();
        }

        [HttpGet("{id}")]
        public TipoPrato Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        [HttpPost]
        public TipoPrato Post([FromBody] TipoPrato tipoPrato)
        {
            _repo.Incluir(tipoPrato);
            return tipoPrato;
        }

        [HttpPut("{id}")]
        public TipoPrato Put([FromBody] TipoPrato tipoPrato)
        {
            _repo.Alterar(tipoPrato);
            return tipoPrato;
        }

        [HttpDelete("{id}")]
        public List<TipoPrato> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
