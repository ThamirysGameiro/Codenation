using RestauranteCodenation.Domain.Repositorio;
using System.Collections.Generic;

namespace RestauranteCodenation.Domain
{
    public class TipoPrato : IEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Prato> Pratos { get; set; }
    }
}
