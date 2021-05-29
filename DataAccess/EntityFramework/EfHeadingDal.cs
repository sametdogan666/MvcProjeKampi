using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.EntityFramework
{
    public class EfHeadingDal : GenericRepository<Heading>, IHeadingDal
    {
    }
}
