using _1_DAL.IService;
using _1_DAL.Context;
using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Service
{
    public class ServiceChatLieu : IServiceChatLieu
    {
        DBContext _DbContext;
        public ServiceChatLieu()
        {
            _DbContext = new DBContext();
        }

        public string AddChatLieu(ChatLieu chatLieu)
        {
            _DbContext.ChatLieus.Add(chatLieu);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteChatLieu(ChatLieu chatLieu)
        {
            _DbContext.ChatLieus.Update(chatLieu);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditChatLieu(ChatLieu chatLieu)
        {
            _DbContext.ChatLieus.Update(chatLieu);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<ChatLieu> GetLstChatLieu()
        {
            return _DbContext.ChatLieus.ToList();
        }
    }
}
