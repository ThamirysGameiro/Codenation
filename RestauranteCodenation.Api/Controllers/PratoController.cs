using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratoController : ControllerBase
    {
        private readonly IPratoRepositorio _repo;
        public PratoController(IPratoRepositorio repo)
        {
            _repo = repo;
        }
               
        [HttpGet]
        public IEnumerable<Prato> Get()
        {
            return _repo.SelecionarTodos();
        }

        [HttpGet("{id}")]
        public Prato Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        [HttpPost]
        public Prato Post([FromBody] Prato prato)
        {
            _repo.Incluir(prato);
            return prato;
        }

        [HttpPut]
        public Prato Put([FromBody] Prato prato)
        {
            _repo.Alterar(prato);
            return prato;
        }

        [HttpDelete("{id}")]
        public IEnumerable<Prato> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
