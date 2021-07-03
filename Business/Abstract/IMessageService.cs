using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAllInbox();
        List<Message> GetAllSendbox();
        void AddMessage(Message message);
        void DeleteMessage(Message message);
        void UpdateMessage(Message message);
        Message GetById(int id);
    }
}
