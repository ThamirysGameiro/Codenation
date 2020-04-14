using System.Collections.Generic;

namespace RestauranteCodenation.Application
{
    public interface IIngredienteAplicacao
    {
        void Incluir(IngredienteViewModel entity);
        void Alterar(IngredienteViewModel entity);
        IngredienteViewModel SelecionarPorId(int id);
        void Excluir(int id);
        List<IngredienteViewModel> SelecionarTodos();
    }
}
