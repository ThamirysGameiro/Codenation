using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaCardapioController : ControllerBase
    {
        private readonly IAgendaCardapioRepositorio _repo;
        public AgendaCardapioController(IAgendaCardapioRepositorio repo)
        {
            _repo = repo;
        }
                
        [HttpGet]
        public IEnumerable<AgendaCardapio> Get()
        {
            return _repo.SelecionarTodos();
        }
                
        [HttpGet("{id}")]
        public AgendaCardapio Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }
                
        [HttpPost]
        public AgendaCardapio Post([FromBody] AgendaCardapio agendaCardapio)
        {
            _repo.Incluir(agendaCardapio);
            return agendaCardapio;
        }
                
        [HttpPut]
        public AgendaCardapio Put([FromBody] AgendaCardapio agendaCardapio)
        {
            _repo.Alterar(agendaCardapio);
            return agendaCardapio;
        }

        [HttpDelete("{id}")]
        public List<AgendaCardapio> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
