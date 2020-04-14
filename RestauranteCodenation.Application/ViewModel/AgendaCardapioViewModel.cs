namespace RestauranteCodenation.Application
{
    public class AgendaCardapioViewModel
    {
        public int IdCardapio { get; set; }
        public CardapioViewModel Cardapio { get; set; }
        public int IdAgenda { get; set; }
        public AgendaViewModel Agenda { get; set; }
        public int Id { get; set; }
    }
}
