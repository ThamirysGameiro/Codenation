using System;
using System.Collections.Generic;

namespace RestauranteCodenation.Domain.Repositorio
{
    public interface IRepositorioBase<T> : IDisposable where T : class, IEntity
    {
        void Incluir(T entity);
        void Alterar(T entity);
        T SelecionarPorId(int id);
        void Excluir(int id);
        List<T> SelecionarTodos();
    }
}
