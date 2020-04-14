using System;
using System.Collections.Generic;

namespace RestauranteCodenation.Application
{
    public class IngredienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Validade { get; set; }
        public List<PratosIngredientesViewModel> PratosIngredientes { get; set; }        
    }
}
