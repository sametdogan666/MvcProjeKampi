using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll();
        List<Content> GetAllByWriter();
        List<Content> GetAllByHeadingId(int id);
        void AddContent(Content content);
        Content GetById(int id);
        void DeleteContent(Content content);
        void UpdateContent(Content content);
    }
}
