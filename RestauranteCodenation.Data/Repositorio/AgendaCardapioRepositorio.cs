﻿using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Data.Repositorio
{
    public class AgendaCardapioRepositorio : RepositorioBase<AgendaCardapio>, IAgendaCardapioRepositorio
    {
        public AgendaCardapioRepositorio(Contexto contexto) : base(contexto)
        {

        }
    }
}
