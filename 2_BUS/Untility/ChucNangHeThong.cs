using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Untilities
{
    public class ChucNangHeThong
    {
        public string MaHoaPass(string password)
        {
            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
        public string PassRandom(int lengthCode)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";//String char for random password

            var random = new Random();
            // set string password random none repeat have length equals 6
            var randomString = new string(Enumerable.Repeat(chars, lengthCode)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }

        public string SenderMail(string Mail, string Pass, string code)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                NetworkCredential cred = new NetworkCredential("thangdqph17086@fpt.edu.vn", "Thangdo22039");
                MailMessage mgs = new MailMessage();
                mgs.From = new MailAddress(Mail);
                mgs.To.Add(Mail);
                mgs.Subject = "ban da su dung tinh nang quen mat khau";
                mgs.Body = "chao anh/chi .mat khau moi truy cap phan mem la : " + Pass + "\nMã xác nhận của bạn là :" + code/* + "\nMã sẽ vô hiệu lực sau 1 phút"*/;
                client.Credentials = cred;
                client.EnableSsl = true;
                client.Send(mgs);
                return "send mail sucessful";
            }
            catch (Exception e)
            {
                return "send mail error : " + e.Message;
            }
        }
    }
    
}
