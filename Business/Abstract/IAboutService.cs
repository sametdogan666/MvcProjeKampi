using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAboutService
    {
        List<About> GetAll();
        void AddAbout(About about);
        About GetById(int id);
        void DeleteAbout(About about);
        void UpdateAbout(About about);
    }
}
