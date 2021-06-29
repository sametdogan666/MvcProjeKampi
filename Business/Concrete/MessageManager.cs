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
    public class MessageManager:IMessageService
    {
        private IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetAll()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com");
        }

        public void AddMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public void UpdateMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
