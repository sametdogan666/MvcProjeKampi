using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AboutManager:IAboutService
    {
        private IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public List<About> GetAll()
        {
            return _aboutDal.List();
        }

        public void AddAbout(About about)
        {
           _aboutDal.Insert(about);
        }

        public About GetById(int id)
        {
            return _aboutDal.Get(x => x.AboutId == id);
        }

        public void DeleteAbout(About about)
        {
            _aboutDal.Delete(about);
        }

        public void UpdateAbout(About about)
        {
           _aboutDal.Update(about);
        }
    }
}
