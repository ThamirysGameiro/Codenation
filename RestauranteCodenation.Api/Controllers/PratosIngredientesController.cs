using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratosIngredientesController : ControllerBase
    {
        private readonly IPratosIngredientesRepositorio _repo;
        public PratosIngredientesController(IPratosIngredientesRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<PratosIngredientes> Get()
        {
            return _repo.SelecionarCompleto();
        }

        [HttpGet("{id}")]
        public PratosIngredientes Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        [HttpPost]
        public PratosIngredientes Post([FromBody] PratosIngredientes pratosIngredientes)
        {
            _repo.Incluir(pratosIngredientes);
            return pratosIngredientes;
        }

        [HttpPut]
        public PratosIngredientes Put([FromBody] PratosIngredientes pratosIngredientes)
        {
            _repo.Alterar(pratosIngredientes);
            return pratosIngredientes;
        }

        [HttpDelete("{id}")]
        public List<PratosIngredientes> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
