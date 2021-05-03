using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager
    {
        private GenericRepository<Category> repository = new GenericRepository<Category>();

        public List<Category> GetAll()
        {
            return repository.List();
        }

        public void AddCategory(Category category)
        {
            if (category.CategoryName == "" || category.CategoryName.Length < 3 || category.CategoryDescription == "" ||
                category.CategoryName.Length > 51)
            {
                // Hata mesajı
            }
            else
            {
                repository.Insert(category);
            }
        }
    }
}
