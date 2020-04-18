using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Data.Repositorio
{
    public class CardapioRepositorio : RepositorioBase<Cardapio>, ICardapioRepositorio
    {
        public CardapioRepositorio(Contexto contexto) : base(contexto)
        {

        }
    }
}
