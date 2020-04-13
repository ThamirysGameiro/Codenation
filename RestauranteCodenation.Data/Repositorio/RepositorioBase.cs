using RestauranteCodenation.Domain.Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteCodenation.Data.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class, IEntity
    {
        protected readonly Contexto _contexto;
        public RepositorioBase()
        {
            _contexto = new Contexto();
        }

        public void Incluir(T entity)
        {
            _contexto.Set<T>().Add(entity);
            _contexto.SaveChanges();
        }

        public void Alterar(T entity)
        {
            _contexto.Set<T>().Update(entity);
            _contexto.SaveChanges();
        }

        public T SelecionarPorId(int id)
        {
            return _contexto.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Excluir(int id)
        {
            var entity = SelecionarPorId(id);
            _contexto.Set<T>().Remove(entity);
            _contexto.SaveChanges();
        }

        public List<T> SelecionarTodos()
        {
            return _contexto.Set<T>().ToList();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
