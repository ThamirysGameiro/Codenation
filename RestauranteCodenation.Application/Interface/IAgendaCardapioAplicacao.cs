using System.Collections.Generic;

namespace RestauranteCodenation.Application
{
    public interface IAgendaCardapioAplicacao
    {
        void Incluir(AgendaCardapioViewModel entity);
        void Alterar(AgendaCardapioViewModel entity);
        AgendaCardapioViewModel SelecionarPorId(int id);
        void Excluir(int id);
        List<AgendaCardapioViewModel> SelecionarTodos();
    }
}
