﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace DataAccess.Concrete.Repositories
{
    public class GenericRepository<T> : IRepositoryBase<T> where T : class
    {
        private MvcContext _mvcContext = new MvcContext();
        private DbSet<T> _object;

        public GenericRepository()
        {
            _object = _mvcContext.Set<T>();
        }

        public void Delete(T p)
        {
            var deletedEntity = _mvcContext.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            _mvcContext.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); //Sadece bir değer döndermek için SingleOrDefault metodu kullanılır.
        }

        public void Insert(T p)
        {
            var addedEntity = _mvcContext.Entry(p);
            addedEntity.State = EntityState.Added;
            //_object.Add(p);
            _mvcContext.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity = _mvcContext.Entry(p);
            updatedEntity.State = EntityState.Modified;
            _mvcContext.SaveChanges();
        }
    }
}
