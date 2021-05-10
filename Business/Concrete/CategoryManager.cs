using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class CategoryManager: ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        

        public List<Category> GetAll()
        {
            return _categoryDal.List();
        }

        public void AddCategory(Category category)
        {
            _categoryDal.Insert(category);
        }
    }
}
