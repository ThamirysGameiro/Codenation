using System.Collections.Generic;

namespace RestauranteCodenation.Application
{
    public interface IPratoAplicacao
    {
        void Incluir(PratoViewModel entity);
        void Alterar(PratoViewModel entity);
        PratoViewModel SelecionarPorId(int id);
        void Excluir(int id);
        List<PratoViewModel> SelecionarTodos();
    }
}
