using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Data.Repositorio
{
    public class PratoRepositorio : RepositorioBase<Prato>, IPratoRepositorio
    {
        public PratoRepositorio(Contexto contexto) : base(contexto)
        {

        }
    }
}
