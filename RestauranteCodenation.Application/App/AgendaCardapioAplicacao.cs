using AutoMapper;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;
using System.Collections.Generic;

namespace RestauranteCodenation.Application
{
    public class AgendaCardapioAplicacao : IAgendaCardapioAplicacao
    {
        private readonly IAgendaCardapioRepositorio _repo;
        private readonly IMapper _mapper;
        public AgendaCardapioAplicacao(IAgendaCardapioRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Alterar(AgendaCardapioViewModel entity)
        {
            _repo.Alterar(_mapper.Map<AgendaCardapio>(entity));
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public void Incluir(AgendaCardapioViewModel entity)
        {
            _repo.Incluir(_mapper.Map<AgendaCardapio>(entity));
        }

        public AgendaCardapioViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<AgendaCardapioViewModel>(_repo.SelecionarPorId(id));
        }

        public List<AgendaCardapioViewModel> SelecionarTodos()
        {
            return _mapper.Map<List<AgendaCardapioViewModel>>(_repo.SelecionarTodos());
        }
    }
}
