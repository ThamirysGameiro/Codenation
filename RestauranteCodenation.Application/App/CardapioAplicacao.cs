using AutoMapper;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;
using System.Collections.Generic;

namespace RestauranteCodenation.Application
{
    public class CardapioAplicacao : ICardapioAplicacao
    {
        private readonly ICardapioRepositorio _repo;
        private readonly IMapper _mapper;

        public CardapioAplicacao(ICardapioRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Alterar(CardapioViewModel entity)
        {
            _repo.Alterar(_mapper.Map<Cardapio>(entity));
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public void Incluir(CardapioViewModel entity)
        {
            _repo.Incluir(_mapper.Map<Cardapio>(entity));
        }

        public CardapioViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<CardapioViewModel>(_repo.SelecionarPorId(id));
        }

        public List<CardapioViewModel> SelecionarTodos()
        {
            return _mapper.Map<List<CardapioViewModel>>(_repo.SelecionarTodos());
        }
    }
}
