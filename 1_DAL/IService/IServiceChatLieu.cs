using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceChatLieu
    {
        public List<ChatLieu> GetLstChatLieu();//Lấy dữ liệu bảng ChatLieu
        public string EditChatLieu(ChatLieu chatLieu);//Sửa dữ liệu bảng ChatLieu
        public string DeleteChatLieu(ChatLieu chatLieu);//Xóa dữ liệu bảng ChatLieu
        public string AddChatLieu(ChatLieu chatLieu);//Thêm dữ liệu  bảng ChatLieu
    }
}
