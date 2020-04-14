namespace RestauranteCodenation.Application
{
    public class PratosIngredientesViewModel
    {
        public int IdPrato { get; set; }
        public PratoViewModel Prato { get; set; }

        public int IdIngrediente { get; set; }
        public IngredienteViewModel Ingrediente { get; set; }
        public int Id { get; set; }
    }
}
