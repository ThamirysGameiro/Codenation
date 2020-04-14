using System.Collections.Generic;

namespace RestauranteCodenation.Application
{
    public interface IAgendaAplicacao   
    {
        void Incluir(AgendaViewModel entity);
        void Alterar(AgendaViewModel entity);
        AgendaViewModel SelecionarPorId(int id);
        void Excluir(int id);
        List<AgendaViewModel> SelecionarTodos();
    }
}
