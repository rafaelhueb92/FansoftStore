using Fansoft.Store.Domain.Contracts;
using Fansoft.Store.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {

        protected readonly FanSoftStoreDataContext _ctx =
            new FanSoftStoreDataContext();

        public T Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            save();
            return entity;
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            save();
        }

        public T Get(object pk)
        {
            return _ctx.Set<T>().Find(pk);
        }

        public IEnumerable<T> Get()
        {
            return _ctx.Set<T>()
                .AsNoTracking() //desativa o dynamic proxie
                .ToList();
        }

        public void Update(T entity)
        {
            _ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            save();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        private void save()
        {
            _ctx.SaveChanges();
        }
    }
}
