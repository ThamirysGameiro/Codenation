using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaRepositorio _repo;
        public AgendaController(IAgendaRepositorio repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        public IEnumerable<Agenda> Get()
        {
            return _repo.SelecionarTodos();
        }

        [HttpGet("{id}")]
        public Agenda Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        [HttpPost]
        public Agenda Post([FromBody] Agenda agenda)
        {
            _repo.Incluir(agenda);
            return agenda;
        }

        [HttpPut]
        public Agenda Put([FromBody] Agenda agenda)
        {
            _repo.Alterar(agenda);
            return agenda;
        }

        [HttpDelete("{id}")]
        public List<Agenda> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
