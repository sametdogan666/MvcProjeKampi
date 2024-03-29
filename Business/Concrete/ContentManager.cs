﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ContentManager:IContentService
    {
        private IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }


        public List<Content> GetAll()
        {
            return _contentDal.List();
        }

        public List<Content> GetAllByWriter(int id)
        {
            return _contentDal.List(x => x.WriterId == id);
        }

        public List<Content> GetAllByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }

        public void AddContent(Content content)
        {
            _contentDal.Insert(content);
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteContent(Content content)
        {
            throw new NotImplementedException();
        }

        public void UpdateContent(Content content)
        {
            throw new NotImplementedException();
        }
    }
}
