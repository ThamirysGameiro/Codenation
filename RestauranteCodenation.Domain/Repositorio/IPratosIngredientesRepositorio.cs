using System.Collections.Generic;

namespace RestauranteCodenation.Domain.Repositorio
{
    public interface IPratosIngredientesRepositorio : IRepositorioBase<PratosIngredientes>
    {
        List<PratosIngredientes> SelecionarCompleto();
    }
}
