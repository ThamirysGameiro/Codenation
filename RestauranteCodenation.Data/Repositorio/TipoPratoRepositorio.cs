using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Data.Repositorio
{
    public class TipoPratoRepositorio : RepositorioBase<TipoPrato>, ITipoPratoRepositorio
    {
        public TipoPratoRepositorio(Contexto contexto) : base(contexto)
        {

        }
    }
}
