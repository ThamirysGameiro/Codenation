
using System.Collections.Generic;

namespace RestauranteCodenation.Application
{
    public interface ITipoPratoAplicacao
    {
        void Incluir(TipoPratoViewModel entity);
        void Alterar(TipoPratoViewModel entity);
        TipoPratoViewModel SelecionarPorId(int id);
        void Excluir(int id);
        List<TipoPratoViewModel> SelecionarTodos();
    }
}
