using System.Collections.Generic;

namespace RestauranteCodenation.Application
{
    public interface ICardapioAplicacao   
    {
        void Incluir(CardapioViewModel entity);
        void Alterar(CardapioViewModel entity);
        CardapioViewModel SelecionarPorId(int id);
        void Excluir(int id);
        List<CardapioViewModel> SelecionarTodos();
    }
}
