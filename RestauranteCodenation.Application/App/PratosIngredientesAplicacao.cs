using AutoMapper;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;
using System.Collections.Generic;

namespace RestauranteCodenation.Application
{
    public class PratosIngredientesAplicacao : IPratosIngredientesAplicacao
    {
        private readonly IPratosIngredientesRepositorio _repo;
        private readonly IMapper _mapper;
        public PratosIngredientesAplicacao(IPratosIngredientesRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
       
        public void Alterar(PratosIngredientesViewModel entity)
        {
            _repo.Alterar(_mapper.Map<PratosIngredientes>(entity));
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public void Incluir(PratosIngredientesViewModel entity)
        {
            _repo.Incluir(_mapper.Map<PratosIngredientes>(entity));
        }

        public List<PratosIngredientesViewModel> SelecionarCompleto()
        {
            return _mapper.Map<List<PratosIngredientesViewModel>>(_repo.SelecionarCompleto());
        }

        public PratosIngredientesViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<PratosIngredientesViewModel>(_repo.SelecionarPorId(id));
        }

        public List<PratosIngredientesViewModel> SelecionarTodos()
        {
            return _mapper.Map<List<PratosIngredientesViewModel>>(_repo.SelecionarTodos());
        }
    }
}
