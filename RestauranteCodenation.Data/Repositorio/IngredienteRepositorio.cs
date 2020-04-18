using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Data.Repositorio
{
    public class IngredienteRepositorio : RepositorioBase<Ingrediente>, IIngredienteRepositorio
    {
        public IngredienteRepositorio(Contexto contexto) : base(contexto)
        {

        }
    }
}
