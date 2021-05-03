using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        private MvcContext mvcContext = new MvcContext();
        private DbSet<Category> _object;

        public void Delete(Category category)
        {
            _object.Remove(category);
            mvcContext.SaveChanges();
        }

        public void Insert(Category category)
        {
            _object.Add(category);
            mvcContext.SaveChanges();
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public List<Category> Lsit(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
